using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Isotop2.Forms
{
    public partial class AddMarkerForm : Window
    {
        public AddMarkerForm()
        {
            InitializeComponent();
            textBox_Name.Focus();
        }
    
        private void button_OK_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_Name.Text != "" && textBox_MaxActivity.Text != "" && textBox_MinActivity.Text != "")
            { 
                if(Convert.ToInt32(textBox_MaxActivity.Text) >= Convert.ToInt32(textBox_MinActivity.Text))                    
                    this.DialogResult = true;
                else
                    MessageBox.Show("Минимальное значение не может быть больше максимального.", "Ошибка!", MessageBoxButton.OK,  MessageBoxImage.Error);            
            }    
            else            
                MessageBox.Show("Введите значение!", "Ошибка!", MessageBoxButton.OK,  MessageBoxImage.Error);            
        }
    
        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }        
     
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
        }
    
        private void PressHotKey(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                button_OK_Click(sender, e);
            if (e.Key == Key.Escape)
                button_Cancel_Click(sender, e);
        }
   
        public (string, string, string, bool) GetEnteredData()
        {
            return (textBox_Name.Text, textBox_MaxActivity.Text, textBox_MinActivity.Text, checkBox_IsNewGenerator.IsChecked.Value);
        }
    }
}
