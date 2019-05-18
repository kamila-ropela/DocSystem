using DocSystem.Models;
using System;
using System.Collections.Generic;

namespace DocSystem.DatabaseFiles.Helper
{
    public static class PrescriptionTable
    {
   

        public static List<Prescription> GetDataByPatientId(int id)
        {
            return Properties.dbContext.GetPrescriptionDb($@"SELECT Prescription.Id,
                                                            Prescription.PatientId,
                                                            Concat(Doctor.Name, ' ', Doctor.Surname) AS DoctorName,
                                                            Prescription.Medicine,
                                                            Prescription.Description,
                                                            Prescription.Date,
                                                            Prescription.Refund
                                                     FROM Prescription
                                                     INNER JOIN Doctor ON Prescription.DoctorId = Doctor.Id
                                                     INNER JOIN Patient ON Prescription.PatientId = Patient.Id
                                                     WHERE Prescription.Id = {id}");

        }




        public static List<Prescription> DoctorPrescription(int patientId, int doctorId, string medicine, string description, DateTime date, string refund)
        {
            return Properties.dbContext.GetPrescriptionDb($@"INSERT INTO Prescription (PatientId, DoctorId, Medicine, Description, Date, Refund) 
                                                     VALUES ('" + patientId + "," + doctorId + "," +
                                                     medicine + "," + description + "," + "','CURDATE()' + refund);");
        }
    


       


        public static void InsertData(int patientId, int doctorId, string medicine, string description, DateTime date, string refund)
        {
            Properties.dbContext.ExecuteQuery($@"INSERT INTO  Prescription(PatientId, DoctorId, Medicine, Description, Date, Refund) 
                                                     VALUES ({patientId},{doctorId},'{medicine}','{description}','{date}','{refund}')");
        }







        public static List<Prescription> GetData()
        {
            return Properties.dbContext.GetPrescriptionDb($@"SELECT Prescription.Id,
                                                            Prescription.PatientId,
                                                            Concat(Doctor.Name, ' ', Doctor.Surname) AS DoctorName,
                                                            Prescription.Medicine,
                                                            Prescription.Description,
                                                            Prescription.Date,
                                                            Prescription.Refund
                                                     FROM Prescription
                                                     INNER JOIN Doctor ON Prescription.DoctorId = Doctor.Id");
        }

    }
}