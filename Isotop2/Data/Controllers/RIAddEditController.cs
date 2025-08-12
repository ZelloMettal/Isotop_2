using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using Isotop2.Services;
using Isotop2.Data.Models;
using Isotop2.Data.Entities;

namespace Isotop2.Data.Controllers
{
    internal class RIAddEditController
    {
        static private RIModel _model = new RIModel(ServiceProviderHolder.ServiceProvider.GetRequiredService<DataStorage<RI>>()); //Объект РИ

        //Метод заполнения combobox в форме
        static public void FillComboboxes(ComboBox radionuclide, ComboBox compound, ComboBox manufacturer, ComboBox package, ComboBox storage, ComboBox supplier, ComboBox recipient)
        {
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
            RI ri = _model.CreateRI
                        (
                            _model.GetCurrentRI(), 
                            radionuclide, 
                            passportNumber, 
                            Convert.ToDateTime(createDate), 
                            weight, 
                            volume, 
                            generatorNumber, 
                            activity, 
                            compound, 
                            manufacturer,
                            operation, 
                            Convert.ToDateTime(operationDate), 
                            package, 
                            storage, 
                            supplier, 
                            recipient, 
                            document, 
                            sent
                        );

            if (ri != null)
                _model.AddRI(ri);
        }

        //Редактирование РИ
        static public void EditRI(string radionuclide, string passportNumber, string createDate, string weight, string volume, string generatorNumber,
                                  string activity, string compound, string manufacturer, string operation, string operation_date, string package,
                                  string storage, string supplier, string recipient, string document, bool sent)
        {
            RI ri = _model.CreateRI
                        (
                            _model.GetCurrentRI(), 
                            radionuclide, 
                            passportNumber, 
                            Convert.ToDateTime(createDate), 
                            weight, 
                            volume, 
                            generatorNumber, 
                            activity, 
                            compound, 
                            manufacturer,
                            operation, 
                            Convert.ToDateTime(operation_date), 
                            package, 
                            storage, 
                            supplier, 
                            recipient, 
                            document, 
                            sent
                        );

            if (ri != null)
                _model.EditRI(ri);
        }

        //Заполнение контролов в форме данными РИ
        static public void FillRIData(int riId, ComboBox radionuclide, TextBox passportNumber, DatePicker createDate, TextBox weight, TextBox volume,
                                        TextBox generatorNumber, TextBox activity, ComboBox compound, ComboBox manufacturer, TextBox operation, 
                                        DatePicker operationDate, ComboBox package, ComboBox storage, ComboBox supplier, ComboBox recipient, TextBox document, CheckBox sent)
        {
            //Устанавлеваем id выбранного РИ
            _model.SetCurrenRI(riId);
            //Получаем необходимый РИ
            RI ri = _model.GetRIbyId(riId);
            if (ri == null)
                return;
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

