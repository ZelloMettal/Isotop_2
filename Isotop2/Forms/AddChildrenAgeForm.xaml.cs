using Isotop2.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Isotop2.Forms
{
    public partial class AddChildrenAgeForm : Window
    {
        public AddChildrenAgeForm()
        {
            InitializeComponent();
            textBox_Age.Focus();
        }
        //Событие добавления
        private void button_OK_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_Age.Text != "" && textBox_Coefficent.Text != "")
            {
                if (AuxiliaryFuntions.ValidationTextBox(textBox_Coefficent.Text))
                    this.DialogResult = true;
                else
                    MessageBox.Show("Введены не корректные данные!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Введите значение!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
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
        //Событие проверка на ввод цифр, запятой, удаления
        private void NumberWithDotValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9,]").IsMatch(e.Text);
        }
        //Метод получения введённых данных из формы
        public (string, string) GetEnteredData()
        {
            return (textBox_Age.Text, textBox_Coefficent.Text);
        }
    }
}
