using System.ComponentModel.DataAnnotations.Schema;

namespace Isotop2.Data.Entities
{
    public class RI
    {
        public int Id { get; set; }
        public int? RadionuclideId { get; set; }
        [ForeignKey(nameof(RadionuclideId))]
        public Radionuclide Radionuclide { get; set; }
        public string PassportNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public double Weight { get; set; }
        public string? GeneratorNumber { get; set; }
        public double Volume { get; set; }
        public double Activity { get; set; }
        public int? RadionuclideCompoundId { get; set; }
        [ForeignKey(nameof(RadionuclideCompoundId))]
        public RadionuclideCompound RadionuclideCompound { get; set; }
        public int? ManufacturerId { get; set; }
        [ForeignKey(nameof(ManufacturerId))]
        public Manufacturer Manufacturer { get; set; }
        public string Operation { get; set; }
        public DateTime OperationDate { get; set; }
        public int? PackageId { get; set; }
        [ForeignKey(nameof(PackageId))]
        public Package Package { get; set; }
        public int? StoragePointId { get; set; }
        [ForeignKey(nameof(StoragePointId))]
        public StoragePoint StoragePoint { get; set; }
        public int? SupplierId { get; set; }
        [ForeignKey(nameof(SupplierId))]
        public Supplier Supplier { get; set; }
        public int? RecipientId { get; set; }
        [ForeignKey(nameof(RecipientId))]
        public Recipient Recipient { get; set; }
        public string AccompanyingDocument { get; set; }
        public bool Sent { get; set; }
        public RI() { }
    }
}
