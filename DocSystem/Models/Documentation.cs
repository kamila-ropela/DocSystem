using System;
using System.ComponentModel.DataAnnotations;

namespace DocSystem.Models
{
    public class Documentation
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Disease { get; set; }

        public DateTime Date { get; set; }
    }
}
