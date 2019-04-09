using System.ComponentModel;

namespace DocSystem.Models
{
    public class Result
    {
        public int Id { get; set; }
        [DisplayName("Id testu")]
        public int TestId { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Jednostka")]
        public string Unit { get; set; }
        [DisplayName("Wartosc")]
        public double Value { get; set; }
    }
}
