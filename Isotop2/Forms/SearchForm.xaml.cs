using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Isotop2.Data.Controllers;

namespace Isotop2.Forms
{
    partial class SearchForm : Window
    {
        public SearchForm()
        {
            InitializeComponent();
        }
        //Событие загрузки формы
        private void SearchForm_Load(object sender, RoutedEventArgs e)
        {
            SearchController.FillComboboxColumnName(comboBox_ColumnName);
            datePicker_StartDate.Text = datePicker_EndDate.Text = DateTime.Now.Date.ToShortDateString();
        }
        //Событие выбора RadioButton
        private void radioButton_ByColumns_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if(comboBox_ColumnName == null) return;
            comboBox_ColumnName.IsEnabled = true;
            comboBox_Search.IsEnabled = true;
            textBox_NumberGeneration.IsEnabled = false;
            textBox_PassportNumber.IsEnabled = false;
            datePicker_StartDate.IsEnabled = false;
            datePicker_EndDate.IsEnabled = false;
            checkBox_Sent.IsEnabled = false;
            comboBox_Search.SelectedIndex = -1;
            comboBox_ColumnName.SelectedIndex = -1;
        }
        //Событие выбора RadioButton
        private void radioButton_ByGenerator_CheckedChanged(object sender, RoutedEventArgs e)
        {
            textBox_NumberGeneration.IsEnabled = true;
            comboBox_ColumnName.IsEnabled = false;
            comboBox_Search.IsEnabled = false;
            textBox_PassportNumber.IsEnabled = false;
            datePicker_StartDate.IsEnabled = false;
            datePicker_EndDate.IsEnabled = false;
            checkBox_Sent.IsEnabled = false;
            comboBox_Search.SelectedIndex = -1;
            comboBox_ColumnName.SelectedIndex = -1;
        }
        //Событие выбора RadioButton
        private void radioButton_ByPassport_CheckedChanged(object sender, RoutedEventArgs e)
        {
            textBox_PassportNumber.IsEnabled = true;
            textBox_NumberGeneration.IsEnabled = false;
            comboBox_ColumnName.IsEnabled = false;
            comboBox_Search.IsEnabled = false;
            datePicker_StartDate.IsEnabled = false;
            datePicker_EndDate.IsEnabled = false;
            checkBox_Sent.IsEnabled = false;
            comboBox_Search.SelectedIndex = -1;
            comboBox_ColumnName.SelectedIndex = -1;
        }
        //Событие выбора RadioButton
        private void radioButton_ByDate_CheckedChanged(object sender, RoutedEventArgs e)
        {
            datePicker_StartDate.IsEnabled = true;
            datePicker_EndDate.IsEnabled = true;
            textBox_PassportNumber.IsEnabled = false;
            textBox_NumberGeneration.IsEnabled = false;
            comboBox_ColumnName.IsEnabled = false;
            comboBox_Search.IsEnabled = false;
            checkBox_Sent.IsEnabled = false;
            comboBox_Search.SelectedIndex = -1;
            comboBox_ColumnName.SelectedIndex = -1;
        }
        //Событие выбора RadioButton
        private void radioButton_BySent_CheckedChanged(object sender, RoutedEventArgs e)
        {
            comboBox_ColumnName.IsEnabled = false;
            comboBox_Search.IsEnabled = false;
            textBox_NumberGeneration.IsEnabled = false;
            textBox_PassportNumber.IsEnabled = false;
            datePicker_StartDate.IsEnabled = false;
            datePicker_EndDate.IsEnabled = false;
            checkBox_Sent.IsEnabled = true;
            comboBox_Search.SelectedIndex = -1;
            comboBox_ColumnName.SelectedIndex = -1;
        }
        //Событие заполнения ComboBox для поиска
        private void comboBox_ColumnName_SelectedChanged(object sender, SelectionChangedEventArgs e)
        {            
            if(comboBox_ColumnName.SelectedItem != null) 
                SearchController.FillComboboxDatePerColumn(comboBox_Search, comboBox_ColumnName.SelectedItem.ToString());
        }
        //Событие нажатия кнопки отмены
        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //Событие нажатия кнопки поиска
        private void button_Search_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        //Метод получения данных из формы
        public (string, string, string) GetEnteredData()
        {
            (string searchItem1, string searchItem2, string searchItem3) _dataSearch = ("", "", "");
            if (radioButton_ByColumns.IsChecked == true)
                return SearchController.SearchSettings(comboBox_ColumnName.Text, comboBox_Search.Text);
            else if (radioButton_ByGenerator.IsChecked == true)
                return SearchController.SearchSettings(radioButton_ByGenerator.Content.ToString(), textBox_NumberGeneration.Text);
            else if (radioButton_ByPassport.IsChecked == true)
                return SearchController.SearchSettings(radioButton_ByPassport.Content.ToString(), textBox_PassportNumber.Text);
            else if (radioButton_ByDate.IsChecked == true)
                return SearchController.SearchSettings(radioButton_ByDate.Content.ToString(), datePicker_StartDate.Text, datePicker_EndDate.Text);
            else if (radioButton_BySent.IsChecked == true)
                return SearchController.SearchSettings(radioButton_BySent.Content.ToString(), checkBox_Sent.IsChecked.ToString());
            return _dataSearch;
        }
        //Событие нажатие Enter
        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                button_Search_Click(sender, e);
        }
    }
}
