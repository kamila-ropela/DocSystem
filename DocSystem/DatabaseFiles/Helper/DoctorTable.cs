using DocSystem.Models;
using System.Collections.Generic;

namespace DocSystem.DatabaseFiles.Helper
{
    public static class DoctorTable
    {
        public static List<Doctor> GetDoctorIdBySurname(string surname)
        {
            return Properties.dbContext.GetDoctorDb($@"SELECT Doctor.Id,
                                                     Doctor.Name,
                                                     Doctor.Surname,
                                                     Doctor.Specialization
                                                     FROM Doctor
                                                     WHERE Doctor.Surname = '{surname}'");
        }
    }
}
