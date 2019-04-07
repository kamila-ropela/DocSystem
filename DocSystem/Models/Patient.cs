using System.ComponentModel;

namespace DocSystem.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [DisplayName("Imie")]
        public string Name { get; set; }
        [DisplayName("Nazwisko")]
        public string Surname { get; set; }
        [DisplayName("Pesel")]
        public int Pesel { get; set; }
        [DisplayName("Adres")]
        public string Address { get; set; }
    }
}
