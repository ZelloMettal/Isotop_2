using System.ComponentModel.DataAnnotations.Schema;

namespace Isotop2.Data.Entities
{
    public class RI
    {
        public int Id { get; set; } //ID
        public int? RadionuclideId { get; set; } //Наименование ОРИ
        [ForeignKey(nameof(RadionuclideId))]
        public Radionuclide Radionuclide { get; set; }
        public string PassportNumber { get; set; } //Номер паспорта
        public DateTime CreateDate { get; set; } //Дата создания
        public double Weight { get; set; } //Масса
        public string? GeneratorNumber { get; set; } //Номер генератора(для технеция)
        public double Volume { get; set; } //Объём
        public double Activity { get; set; } //Активность
        public int? RadionuclideCompoundId { get; set; } //Радионуклиидный состав ОРИ
        [ForeignKey(nameof(RadionuclideCompoundId))]
        public RadionuclideCompound RadionuclideCompound { get; set; }
        public int? ManufacturerId { get; set; } //Произволдитель
        [ForeignKey(nameof(ManufacturerId))]
        public Manufacturer Manufacturer { get; set; }
        public string Operation { get; set; } //Вид операции
        public DateTime OperationDate { get; set; } //Дата операции
        public int? PackageId { get; set; } //Тип упаковки
        [ForeignKey(nameof(PackageId))]
        public Package Package { get; set; }
        public int? StoragePointId { get; set; } //Место хранение
        [ForeignKey(nameof(StoragePointId))]
        public StoragePoint StoragePoint { get; set; }
        public int? SupplierId { get; set; } //Поставщик
        [ForeignKey(nameof(SupplierId))]
        public Supplier Supplier { get; set; }
        public int? RecipientId { get; set; } //Получатель
        [ForeignKey(nameof(RecipientId))]
        public Recipient Recipient { get; set; }
        public string AccompanyingDocument { get; set; } //Сопроводительный документ
        public bool Sent { get; set; } //Отправлен ли изотоп
        public RI() { }
    }
}
