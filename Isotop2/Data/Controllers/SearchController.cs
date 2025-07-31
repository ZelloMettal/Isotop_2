using System.Windows.Controls;
using Isotop2.Data.Models;
using Isotop2.Services;
using Isotop2.Data.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Isotop2.Data.Controllers
{
    internal class SearchController
    {
        static private RIModel _model = new RIModel(ServiceProviderHolder.ServiceProvider.GetRequiredService<DataStorage<RI>>()); //Объект РИ
        
        //Метод заполнения ComboBox
        static public void FillComboboxDatePerColumn(ComboBox cb, string columnsName)
        {
            cb.SelectedIndex = -1;
            if (columnsName == "") 
                return;

            switch (columnsName)
            {
                case "Наименование РИ":
                    cb.ItemsSource = _model.GetRadionuclideList().Select(r => r.RadionuclideName);
                break;
                case "Производитель":
                    cb.ItemsSource = _model.GetManufacturerList().Select(m => m.ManufacturerName);
                break;
                case "Поставщик":
                    cb.ItemsSource = _model.GetSupplierList().Select(s => s.SupplierName);
                break;
                case "Получатель":
                    cb.ItemsSource = _model.GetRecipientList().Select(r => r.RecipientName);
                break;
            }
        }
        //Метод заполнения ComboBox
        static public void FillComboboxColumnName(ComboBox cb)
        {
            string[] headerNameToSearch = _model.GetColumnNameToSearch();
            cb.ItemsSource = headerNameToSearch;
        }
        //Метод установки настрое поиска
        static public (string, string, string) SearchSettings(string findPlace, string dataSearch, string dataAdditionalSearch = "")
        {
            (string searchItem1, string searchItem2, string searchItem3) data = ("", "", "");
            data.searchItem1 = findPlace;
            data.searchItem2 = (findPlace == "Дата изготовления" && dataSearch == "")? DateTime.Now.ToShortDateString() : dataSearch;
            data.searchItem3 = (findPlace == "Дата изготовления" && dataAdditionalSearch == "") ? DateTime.Now.ToShortDateString() : dataAdditionalSearch;
            return data;
        }
    }
}
