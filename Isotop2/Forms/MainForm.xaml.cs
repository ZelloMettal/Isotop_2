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
        public MainForm()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if (!MainFormController.Authorization())             
                this.Close();            
        }
     
        private void menuItem_OpenFormData_Click(object sender, RoutedEventArgs e)
        {
            MainFormController.OpenFormData();
            RefreshAllData();
            MainFormController.FillTechnetiumCoefficientChildren(comboBox_ChildrenAge);
        }
    
        private void menuItem_OpenFormRI_Click(object sender, RoutedEventArgs e)
        {
            MainFormController.OpenRIForm();
        }
     
        private void MainForm_FormClosed(object sender, EventArgs e)
        {
            MainFormController.SaveSettings
                (
                    textBox_ActivityNewGeneration.Text,
                    textBox_ActivityOldGeneration.Text,
                    slider_TimeOfDecay.Value,
                    datePicker_DateOnDayZeroIodine.Text,
                    textBox_IodineActivity.Text,
                    textBox_ActivityRadium.Text,
                    datePicker_CreateDateRadium.Text,
                    textBox_PatientWeightRadium.Text
                );
        }
     
        private void menuItem_ChangeUser_Click(object sender, RoutedEventArgs e)
        {
            MainFormController.Authorization();
            MainFormController.SetUserName();
        }
     
        private void menuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
      
        private void MainForm_Load(object sender, RoutedEventArgs e)
        {
            MainFormController.SetUserName();
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

            textBlock_Hour.Text = (slider_TimeOfDecay.Value / 2) + " час.";
            RefreshAllData();
            MainFormController.FillTechnetiumCoefficientChildren(comboBox_ChildrenAge);

            ///////// ******************** /////////

            ///////// ЧАСТЬ ДЛЯ ЙОДА /////////

            RefrashListViewIodine();

            ///////// ******************** /////////

            ///////// ЧАСТЬ ДЛЯ РАДИЯ /////////

            datePicker_CurrentDateRadium.Text = DateTime.Now.ToString();
            MainFormController.SetDifferenceDayRadium(datePicker_CreateDateRadium.Text, datePicker_CurrentDateRadium.Text);
            RefrashListViewRadium();
            RefrashListViewPatient();

            ///////// ******************** /////////
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]").IsMatch(e.Text);
        }

        private void NumberValidationTextBoxWithDot(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9,]").IsMatch(e.Text);
        }

        ///////// ЧАСТЬ ДЛЯ ТЕХНЕЦИЯ /////////

        private void RefrashListViewNewGeneration()
        {
            MainFormController.FillListViewGeneration(listView_CalculateNewGeneration, textBox_ActivityNewGeneration.Text);
        }

        private void RefrashListViewOldGeneration()
        {
            MainFormController.FillListViewGeneration(listView_CalculateOldGeneration, textBox_ActivityOldGeneration.Text);
        }

        private void RefrashListViewAdults()
        {
            MainFormController.GetListTechnetiumPatient(listView_EstimatedActivitybyAdults, textBox_ActivityNewGeneration.Text, textBox_ActivityOldGeneration.Text, true);
        }
  
        private void RefrashListViewChildrens()
        {
            MainFormController.GetListTechnetiumPatient(listView_EstimatedActivitybyChildren, textBox_ActivityNewGeneration.Text, textBox_ActivityOldGeneration.Text, false);
        }

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

        private void textBox_ActivityNewGeneration_ValueChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox_ActivityNewGeneration.Text != "" && textBox_ActivityOldGeneration.Text != "")
            { 
                RefrashListViewNewGeneration();
                RefrashListViewAdults();
                RefrashListViewChildrens();
            }
        }

        private void textBox_ActivityOldGeneration_ValueChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox_ActivityNewGeneration.Text != "" && textBox_ActivityOldGeneration.Text != "")
            {
                RefrashListViewOldGeneration();
                RefrashListViewAdults();
                RefrashListViewChildrens();
            }
        }

        private void slider_TimeOfDecay_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            RefreshAllData();
        }

        private void comboBox_ChildrenAge_SelectedChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox_ChildrenAge.SelectedValue != null)
            { 
                MainFormController.SetChildrenCoefficent(comboBox_ChildrenAge.SelectedValue.ToString());
                RefrashListViewChildrens();
            }
        }
    
        private void button_PrintTechnetium_Click(object sender, RoutedEventArgs e)
        {
            MainFormController.PrintTechnetiumForm(textBox_ActivityNewGeneration.Text, textBox_ActivityOldGeneration.Text, comboBox_ChildrenAge.Text);
        }

        ///////// ******************** /////////

        ///////// ЧАСТЬ ДЛЯ ЙОДА /////////

        private void RefrashListViewIodine()
        {
            if (textBox_IodineActivity.Text != "" && datePicker_DateOnDayZeroIodine.Text != "")
                MainFormController.FillListViewIodine(listView_CalculationIodine, textBox_IodineActivity.Text, datePicker_DateOnDayZeroIodine.Text);
        }
    
        private void datePicker_DateOnDayZeroIodine_SelectionDataChanged(object sender, SelectionChangedEventArgs e)
        {
            RefrashListViewIodine();
        }

        private void textBox_ActivityIodine_ValueChanged(object sender, TextChangedEventArgs e)
        {
            RefrashListViewIodine();
        }

        private void button_PrintIodune_Click(object sender, RoutedEventArgs e)
        {
            MainFormController.PrintIodine(listView_CalculationIodine, textBox_IodineActivity.Text);
        }

        ///////// ******************** /////////

        /////////// ЧАСТЬ ДЛЯ РАДИЯ /////////        

        private void RefrashListViewRadium()
        {
            if(textBox_PatientWeightRadium.Text != "" && textBox_ActivityRadium.Text != "")
                MainFormController.FillListViewRadium(listView_CalculationRadium, textBox_ActivityRadium.Text);
        }

        private void RefrashListViewPatient()
        {
            if (textBox_ActivityRadium.Text != "" && textBox_PatientWeightRadium.Text != "")
            { 
                textBlock_Warning.Text = "";
                if (!MainFormController.IsExpiredRadium())
                    textBlock_Warning.Text = "СРОК ГОДНОСТИ ИСТЁК!";
                if(MainFormController.GetDefferenceDayRadiun() < 0)
                    textBlock_Warning.Text = "НЕ КОРРЕКТНО УКАЗАНЫ ДАТЫ!";
                MainFormController.FillListViewRadiumForPatient(listView_CalculationActivityRadium, textBox_PatientWeightRadium.Text, textBox_ActivityRadium.Text);
            }
        }

        private void textBox_ActivityRadium_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (AuxiliaryFuntions.ValidationTextBox(textBox_ActivityRadium.Text))
            {                 
                RefrashListViewRadium();
                RefrashListViewPatient();
            }
        }

        private void datePicker_CreateDateRadium_SelectionDataChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datePicker_CreateDateRadium.Text != "" && datePicker_CurrentDateRadium.Text != "")
            { 
                MainFormController.SetDifferenceDayRadium(datePicker_CreateDateRadium.Text, datePicker_CurrentDateRadium.Text);
                RefrashListViewPatient();
            }
        }

        private void datePicker_CurrentDateRadium_SelectionDataChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datePicker_CreateDateRadium.Text != "" && datePicker_CurrentDateRadium.Text != "")
            { 
                MainFormController.SetDifferenceDayRadium(datePicker_CreateDateRadium.Text, datePicker_CurrentDateRadium.Text);
                RefrashListViewPatient();
            }
        }
        
        private void textBox_PatientWeightRadium_ValueChanged(object sender, TextChangedEventArgs e)
        {
            RefrashListViewPatient();
        }
   
        private void button_AddPatient_Click(object sender, RoutedEventArgs e)
        {
            MainFormController.AddRadiumPatientList(listView_RadiumPatientList, listView_CalculationActivityRadium, textBox_PatientWeightRadium.Text, textBox_ActivityRadium.Text);
        }
    
        private void button_DeletePatient_Click(object sender, RoutedEventArgs e)
        {
            MainFormController.DeleteRadiumPatientList(listView_RadiumPatientList);
        }

        private void button_PrintRadium_Click(object sender, RoutedEventArgs e)
        {
            MainFormController.PrintRadium
                (
                    listView_RadiumPatientList, 
                    listView_CalculationActivityRadium, 
                    datePicker_CurrentDateRadium.Text                    
                );
        }

        private void listView_RadiumPatientList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                button_DeletePatient_Click(sender, e);
        }
        ///////// ******************** /////////             
    }
}