using System.ComponentModel;

namespace DocSystem.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [DisplayName("Imie")]
        public string Name { get; set; }
        [DisplayName("Nazwisko")]
        public string Surname { get; set; }
        [DisplayName("Specjalizacja")]
        public string Specialization { get; set; }
    }
}
