using System;
using System.ComponentModel.DataAnnotations;

namespace DocSystem.Models
{
    public class Visit
    {
        public int Id { get; set; }

        public string PatientName { get; set; }

        public string DoctorName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Type { get; set; }

        public string Doctor { get; set; }

        public string Status { get; set; }

        public DateTime Date { get; set; }
    }

    public enum Choose
    {
        wizyta,
        skierowanie
    }

}
