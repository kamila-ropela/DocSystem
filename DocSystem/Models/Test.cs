using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DocSystem.Models
{
    public class Test
    {
        public int Id { get; set; }
        [DisplayName("Id pacjenta")]
        public int PatientId { get; set; }
        [DisplayName("Id doktora")]
        public int DoctorId { get; set; }
        [Required]
        [DisplayName("Opis")]
        public string Description { get; set; }
        [DisplayName("Data")]
        public DateTime Date { get; set; }
    }
}
