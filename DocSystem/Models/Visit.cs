using System;

namespace DocSystem.Models
{
    public class Visit
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public string Type { get; set; }

        public string Doctor { get; set; }

        public string Status { get; set; }

        public DateTime Date { get; set; }
    }
}
