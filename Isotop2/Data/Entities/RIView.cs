namespace Isotop2.Data.Entities
{
    public class RIView
    {
        public int Id { get; set; } //ID
        public string RadionuclideName { get; set; } //Наименование ОРИ
        public string PassportNumber { get; set; } //Номер паспорта
        public string CreateDate { get; set; } //Дата создания
        public double Weight { get; set; } //Масса
        public string? GeneratorNumber { get; set; } //Номер генератора(для технеция)
        public double Volume { get; set; } //Объём
        public double Activity { get; set; } //Активность
        public string Compound { get; set; } //Радионуклиидный состав ОРИ
        public string ManufacturerName { get; set; } //Произволдитель
        public string Operation { get; set; } //Вид операции
        public string OperationDate { get; set; } //Дата операции
        public string PackageName { get; set; } //Тип упаковки
        public string StoragePointName { get; set; } //Место хранение
        public string SupplierName { get; set; } //Поставщик
        public string RecipientName { get; set; } //Получатель
        public string AccompanyingDocument { get; set; } //Сопроводительный документ
        public bool Sent { get; set; } //Отправлен ли изотоп        
    }
}

