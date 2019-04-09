using System.ComponentModel;

namespace DocSystem.Models
{
    public class User
    {
        [DisplayName("Login")]
        public string Login { get; set; }
        [DisplayName("Haslo")]
        public string Password { get; set; }
        [DisplayName("Rola")]
        public string Role { get; set; }
    }
}
