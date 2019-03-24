using System;
using System.ComponentModel.DataAnnotations;

namespace DocSystem.Models
{
    public class Test
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }
        
        [Required]
        public string Type { get; set; }

        public double Value { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}
