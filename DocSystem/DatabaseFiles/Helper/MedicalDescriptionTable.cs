using DocSystem.Models;
using System;
using System.Collections.Generic;

namespace DocSystem.DatabaseFiles.Helper
{
    public static class MedicalDescriptionTable
    {
        public static List<MedicalDescription> GetDataByPatientId(int id)
        {
            return Properties.dbContext.GetMedicalDescriptionDb($@"SELECT MedicalDescription.Id,
                                                     Concat(Doctor.Name, ' ', Doctor.Surname) AS DoctorName,
                                                     MedicalDescription.Type,
                                                     MedicalDescription.Description,
                                                     MedicalDescription.Date
                                                     FROM MedicalDescription
                                                     INNER JOIN Doctor ON MedicalDescription.DoctorId = Doctor.Id
                                                     WHERE MedicalDescription.PatientId = {id}");
        }

        public static void AddDescription(int patientId, int doctorId, string type, string description, String date)
        {
            Properties.dbContext.ExecuteQuery($@"INSERT INTO  MedicalDescription(PatientId,DoctorId,Type, Description, Date) 
                                                     VALUES ({patientId},{doctorId},'{type}','{description}','{date}')");
        }
    }
}
