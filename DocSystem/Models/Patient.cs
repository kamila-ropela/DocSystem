using DocSystem.DatabaseFiles;

namespace DocSystem.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Pesel { get; set; }

        public string Address { get; set; }
    }
}
