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

        private void button_OK_Click(object sender, RoutedEventArgs e)
        {
            if(textBox_PatientName.Text != string.Empty)
                this.DialogResult = true;
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
   
        public string GetEnteredData()
        {
            return textBox_PatientName.Text;
        }        
    }
}
