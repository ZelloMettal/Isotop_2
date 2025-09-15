using CsvHelper.Configuration.Attributes;

namespace Isotop2.Data.Entities
{ 
    public class RIView
    {
        [IgnoreAttribute]
        public int Id { get; set; } //ID
        [Name("Наименование РИ")]
        public string RadionuclideName { get; set; } //Наименование ОРИ
        [Name("Номер паспотра")]        
        public string PassportNumber { get; set; } //Номер паспорта
        [Name("Дата изготовления")]        
        public string CreateDate { get; set; } //Дата создания
        [Name("Масса, Кг")]        
        public double Weight { get; set; } //Масса
        [Name("Номер генератора")]        
        public string? GeneratorNumber { get; set; } //Номер генератора(для технеция)
        [Name("Объём, Мл")]        
        public double Volume { get; set; } //Объём
        [Name("Активность, МБк")]        
        public double Activity { get; set; } //Активность
        [Name("Состав РИ")]   
        public string Compound { get; set; } //Радионуклиидный состав ОРИ
        [Name("Производитель")]        
        public string ManufacturerName { get; set; } //Произволдитель
        [Name("Вид операции")]        
        public string Operation { get; set; } //Вид операции
        [Name("Дата операции")]        
        public string OperationDate { get; set; } //Дата операции
        [Name("Тип упаковки")]        
        public string PackageName { get; set; } //Тип упаковки
        [Name("Место хранения")]        
        public string StoragePointName { get; set; } //Место хранение
        [Name("Поставщик")]        
        public string SupplierName { get; set; } //Поставщик
        [Name("Получаетль")]        
        public string RecipientName { get; set; } //Получатель
        [Name("Документ")]        
        public string AccompanyingDocument { get; set; } //Сопроводительный документ
        [Name("Отправлен")]        
        public bool Sent { get; set; } //Отправлен ли изотоп        
    }
}

