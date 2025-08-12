using System.Windows;
using System.Security;
using System.Windows.Input;

namespace Isotop2.Forms
{
    public partial class AddUserForm : Window
    {
        public AddUserForm()
        {
            InitializeComponent();
            textBox_UserName.Focus();
        }
        //Событие получение данных из формы
        private void button_OK_Click(object sender, RoutedEventArgs e)
        {
            if ((textBox_UserName.Text != "" && textBox_Password.Text != "" && textBox_ConfirmPassword.Text != "") || (textBox_UserName.Text != "" && passworBox_Password.Password != "" && passworBox_ConfirmPassword.Password != ""))
            {
                if ((textBox_Password.Text == textBox_ConfirmPassword.Text && textBox_Password.Text != "" && textBox_ConfirmPassword.Text != "") || (passworBox_Password.Password == passworBox_ConfirmPassword.Password && passworBox_Password.Password != "" && passworBox_ConfirmPassword.Password != ""))               
                    this.DialogResult = true;                
                else                
                    MessageBox.Show("Пароли не совпадают!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);                
            }
            else            
                MessageBox.Show("Введите значение!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);            
        }
        //Событие закрытия формы
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
        //Событие отображения пароля
        private void checkBox_ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            textBox_Password.Text = passworBox_Password.Password;
            textBox_ConfirmPassword.Text = passworBox_ConfirmPassword.Password;
            textBox_Password.Visibility = Visibility.Visible;
            textBox_ConfirmPassword.Visibility = Visibility.Visible;
            passworBox_Password.Visibility = Visibility.Hidden;
            passworBox_ConfirmPassword.Visibility = Visibility.Hidden;
        }
        //Событие скрытия пароля
        private void checkBox_ShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            passworBox_Password.Password = textBox_Password.Text;
            passworBox_ConfirmPassword.Password = textBox_ConfirmPassword.Text;
            textBox_Password.Visibility = Visibility.Hidden;
            textBox_ConfirmPassword.Visibility = Visibility.Hidden;
            passworBox_Password.Visibility = Visibility.Visible;
            passworBox_ConfirmPassword.Visibility = Visibility.Visible;
        }
        //Метод получения введённых данных
        public (string, SecureString, bool) GetEnteredData()
        {
            return (textBox_UserName.Text, passworBox_Password.SecurePassword, checkBox_Administrator.IsChecked.Value);
        }
    }
}
