using DocSystem.Models;
using System.Collections.Generic;

namespace DocSystem.DatabaseFiles.Helper
{
    public static class PatientTable
    {

        public static List<Patient> GetPatientBySurname(string surname)
        {
            return Properties.dbContext.GetPatientDb($@"SELECT Patient.Id,
                                                             Patient.Name,
                                                             Patient.Surname,
                                                             Patient.Pesel,
                                                             Patient.Address
                                                     FROM Patient
                                                     WHERE Patient.Surname = '{surname}'");
        }

        public static List<Patient> GetPatientByPesel(int pesel)
        {
            return Properties.dbContext.GetPatientDb($@"SELECT Patient.Id,
                                                             Patient.Name,
                                                             Patient.Surname,
                                                             Patient.Pesel,
                                                             Patient.Address
                                                     FROM Patient
                                                     WHERE Patient.Pesel = {pesel}");
        }

        public static List<Patient> GetPatientById(int id)
        {
            return Properties.dbContext.GetPatientDb($@"SELECT Patient.Id,
                                                             Patient.Name,
                                                             Patient.Surname,
                                                             Patient.Pesel,
                                                             Patient.Address
                                                     FROM Patient
                                                     WHERE Patient.Id = {id}");
        }
    }
}
