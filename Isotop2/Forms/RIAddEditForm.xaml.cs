using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Isotop2.Data.Controllers;

namespace Isotop2.Forms
{
    public partial class RIAddEditForm : Window
    {
        //Конструктор формы для создани РИ
        public RIAddEditForm()
        {
            InitializeComponent();
            //Устанавливаем название кнопки в зависимости от выбранного функционала формы 
            button_AddEdit.Content = "Добавить";
        }

        //Конструктор формы для редактирования формы
        public RIAddEditForm(int id)
        {
            InitializeComponent();
            RIAddEditController.SetCurretnId(id);
            //Устанавливаем название кнопки в зависимости от выбранного функционала формы 
            button_AddEdit.Content = "Сохранить";
        }
        //Событие загрузки формы
        private void RIAddEditForm_Load(object sender, RoutedEventArgs e)
        {
            //Заполнение combobox
            RIAddEditController.FillComboboxes
                (
                    comboBox_Radionuclide, 
                    comboBox_Compound, 
                    comboBox_Manufacturer, 
                    comboBox_Package,
                    comboBox_StoragePoint, 
                    comboBox_Supplier, 
                    comboBox_Recipient
                );

            //Устанавливаем даты
            datePicker_CreateDate.Text = DateTime.Now.ToString();
            datePicker_OperationDate.Text = DateTime.Now.ToString();

            int currentId = RIAddEditController.GetCurrenRI();
            //Заполняем контролы при редактирования сущности РИ
            if(currentId > 0)
                RIAddEditController.FillRIData
                    (
                        currentId, 
                        comboBox_Radionuclide, 
                        textBox_PassportNumber, 
                        datePicker_CreateDate, 
                        textBox_Weight, 
                        textBox_Volume, 
                        textBox_GeneratorNumber, 
                        textBox_Activity, 
                        comboBox_Compound, 
                        comboBox_Manufacturer, 
                        textBox_Operation, 
                        datePicker_OperationDate, 
                        comboBox_Package,
                        comboBox_StoragePoint, 
                        comboBox_Supplier, 
                        comboBox_Recipient, 
                        textBox_AccompanyingDocument, 
                        checkBox_Sent
                    );
        }
        //Событие закрытия формы
        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //Событие добавления/редактирования РИ
        private void button_AddEdit_Click(object sender, RoutedEventArgs e)
        {
            if (datePicker_CreateDate.Text == "" || datePicker_OperationDate.Text == "")
            {
                MessageBox.Show("Неверно указаны даты", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (button_AddEdit.Content == "Добавить")
            {
                RIAddEditController.AddRI
                    (
                        comboBox_Radionuclide.Text, 
                        textBox_PassportNumber.Text, 
                        datePicker_CreateDate.Text, 
                        textBox_Weight.Text, 
                        textBox_Volume.Text,
                        textBox_GeneratorNumber.Text, 
                        textBox_Activity.Text, 
                        comboBox_Compound.Text, 
                        comboBox_Manufacturer.Text, 
                        textBox_Operation.Text,
                        datePicker_OperationDate.Text, 
                        comboBox_Package.Text, 
                        comboBox_StoragePoint.Text, 
                        comboBox_Supplier.Text,
                        comboBox_Recipient.Text,
                        textBox_AccompanyingDocument.Text, 
                        checkBox_Sent.IsChecked.Value
                     );
            }
            else
            {
                RIAddEditController.EditRI
                    (
                        comboBox_Radionuclide.Text, 
                        textBox_PassportNumber.Text, 
                        datePicker_CreateDate.Text, 
                        textBox_Weight.Text, 
                        textBox_Volume.Text,
                        textBox_GeneratorNumber.Text, 
                        textBox_Activity.Text, 
                        comboBox_Compound.Text, 
                        comboBox_Manufacturer.Text,
                        textBox_Operation.Text,
                        datePicker_OperationDate.Text,
                        comboBox_Package.Text,
                        comboBox_StoragePoint.Text,
                        comboBox_Supplier.Text,
                        comboBox_Recipient.Text,
                        textBox_AccompanyingDocument.Text,
                        checkBox_Sent.IsChecked.Value
                    );
            }
            if (!RIAddEditController.IsRICreated())
            {
                //Если РИ не удалось создать
                MessageBox.Show("Заполнены не все обязательные поля", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            this.Close();
        }
        private void comboBox_Radionuclide_SelectedChanged(object sender, SelectionChangedEventArgs e)
        { 
            if(comboBox_Radionuclide.SelectedItem.ToString() == "Технеций-99m")
                textBox_GeneratorNumber.IsEnabled = true;
            else 
                textBox_GeneratorNumber.IsEnabled = false;
        }
        //События проверки на допустимость символов        
        ///////С точкой
        private void NumberValidationTextBoxWithDot(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9,]").IsMatch(e.Text);
        }
        /////////Без точки
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
        }
        //Событие нажатие Enter
        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                button_AddEdit_Click(sender, e);
        }
    }
}
