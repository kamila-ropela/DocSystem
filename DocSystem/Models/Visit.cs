using System;
using System.ComponentModel;

namespace DocSystem.Models
{
    public class Visit
    {
        public int Id { get; set; }
        [DisplayName("Id pacjenta")]
        public int PatientId { get; set; }
        [DisplayName("Id doktora")]
        public int DoctorId { get; set; }
        [DisplayName("Typ")]
        public string Type { get; set; }
        [DisplayName("Doktor")]
        public string Doctor { get; set; }
        [DisplayName("Status")]
        public string Status { get; set; }
        [DisplayName("Data")]
        public DateTime Date { get; set; }
    }
}
