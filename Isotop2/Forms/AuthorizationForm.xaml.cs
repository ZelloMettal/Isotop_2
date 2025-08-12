using Isotop2.Data.Controllers;
using Isotop2.Data;
using System.Security;
using System.Windows;
using System.Windows.Input;

namespace Isotop2.Forms
{
    public partial class AuthorizationForm : Window
    {
        public AuthorizationForm()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            textBox_UserName.Focus();
        }
        //Событие авторизации
        private void button_OK_Click(object sender, RoutedEventArgs e)
        {
            if ((textBox_UserName.Text != "" && textBox_UserPassword.Text != "") || (textBox_UserName.Text != "" && passwordBox_UserPassword.Password != ""))
            {
                SecureString securePass = new SecureString();
                if (!checkBox_ShowPassword.IsChecked.Value)
                {
                    securePass = passwordBox_UserPassword.SecurePassword;
                    securePass.MakeReadOnly();
                }
                else
                { 
                    securePass = AuxiliaryFuntions.StringToSecureString(textBox_UserPassword.Text);    //Защищаем полученную строку
                    securePass.MakeReadOnly();
                }

                if (AuthorizationController.VerifyUser(textBox_UserName.Text, securePass))
                    this.DialogResult = true;
                else
                {
                    MessageBox.Show("Неверное имя пользователя или пароль!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    textBox_UserPassword.Text = passwordBox_UserPassword.Password = "";
                }
            }
            else
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        //Событие отмены
        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }        
        //Событие отображения/скрытия пароля
        private void checkBox_ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            textBox_UserPassword.Text = passwordBox_UserPassword.Password;
            textBox_UserPassword.Visibility = Visibility.Visible;
            textBox_UserPassword.TabIndex = 1;
            passwordBox_UserPassword.Visibility = Visibility.Hidden;
        }
        private void checkBox_ShowPassword_Uncheked(object sender, RoutedEventArgs e)
        {
            passwordBox_UserPassword.Password = textBox_UserPassword.Text;
            textBox_UserPassword.Visibility = Visibility.Hidden;
            textBox_UserPassword.TabIndex = -1;
            passwordBox_UserPassword.Visibility = Visibility.Visible;
            passwordBox_UserPassword.TabIndex = 1;
        }
        //Метод нажатия Enter
        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                button_OK_Click(sender, e);
        }
        //Метод получения роли текущего пользователя
        public bool GetUserRole()
        {
            return AuthorizationController.GetUserRole();
        }
        //Метод получения текущего пользователя
        public string GetUserName()
        {
            return AuthorizationController.GetUserName();
        }
    }
}
