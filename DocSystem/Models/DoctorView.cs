namespace DocSystem.Models
{
    public class DoctorView
    {
        public Patient patient { get; set; }

        public Visit visit { get; set; }

        public Test test { get; set; }

        public Prescription prescription { get; set; }
    }
}
