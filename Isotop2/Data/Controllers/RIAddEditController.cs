using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using Isotop2.Services;
using Isotop2.Data.Interfaces;
using Isotop2.Data.Entities;
using System.Windows;

namespace Isotop2.Data.Controllers
{
    internal class RIAddEditController
    {
        static private IRIModel _model = ServiceProviderHolder.ServiceProvider.GetRequiredService<IRIModel>(); //Объект РИ

        //Метод заполнения Combobox в форме
        static public void FillComboboxes(ComboBox radionuclide, ComboBox compound, ComboBox manufacturer, ComboBox package, ComboBox storage, ComboBox supplier, ComboBox recipient)
        {
            _model.RefrashData();
            radionuclide.ItemsSource = _model.GetRadionuclideList().Select(r => r.RadionuclideName);
            compound.ItemsSource = _model.GetRadionuclideCompoundList().Select(c => c.Compound);
            manufacturer.ItemsSource = _model.GetManufacturerList().Select(m => m.ManufacturerName);
            package.ItemsSource = _model.GetPackageList().Select(p => p.PackageName);
            storage.ItemsSource = _model.GetStoragePointList().Select(s => s.StoragePointName);
            supplier.ItemsSource = _model.GetSupplierList().Select(s => s.SupplierName);
            recipient.ItemsSource = _model.GetRecipientList().Select(r => r.RecipientName);
        }

        //Добавлени РИ
        static public void AddRI(string radionuclide, string passportNumber, string createDate, string weight, string volume, string generatorNumber,
                                  string activity, string compound, string manufacturer, string operation, string operationDate, string package,
                                  string storage, string supplier, string recipient, string document, bool sent)
        {
            //Проверяем на заполенени необходимых полей
            if (radionuclide == "" || passportNumber == "" || weight == "" || volume == "" || activity == "" || compound == "" ||
                manufacturer == "" || operation == "" | package == "" || storage == "" || supplier == "" || recipient == "" || document == "")
            {
                MessageBox.Show("Все обязательные поля должны быть заполнены", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!_model.AddRI
                    (
                        radionuclide,
                        passportNumber,
                        createDate,
                        weight,
                        volume,
                        generatorNumber,
                        activity,
                        compound,
                        manufacturer,
                        operation,
                        operationDate,
                        package,
                        storage,
                        supplier,
                        recipient,
                        document,
                        sent
                    )
                )
            {
                MessageBox.Show("Не удалось создать РИ", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Редактирование РИ
        static public void EditRI(string radionuclide, string passportNumber, string createDate, string weight, string volume, string generatorNumber,
                                  string activity, string compound, string manufacturer, string operation, string operation_date, string package,
                                  string storage, string supplier, string recipient, string document, bool sent)
        {
            if(!_model.EditRI
                    (
                        
                        radionuclide, 
                        passportNumber, 
                        createDate, 
                        weight, 
                        volume, 
                        generatorNumber, 
                        activity, 
                        compound, 
                        manufacturer,
                        operation, 
                        operation_date, 
                        package, 
                        storage, 
                        supplier, 
                        recipient, 
                        document, 
                        sent
                    )
                )
            {            
                    MessageBox.Show("Не удалось обновить РИ", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Заполнение контролов в форме данными РИ
        static public void FillRIData(int riId, ComboBox radionuclide, TextBox passportNumber, DatePicker createDate, TextBox weight, TextBox volume,
                                        TextBox generatorNumber, TextBox activity, ComboBox compound, ComboBox manufacturer, TextBox operation, 
                                        DatePicker operationDate, ComboBox package, ComboBox storage, ComboBox supplier, ComboBox recipient, TextBox document, CheckBox sent)
        {
            //Если ID меньше нуля, значит РИ создаётся
            if (riId < 0) return;

            //Устанавлеваем id выбранного РИ
            _model.SetCurrenRI(riId);

            //Получаем необходимый РИ
            RI? ri = _model.GetRIbyId(riId);
            if (ri == null)
            {
                MessageBox.Show("Не удалось получить РИ", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Заполняем данными РИ соответствующие контролы
            radionuclide.Text = ri.Radionuclide.RadionuclideName;
            passportNumber.Text = ri.PassportNumber;
            createDate.Text = ri.CreateDate.ToString();
            weight.Text = ri.Weight.ToString();
            volume.Text = ri.Volume.ToString();
            generatorNumber.Text = ri.GeneratorNumber == null ? "" : ri.GeneratorNumber.ToString(); //Может быть null
            activity.Text = ri.Activity.ToString();
            compound.Text = ri.RadionuclideCompound.Compound;
            manufacturer.Text = ri.Manufacturer.ManufacturerName;
            operation.Text = ri.Operation;
            operationDate.Text = ri.OperationDate.ToString();
            package.Text = ri.Package.PackageName;
            storage.Text = ri.StoragePoint.StoragePointName;
            supplier.Text = ri.Supplier.SupplierName;
            recipient.Text = ri.Recipient.RecipientName;
            document.Text = ri.AccompanyingDocument;
            sent.IsChecked = ri.Sent;
        }
        //Метод получения состояния создания РИ
        public static bool IsRICreated()
        {
            return _model.IsRICreated();
        }
        //Метод установки Id текущей сущности РИ
        public static void SetCurretnId(int id)
        {
            _model.SetCurrenRI(id);
        }
        //Метод получения Id текущей сущности РИ
        public static int GetCurrenRI()
        {
            return _model.GetCurrentRI();
        }
    }
}

