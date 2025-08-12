using System.Windows;
using System.Windows.Input;

namespace Isotop2.Forms
{
    public partial class AddForm : Window
    {
        public AddForm()
        {
            InitializeComponent();  
            textBox_Value.Focus();
        }
        //Событие добавления
        private void button_OK_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_Value.Text != "")            
                this.DialogResult = true;            
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
        //Метод получения введённых данных из формы
        public string GetEnteredData()
        {
            return textBox_Value.Text;
        }
    }
}
