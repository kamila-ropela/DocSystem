using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DocSystem.Models
{
    public class Documentation
    {
        public int Id { get; set; }
        [DisplayName("Id pacjenta")]
        public int PatientId { get; set; }
        [DisplayName("Id doktora")]
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Choroba")]
        public string Disease { get; set; }
        [DisplayName("Data")]
        public DateTime Date { get; set; }
    }
}
