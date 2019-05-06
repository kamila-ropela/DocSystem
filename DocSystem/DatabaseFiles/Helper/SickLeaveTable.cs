using DocSystem.Models;
using System.Collections.Generic;

namespace DocSystem.DatabaseFiles.Helper
{
    public static class SickLeaveTable
    {
        public static List<SickLeave> GetDataByPatientId(int id)
        {
            return Properties.dbContext.GetSickLeaveDb($@"SELECT SickLeave.Id,
                                                     Concat(Doctor.Name, ' ', Doctor.Surname) AS DoctorName,
                                                     SickLeave.Days,
                                                     SickLeave.Description,
                                                     MedicalDescription.Date
                                                     FROM SickLeave
                                                     INNER JOIN Doctor ON SickLeave.DoctorId = Doctor.Id
                                                     WHERE SickLeave.Id = {id}");
        }



        public static List<SickLeave> AddDescription(int patientId, int doctorId, int days, string description, System.DateTime date)
        {

            return Properties.dbContext.GetSickLeaveDb($@"INSERT INTO DoctorSickLeave 
                                                                    VALUES ({patientId},{doctorId},{days},{description},{date})");
        }

        public static void InsertData(int doctorId, SickLeave sick)
        {
            Properties.dbContext.ExecuteQuery($@"INSERT INTO SickLeave 
                                                                    VALUES ({doctorId},{sick.Days},{sick.Description},{sick.Date})");
        }
    }

}
