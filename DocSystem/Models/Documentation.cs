using System;

namespace DocSystem.Models
{
    public class Documentation
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public string Desease { get; set; }

        public DateTime Date { get; set; }
    }
}
