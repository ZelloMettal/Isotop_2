using System.Reflection;
using System.Security;
using System.Windows.Controls;
using Isotop2.Data.Entities;

namespace Isotop2.Data
{
    internal class AuxiliaryFuntions
    {
        //Метод установки заголовков в DataGrid
        public static void SetHeaderDataGrid(DataGrid dataGrid, params string[] headers)
        {             
            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                dataGrid.Columns[i].Header = headers[i];
            }
        }
        //Метод получение данных из ListView
        static public List<string> ConvertListItemsToList(List<string[]> list)
        {
            List<string> _dataList = new List<string>();
            if (list != null)
            {
                foreach (var data in list)
                {
                    for (int i = 0; i < data.Length; i++)
                        _dataList.Add(data[i]);                    
                }
            }
            return _dataList;
        }
        static public List<string> ConvertListItemsToList(List<CheckedMarkerForPrint> list)
        {
            List<string> _dataList = new List<string>();
            if (list != null)
            {
                foreach (var data in list)
                {
                    if (data.IsChecked)
                    { 
                        _dataList.Add(data.MarkerName);
                        _dataList.Add(data.Volume);
                        _dataList.Add(data.Activity);
                    }
                }
            }
            return _dataList;
        }
        //Метод конвертации словаря с Маркерами в список с отмеченными Маркерами
        static public List<CheckedMarkerForPrint> ConvertDictionaryToListChecked(Dictionary<Marker, ActivityByVolume> list)
        { 
            List<CheckedMarkerForPrint> checkedList = new List<CheckedMarkerForPrint>();
            foreach (var item in list)
            {
                CheckedMarkerForPrint checkedItem = new CheckedMarkerForPrint()
                {
                    IsChecked = false,
                    MarkerName = item.Key.MarkerName,
                    Activity = item.Value.Activity.ToString(),
                    Volume = item.Value.Volume.ToString()
                };
                checkedList.Add(checkedItem);
            }
            return checkedList;
        }
        //Метод конвертации RI в RIView
        public static List<RIView> ConvertRIToRIView(List<RI> riList)
        {
            List<RIView> list = new List<RIView>();
            foreach (var ri in riList)
            {
                RIView rv = new RIView
                {
                    Id = ri.Id,
                    RadionuclideName = ri.Radionuclide == null ? null : ri.Radionuclide.RadionuclideName,
                    PassportNumber = ri.PassportNumber,
                    CreateDate = ri.CreateDate.ToShortDateString(),
                    Weight = ri.Weight,
                    GeneratorNumber = ri.GeneratorNumber,
                    Volume = ri.Volume,
                    Activity = ri.Activity,
                    Compound = ri.RadionuclideCompound == null ? null : ri.RadionuclideCompound.Compound,
                    ManufacturerName = ri.Manufacturer == null ? null : ri.Manufacturer.ManufacturerName,
                    Operation = ri.Operation,
                    OperationDate = ri.OperationDate.ToShortDateString(),
                    PackageName = ri.Package == null ? null : ri.Package.PackageName,
                    StoragePointName = ri.StoragePoint == null ? null : ri.StoragePoint.StoragePointName,
                    SupplierName = ri.Supplier == null ? null : ri.Supplier.SupplierName,
                    RecipientName = ri.Recipient == null ? null : ri.Recipient.RecipientName,
                    AccompanyingDocument = ri.AccompanyingDocument,
                    Sent = ri.Sent
                };
                list.Add(rv);
            }
            return list;
        }
        //Метод конвертации RadiationExposureToOrgan в RadiationExposureView
        public static List<RadiationExposureView> ConvertRadiationExposureToRadiationExposureView(List<RadiationExposureToOrgan> reoList)
        {
            List<RadiationExposureView> reoView = new List<RadiationExposureView>();
            foreach (var reo in reoList)
            {
                RadiationExposureView rv = new RadiationExposureView
                {
                    Id = reo.Id,
                    Coefficient = reo.Coefficient,
                    MarkerName = reo.Marker.MarkerName,
                    OrganName = reo.Organ.OrganName
                };
                reoView.Add(rv);
            }
            return reoView;
        }
        //Метод формирования защищенной строки
        public static SecureString StringToSecureString(string str)
        {
            SecureString secureString = new SecureString();
            Array.ForEach(str.ToArray(), secureString.AppendChar);
            secureString.MakeReadOnly();
            return secureString;
        }
        //Метод конвертации ListRIView в ListString[]
        public static List<string[]> RIViewToStringList(List<RIView> dataList, bool isShowFirsColumn = false)
        {
            List<string[]> stringList = new List<string[]>();
            int j = isShowFirsColumn? 1 : 0;    //Если нужно пропустить первый столбец

            for(int i = 0; i < dataList.Count; i++)
            {
                //Получаем список свойст объекта
                PropertyInfo[] propInfo = new RIView().GetType().GetProperties();
                string[] tempData = new string[propInfo.Length];
                for (int p = 0; p < propInfo.Length - 1; p++, j++)
                {
                    tempData[p] = propInfo[j].GetValue(dataList[i], null)?.ToString();
                }
                stringList.Add(tempData);
                j = isShowFirsColumn? 1 : 0;
            }
            return stringList;
        }
        //Метод валидации TextBox для дробных значений
        public static bool ValidationTextBox(string text)
        {
            if (text != "" && text.Split(',').Length < 3 && text[0] != ',' && text[text.Length - 1] != ',')
                return true;
            return false;
        }
    }
}
