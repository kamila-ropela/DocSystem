using DocSystem.Models;
using System;
using System.Collections.Generic;

namespace DocSystem.DatabaseFiles.Helper
{
    public static class MedicalDescriptionTable
    {
        public static List<MedicalDescription> GetData(int id,string descr)
        {
            return Properties.dbContext.GetMedicalDescriptionDb($@"SELECT MedicalDescription.Id,
                                                                 Concat(Doctor.Name, ' ', Doctor.Surname) AS DoctorName,
                                                                 MedicalDescription.Type,
                                                                 MedicalDescription.Description,
                                                                 MedicalDescription.Date
                                                                 FROM MedicalDescription
                                                                 INNER JOIN Doctor ON MedicalDescription.DoctorId = Doctor.Id
                                                                 INNER JOIN Patient ON MedicalDescription.PatientId = Patient.Id
                                                                 WHERE MedicalDescription.PatientId = {id} AND MedicalDescription.Description LIKE '%ok%'");
        }


        public static List<MedicalDescription> GetDataByPatientId(int id)
        {
            return Properties.dbContext.GetMedicalDescriptionDb($@"SELECT MedicalDescription.Id,
                                                     Concat(Doctor.Name, ' ', Doctor.Surname) AS DoctorName,
                                                     MedicalDescription.Type,
                                                     MedicalDescription.Description,
                                                     MedicalDescription.Date
                                                     FROM MedicalDescription
                                                     INNER JOIN Doctor ON MedicalDescription.DoctorId = Doctor.Id
                                                     INNER JOIN Patient ON MedicalDescription.PatientId = Patient.Id
                                                     WHERE MedicalDescription.PatientId = {id}");
        }

        public static List<MedicalDescription> GetDataByDoctorId(int id,int pid)
        {
            return Properties.dbContext.GetMedicalDescriptionDb($@"SELECT MedicalDescription.Id,
                                                     Concat(Doctor.Name, ' ', Doctor.Surname) AS DoctorName,
                                                     MedicalDescription.Type,
                                                     MedicalDescription.Description,
                                                     MedicalDescription.Date
                                                     FROM MedicalDescription
                                                     INNER JOIN Doctor ON MedicalDescription.DoctorId = Doctor.Id
                                                     INNER JOIN Patient ON MedicalDescription.PatientId = Patient.Id
                                                     WHERE MedicalDescription.DoctorId = {id} AND MedicalDescription.PatientId = {pid}");
        }

        public static void AddDescription(int patientId, int doctorId, string type, string description, String date)
        {
            Properties.dbContext.ExecuteQuery($@"INSERT INTO  MedicalDescription(PatientId,DoctorId,Type, Description, Date) 
                                                     VALUES ({patientId},{doctorId},'{type}','{description}','{date}')");
        }

        public static List<MedicalDescription> MedicalDescription(int patientId, int doctorId, string type, string description, DateTime date)
        {
            return Properties.dbContext.GetMedicalDescriptionDb($@"INSERT INTO Prescription (PatientId, DoctorId, Type, Description, Date) 
                                                     VALUES ('" + patientId + "," + doctorId + "," +
                                                      type + "," + description + "','CURDATE()');");
        }



    }
}
