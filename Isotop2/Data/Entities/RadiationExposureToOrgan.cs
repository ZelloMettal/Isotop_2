namespace Isotop2.Data.Entities
{
    public class RadiationExposureToOrgan
    {
        public int Id { get; set; }
        public double Coefficient { get; set; }
        public int MarkerId { get; set; }
        public Marker Marker { get; set; }
        public int OrganId { get; set; }
        public Organ Organ { get; set; }
    }
}
