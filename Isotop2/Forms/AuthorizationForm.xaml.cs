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
                    securePass = AuxiliaryFuntions.StringToSecureString(textBox_UserPassword.Text);
                    securePass.MakeReadOnly();
                }

                if (AuthorizationController.VerifyUser(textBox_UserName.Text, securePass))
                    this.DialogResult = true;
                else
                {
                    MessageBox.Show("Пользователь не найден!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    textBox_UserPassword.Text = passwordBox_UserPassword.Password = "";
                }
            }
            else
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }        
     
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
   
        private void PressHotKey(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                button_OK_Click(sender, e);
            if (e.Key == Key.Escape)
                button_Cancel_Click(sender, e);
        }
  
        public bool GetUserRole()
        {
            return AuthorizationController.GetUserRole();
        }
     
        public string GetUserName()
        {
            return AuthorizationController.GetUserName();
        }
    }
}
