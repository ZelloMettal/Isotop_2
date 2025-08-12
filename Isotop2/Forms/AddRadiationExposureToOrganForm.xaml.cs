using Isotop2.Data.Entities;
using Isotop2.Data;
using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Isotop2.Forms
{
    public partial class AddRadiationExposureToOrganForm : Window
    {
        public AddRadiationExposureToOrganForm()
        {
            InitializeComponent();
            comboBox_Marker.Focus();
        }
        //Метод получаем данные из базы для заполнения ComboBox
        private void EditRadiationExposureToOrganForm_Load(object sender, RoutedEventArgs e)
        {
            List<Marker> markers = new DataStorage<Marker>().GetAll();
            List<Organ> organs = new DataStorage<Organ>().GetAll();
            comboBox_Marker.ItemsSource = markers.Select(x => x.MarkerName);
            comboBox_Organ.ItemsSource = organs.Select(x => x.OrganName);
        }
        //Событие созранения
        private void button_OK_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox_Marker.Text != "" && comboBox_Organ.Text != "" && textBox_Coefficient.Text != "")
            {
                if (AuxiliaryFuntions.ValidationTextBox(textBox_Coefficient.Text))
                { 
                    if (textBox_Coefficient.Text != "0")
                        this.DialogResult = true;
                    else
                        MessageBox.Show("Коэффицент не может быть \"0\"", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                    MessageBox.Show("Введены не корректные данные!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else            
                MessageBox.Show("Введите значение!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);            
        }
        //Событие проверка на ввод цифр, запятой, удаления
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9,]").IsMatch(e.Text);
        }
        //Событие отмены
        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //Событие нажатие Enter
        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                button_OK_Click(sender, e);
        }
        //Метод получения введённых данных
        public (string, string, string) GetEnteredData()
        {
            return (comboBox_Marker.Text, comboBox_Organ.Text, textBox_Coefficient.Text);
        }
    }
}
