using System.ComponentModel.DataAnnotations;

namespace DocSystem.Models
{
    public class User
    {
        [Required(ErrorMessage = "This field is required")]
        public string Login { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
