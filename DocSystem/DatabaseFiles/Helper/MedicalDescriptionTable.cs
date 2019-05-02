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
                                                     WHERE MedicalDescription.Id = {id}");
        }


        public static List<MedicalDescription> AddDescription(int patientId, int doctorId, string type, string description, DateTime date)
        {

            return Properties.dbContext.GetMedicalDescriptionDb($@"INSERT INTO MedicalDescription 
                                                                    VALUES ({patientId},{doctorId},{type},{description},{date})");
        }
    }
}
