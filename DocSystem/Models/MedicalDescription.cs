using System;
using System.ComponentModel;

namespace DocSystem.Models
{
    public class MedicalDescription
    {
        public int Id { get; set; }
        [DisplayName("Id pacjenta")]
        public int PatientId { get; set; }
        [DisplayName("Id doktora")]
        public int DoctorId { get; set; }
        [DisplayName("Typ")]
        public string Type { get; set; }
        [DisplayName("Opis")]
        public string Description { get; set; }
        [DisplayName("Data")]
        public DateTime Date { get; set; }
    }
}