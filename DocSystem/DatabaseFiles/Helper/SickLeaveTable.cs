using DocSystem.Models;
using System;
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
                                                     SickLeave.Date
                                                     FROM SickLeave
                                                     INNER JOIN Patient ON SickLeave.PatientId = Patient.Id
                                                     INNER JOIN Doctor ON SickLeave.DoctorId = Doctor.Id
                                                     WHERE  Prescription.PatientId = {id}");
                                                
        }


        public static List<SickLeave> DoctorSickLeave(int patientId, int doctorId, int days, string description, DateTime date)
        {
            return Properties.dbContext.GetSickLeaveDb($@"INSERT INTO SickLeave (PatientId, DoctorId, Days, Description, Date) 
                                                     VALUES ('" + patientId + "," + doctorId + "," +
                                                     days + "," + description + "," + "','CURDATE()');");
        }



        public static void InsertData(int doctorId, SickLeave sickleave)
        {
            Properties.dbContext.ExecuteQuery($@"INSERT INTO SickLeave (PatientId, DoctorId, Days, Description, Date) 
                                                     VALUES ('" + sickleave.PatientId + "','" + doctorId + "','" +
                                                     sickleave.Days + "','" + sickleave.Description + "','" + sickleave.Date + "');");



        }







    }

}
