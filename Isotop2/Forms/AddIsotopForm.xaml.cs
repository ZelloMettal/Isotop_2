using Isotop2.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Isotop2.Forms
{
    public partial class AddIsotopForm : Window
    {
        public AddIsotopForm()
        {
            InitializeComponent();
            textBox_Day.Focus();
        }
  
        private void button_OK_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_Day.Text != "" && textBox_PrecentOfDecay.Text != "")
            { 
                if (AuxiliaryFuntions.ValidationTextBox(textBox_PrecentOfDecay.Text))
                    this.DialogResult = true;
                else
                    MessageBox.Show("Введены не корректные данные!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Введите значение!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
     
        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    
        private void PressHotKey(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                button_OK_Click(sender, e);
            if (e.Key == Key.Escape)
                button_Cancel_Click(sender, e);
        }
 
        private void NumberWithDotValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9,]").IsMatch(e.Text);
        }
    
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
        }
    
        public (string, string) GetEnteredData()
        {
            return (textBox_Day.Text, textBox_PrecentOfDecay.Text);
        }
    }
}