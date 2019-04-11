using System;
using System.ComponentModel.DataAnnotations;

namespace DocSystem.Models
{
    public class Test
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}
