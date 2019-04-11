using System;
using System.ComponentModel.DataAnnotations;

namespace DocSystem.Models
{
    public class SickLeave
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int Days { get; set; }

        public string Description { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public DateTime Date { get; set; }
    }
}
