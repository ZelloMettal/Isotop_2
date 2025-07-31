using Isotop2.Data.Controllers;
using Isotop2.Data.Entities;
using System.Windows;

namespace Isotop2.Forms
{
    public partial class TechnetiumPrintForm : Window
    {
        public TechnetiumPrintForm()
        {
            InitializeComponent();
        }
        //Конструктор с параметром
        public TechnetiumPrintForm(Dictionary<Marker, ActivityByVolume> adultList, Dictionary<Marker, ActivityByVolume> childrenList, decimal newActivity, decimal oldActivity, string childrenAge)
        {
            InitializeComponent();
            TechnetiumPrintController.SetPrintData(adultList, childrenList, newActivity, oldActivity);
            label_CurrentData.Content = $"Дата: {DateTime.Now.ToShortDateString()} - {TechnetiumPrintController.GetWeekDay(DateTime.Now.DayOfWeek.ToString())}";
            label_Children.Content = $"Дети: {childrenAge} лет";
        }
        //Событие загрузки формы
        private void TechnetiumPrintForm_Load(object sender, RoutedEventArgs e)
        {
            TechnetiumPrintController.FillListView(listView_Adult, TechnetiumPrintController.GetAdultList());
            TechnetiumPrintController.FillListView(listView_Children, TechnetiumPrintController.GetChildrenList());
        }
        //Событие печати
        private void button_Print_Click(object sender, RoutedEventArgs e)
        {
            TechnetiumPrintController.PrintDocument(checkBox_PrintAdult.IsChecked.Value, listView_Adult, checkBox_PrintChildren.IsChecked.Value, listView_Children);
        }
        //Событие выхода из формы
        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
