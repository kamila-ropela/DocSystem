using System;
using System.ComponentModel.DataAnnotations;

namespace DocSystem.Models
{
    public class MedicalDescription
    {
        public int Id { get; set; }

        public string DoctorName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Type { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}