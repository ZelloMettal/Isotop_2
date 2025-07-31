using System.Windows;
using System.Windows.Input;

namespace Isotop2.Forms
{
    public partial class AddNameRadiumPatient : Window
    {
        public AddNameRadiumPatient()
        {
            InitializeComponent();
            textBox_PatientName.Focus();
        }
        //Событие добавление пациента
        private void button_OK_Click(object sender, RoutedEventArgs e)
        {
            if(textBox_PatientName.Text != string.Empty)
                this.DialogResult = true;
            else
                MessageBox.Show("Введите значение!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        //Событие отмены
        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //Событие нажатия Enter
        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                button_OK_Click(sender, e);
        }
        //Метод получения данных формы
        public string GetEnteredData()
        {
            return textBox_PatientName.Text;
        }

        
    }
}
