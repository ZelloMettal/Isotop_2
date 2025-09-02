namespace Isotop2.Data.Entities
{
    public class Marker
    {
        public int Id { get; set; }
        public string MarkerName { get; set; }
        public int MaxActivity { get; set; }
        public int MinActivity { get; set; }
        public bool NewGenerator { get; set; }
    }
}
