using CsvHelper.Configuration.Attributes;

namespace Isotop2.Data.Entities
{ 
    public class RIView
    {
        [IgnoreAttribute]
        public int Id { get; set; }
        [Name("Наименование РИ")]
        public string RadionuclideName { get; set; }
        [Name("Номер паспотра")]        
        public string PassportNumber { get; set; }
        [Name("Дата изготовления")]        
        public string CreateDate { get; set; }
        [Name("Масса, Кг")]        
        public double Weight { get; set; }
        [Name("Номер генератора")]        
        public string? GeneratorNumber { get; set; }
        [Name("Объём, Мл")]        
        public double Volume { get; set; }
        [Name("Активность, МБк")]
        public double Activity { get; set; }
        [Name("Состав РИ")]   
        public string Compound { get; set; }
        [Name("Производитель")]        
        public string ManufacturerName { get; set; }
        [Name("Вид операции")]        
        public string Operation { get; set; }
        [Name("Дата операции")]        
        public string OperationDate { get; set; }
        [Name("Тип упаковки")]        
        public string PackageName { get; set; }
        [Name("Место хранения")]        
        public string StoragePointName { get; set; }
        [Name("Поставщик")]        
        public string SupplierName { get; set; }
        [Name("Получаетль")]        
        public string RecipientName { get; set; }
        [Name("Документ")]        
        public string AccompanyingDocument { get; set; }
        [Name("Отправлен")]        
        public bool Sent { get; set; }    
    }
}

