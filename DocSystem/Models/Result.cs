using System.ComponentModel.DataAnnotations;

namespace DocSystem.Models
{
    public class Result
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int TestId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Unit { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public double Value { get; set; }
    }
}
