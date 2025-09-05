namespace Isotop2.Data.Entities
{
    public class ProgramSettings
    {
        public string FileName = Environment.CurrentDirectory + "\\Program_Settings.xml";
        public double NewGenerationActivity = 19000;
        public double OldGenerationActivity = 19000;
        public int TimeDecay = 0;
        public DateTime DateOnZeroDay = new DateTime(2025, 1, 1);
        public double IodineActivity = 200;
        public double RadiumActivity = 10.2;
        public DateTime CreateDateRadium = new DateTime(2025, 1, 1);
        public int PatientWeighet = 70;
    }
}
