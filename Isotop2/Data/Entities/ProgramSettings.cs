namespace Isotop2.Data.Entities
{
    public class ProgramSettings
    {
        public string FileName = Environment.CurrentDirectory + "\\Program_Settings.xml";
        public decimal NewGenerationActivity = 19000M;
        public decimal OldGenerationActivity = 19000M;
        public int TimeDecay = 0;
        public DateTime DateOnZeroDay = new DateTime(2025, 1, 1);
        public decimal IodineActivity = 200M;
        public decimal RadiumActivity = 10.2M;
        public DateTime CreateDateRadium = new DateTime(2025, 1, 1);
        public decimal PatientWeighet = 70M;
    }
}
