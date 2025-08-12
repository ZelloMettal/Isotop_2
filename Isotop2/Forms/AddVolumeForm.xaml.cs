using Isotop2.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Isotop2.Forms
{
    public partial class AddVolumeForm : Window
    {
        public AddVolumeForm()
        {
            InitializeComponent();
            textBox_Volume.Focus();
        }        
        // Событие нажатия кнопки Ok/Save
        private void button_OK_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_Volume.Text != "")
            {
                if (AuxiliaryFuntions.ValidationTextBox(textBox_Volume.Text))
                { 
                    if(textBox_Volume.Text != "0")
                        this.DialogResult = true;
                    else
                        MessageBox.Show("Объём не может быть \"0\"", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                    MessageBox.Show("Введены не корректные данные!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Введите значение!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);            
        }
        // Событие закрытия формы
        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //Событие на ввод цифр, запятой, удаление
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9,]").IsMatch(e.Text);
        }
        //Событие нажатие Enter
        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                button_OK_Click(sender, e);
        }
        //Метод получения введённых данных
        public string GetEnteredData()
        { 
            return textBox_Volume.Text;
        }
    }
}
