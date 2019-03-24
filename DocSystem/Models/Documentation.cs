using System;

namespace DocSystem.Models
{
    public class Documentation
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public string Disease { get; set; }

        public DateTime Date { get; set; }
    }
}
