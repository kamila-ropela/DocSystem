using System;

namespace DocSystem.Models
{
    public class Percription
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public string Medicine { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}
