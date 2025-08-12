using Isotop2.Data;
using Isotop2.Data.Controllers;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Isotop2
{
    public partial class MainForm : Window
    {
                                            //////////  МЕТОДЫ/СОБЫТИЯ ОСНОВНОЙ ФОРМЫ  ///////////
        public MainForm()
        {            
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if (!MainFormController.Authorization())
                this.Close();
        }
        //Событие открытия формы FormData
        private void menuItem_OpenFormData_Click(object sender, RoutedEventArgs e)
        {
            MainFormController.OpenFormData();
            RefreshAllData();
            MainFormController.FillTechnetiumCoefficientChildren(comboBox_ChildrenAge);
        }
        //Событие открытия формы РИ
        private void menuItem_OpenFormRI_Click(object sender, RoutedEventArgs e)
        {
            MainFormController.OpenRIForm();
        }
        //Событие закрытие формы(сохранение настроек)
        private void MainForm_FormClosed(object sender, EventArgs e)
        {
            MainFormController.SaveSettings
                (
                    Convert.ToDecimal(textBox_ActivityNewGeneration.Text),
                    Convert.ToDecimal(textBox_ActivityOldGeneration.Text),
                    (int)slider_TimeOfDecay.Value,
                    Convert.ToDateTime(datePicker_DateOnDayZeroIodine.Text),
                    Convert.ToDecimal(textBox_IodineActivity.Text),
                    Convert.ToDecimal(textBox_ActivityRadium.Text),
                    Convert.ToDateTime(datePicker_CreateDateRadium.Text),
                    Convert.ToDecimal(textBox_PatientWeightRadium.Text)
                );
        }
        //Событие смены пользователя
        private void menuItem_ChangeUser_Click(object sender, RoutedEventArgs e)
        {
            MainFormController.Authorization();
            MainFormController.SetUserName();
        }
        //Событие выхода через главное меню
        private void menuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //Событие загрузки формы
        private void MainForm_Load(object sender, RoutedEventArgs e)
        {
            //Устанавливаем текущего пользователя
            MainFormController.SetUserName();
            //Загрузка настроек
            MainFormController.LoadSettings
                (
                    textBox_ActivityNewGeneration, 
                    textBox_ActivityOldGeneration, 
                    slider_TimeOfDecay, 
                    datePicker_DateOnDayZeroIodine, 
                    textBox_IodineActivity, 
                    textBox_ActivityRadium, 
                    datePicker_CreateDateRadium, 
                    textBox_PatientWeightRadium
                );


            ///////// ЧАСТЬ ДЛЯ ТЕХНЕЦИЯ /////////

            //Выводим значение текущего времени распада
            textBlock_Hour.Text = (slider_TimeOfDecay.Value / 2) + " час.";

            //Обновляем ListView
            RefreshAllData();

            //Заполняем ComboBox возрастов детей
            MainFormController.FillTechnetiumCoefficientChildren(comboBox_ChildrenAge);

            ///////// ******************** /////////

            ///////// ЧАСТЬ ДЛЯ ЙОДА /////////

            RefrashListViewIodine();

            ///////// ******************** /////////

            ///////// ЧАСТЬ ДЛЯ РАДИЯ /////////

            //Устанавливаем разность дней для Радия
            datePicker_CurrentDateRadium.Text = DateTime.Now.ToString();
            MainFormController.SetDifferenceDayRadium
                (
                    Convert.ToDateTime(datePicker_CreateDateRadium.Text), 
                    Convert.ToDateTime(datePicker_CurrentDateRadium.Text)
                );

            RefrashListViewRadium();
            RefrashListViewPatient();

            ///////// ******************** /////////
        }
        //Событие проверки на ввод чисел для TextBox
        //Без точки
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
        }
        //С точкой
        private void NumberValidationTextBoxWithDot(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9,]").IsMatch(e.Text);
        }

                                         /////////////////////////////////////////////////                                         

                                        //////////  МЕТОДЫ/СОБЫТИЯ ПО ИЗОТОПАМ  ///////////

        ///////// ЧАСТЬ ДЛЯ ТЕХНЕЦИЯ /////////

        //Метод обновление ListView нового генератора
        private void RefrashListViewNewGeneration()
        {
            MainFormController.FillListViewGeneration
                (
                    listView_CalculateNewGeneration, 
                    Convert.ToDecimal(textBox_ActivityNewGeneration.Text)
                );
        }
        //Метод обновление ListView старого генератора
        private void RefrashListViewOldGeneration()
        {
            MainFormController.FillListViewGeneration
                (
                    listView_CalculateOldGeneration, 
                    Convert.ToDecimal(textBox_ActivityOldGeneration.Text)
                );
        }
        //Метод обновление ListView по маркерам для взрослых
        private void RefrashListViewAdults()
        {
            MainFormController.GetListTechnetiumPatient
                (
                    listView_EstimatedActivitybyAdults, 
                    Convert.ToDecimal(textBox_ActivityNewGeneration.Text), 
                    Convert.ToDecimal(textBox_ActivityOldGeneration.Text), 
                    true
                );
        }
        //Метод обновление ListView по маркерам для детей
        private void RefrashListViewChildrens()
        {
            MainFormController.GetListTechnetiumPatient
                (
                    listView_EstimatedActivitybyChildren, 
                    Convert.ToDecimal(textBox_ActivityNewGeneration.Text), 
                    Convert.ToDecimal(textBox_ActivityOldGeneration.Text), 
                    false
                );
        }
        //Метод полного обновления
        private void RefreshAllData()
        {
            double hour = slider_TimeOfDecay.Value;
            MainFormController.SetTechnetiumCurrentDecay(hour);
            textBlock_Hour.Text = hour.ToString() + " час.";

            RefrashListViewNewGeneration();
            RefrashListViewOldGeneration();
            RefrashListViewAdults();
            RefrashListViewChildrens();
        }
        //Событие обновления ListView после введения активности для нового генератора
        private void textBox_ActivityNewGeneration_ValueChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox_ActivityNewGeneration.Text != "" && textBox_ActivityOldGeneration.Text != "")
            { 
                RefrashListViewNewGeneration();
                RefrashListViewAdults();
                RefrashListViewChildrens();
            }
        }
        //Событие обновления ListView после введения активности для старого генератора
        private void textBox_ActivityOldGeneration_ValueChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox_ActivityNewGeneration.Text != "" && textBox_ActivityOldGeneration.Text != "")
            {
                RefrashListViewOldGeneration();
                RefrashListViewAdults();
                RefrashListViewChildrens();
            }
        }
        //Событие изменение времени распада
        private void slider_TimeOfDecay_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            RefreshAllData();
        }
        //Событие изменения возраста ребёнка
        private void comboBox_ChildrenAge_SelectedChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox_ChildrenAge.SelectedValue != null)
            { 
                MainFormController.SetChildrenCoefficent(comboBox_ChildrenAge.SelectedValue.ToString());
                RefrashListViewChildrens();
            }
        }
        //Событие печати Технеция
        private void button_PrintTechnetium_Click(object sender, RoutedEventArgs e)
        {
            MainFormController.PrintTechnetiumForm
                (   
                    Convert.ToDecimal(textBox_ActivityNewGeneration.Text), 
                    Convert.ToDecimal(textBox_ActivityOldGeneration.Text), 
                    comboBox_ChildrenAge.Text
                );
        }

        ///////// ******************** /////////

        ///////// ЧАСТЬ ДЛЯ ЙОДА /////////

        //Метод обновления списка раcпада Йода
        private void RefrashListViewIodine()
        {
            if (textBox_IodineActivity.Text != "" && datePicker_DateOnDayZeroIodine.Text != "")
                MainFormController.FillListViewIodine
                    (
                        listView_CalculationIodine, 
                        Convert.ToDecimal(textBox_IodineActivity.Text), 
                        Convert.ToDateTime(datePicker_DateOnDayZeroIodine.Text)
                    );
        }
        //Событие изменения стартовой даты Йода
        private void datePicker_DateOnDayZeroIodine_SelectionDataChanged(object sender, SelectionChangedEventArgs e)
        {
            RefrashListViewIodine();
        }
        //Событие изменение активности Йода
        private void textBox_ActivityIodine_ValueChanged(object sender, TextChangedEventArgs e)
        {
            RefrashListViewIodine();
        }
        //Событие печати Йода
        private void button_PrintIodune_Click(object sender, RoutedEventArgs e)
        {
            MainFormController.PrintIodine(listView_CalculationIodine, Convert.ToDecimal(textBox_IodineActivity.Text));
        }

        ///////// ******************** /////////

        /////////// ЧАСТЬ ДЛЯ РАДИЯ /////////        

        // Метод обновление списка распада Радиа
        private void RefrashListViewRadium()
        {
            if(textBox_PatientWeightRadium.Text != "" && textBox_ActivityRadium.Text != "")
                MainFormController.FillListViewRadium(listView_CalculationRadium, Convert.ToDouble(textBox_ActivityRadium.Text));
        }
        //Метод расчёта данных на пациента
        private void RefrashListViewPatient()
        {
            if (textBox_ActivityRadium.Text != "" && textBox_PatientWeightRadium.Text != "")
            {
                //Очищаем сообщение о предупреждении
                textBlock_Warning.Text = "";
                //Проверяем на истечение срока годности
                if (!MainFormController.IsExpiredRadium())
                    textBlock_Warning.Text = "СРОК ГОДНОСТИ ИСТЁК!";
                if(MainFormController.GetDefferenceDayRadiun() < 0)
                    textBlock_Warning.Text = "НЕ КОРРЕКТНО УКАЗАНЫ ДАТЫ!";
                MainFormController.FillListViewRadiumForPatient
                    (
                        listView_CalculationActivityRadium, 
                        Convert.ToDecimal(textBox_PatientWeightRadium.Text), 
                        Convert.ToDouble(textBox_ActivityRadium.Text)
                    );
            }
        }
        //Событие для изменения значение TextBox
        private void textBox_ActivityRadium_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (AuxiliaryFuntions.ValidationTextBox(textBox_ActivityRadium.Text))
            {                 
                RefrashListViewRadium();
                RefrashListViewPatient();
            }
        }
        //Событие изменения Даты изготовления
        private void datePicker_CreateDateRadium_SelectionDataChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datePicker_CreateDateRadium.Text != "" && datePicker_CurrentDateRadium.Text != "")
            { 
                MainFormController.SetDifferenceDayRadium
                    (
                        Convert.ToDateTime(datePicker_CreateDateRadium.Text), 
                        Convert.ToDateTime(datePicker_CurrentDateRadium.Text)
                    );
                RefrashListViewPatient();
            }
        }
        //Событие изменения текущей даты
        private void datePicker_CurrentDateRadium_SelectionDataChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datePicker_CreateDateRadium.Text != "" && datePicker_CurrentDateRadium.Text != "")
            { 
                MainFormController.SetDifferenceDayRadium
                    (
                        Convert.ToDateTime(datePicker_CreateDateRadium.Text), 
                        Convert.ToDateTime(datePicker_CurrentDateRadium.Text)
                    );
                RefrashListViewPatient();
            }
        }
        //Событие изменения веса пациента
        private void textBox_PatientWeightRadium_ValueChanged(object sender, TextChangedEventArgs e)
        {
            RefrashListViewPatient();
        }
        //Событие добавления пациента в список Радия
        private void button_AddPatient_Click(object sender, RoutedEventArgs e)
        {
            MainFormController.AddRadiumPatientList
                (
                    listView_RadiumPatientList, 
                    Convert.ToDecimal(textBox_PatientWeightRadium.Text), 
                    Convert.ToDouble(textBox_ActivityRadium.Text)
                );
        }
        //Событие удаления пациента из списка Радия
        private void button_DeletePatient_Click(object sender, RoutedEventArgs e)
        {
            MainFormController.DeleteRadiumPatientList(listView_RadiumPatientList);
        }
        //Событие печати списка пациентов Радия
        private void button_PrintRadium_Click(object sender, RoutedEventArgs e)
        {
            MainFormController.PrintRadium
                (
                    listView_RadiumPatientList, 
                    Convert.ToDateTime(datePicker_CurrentDateRadium.Text), 
                    Convert.ToDecimal(textBox_PatientWeightRadium.Text), 
                    Convert.ToDouble(textBox_ActivityRadium.Text)
                );
        }
        //Метод нажатия Delete
        private void listView_RadiumPatientList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                button_DeletePatient_Click(sender, e);
        }
        ///////// ******************** /////////             
    }
}