using DocSystem.Models;
using System;
using System.Collections.Generic;

namespace DocSystem.DatabaseFiles.Helper
{
    public static class PrescriptionTable
    {
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
                                                     WHERE Prescription.PatientId = {id}");
        }

        public static List<Prescription> DoctorPrescription(int patientId, int doctorId, string medicine, string description, DateTime date, int refund)
        {

            return Properties.dbContext.GetPrescriptionDb($@"INSERT INTO Prescription 
                                                                    VALUES ({patientId},{doctorId},{medicine},{description},{date},{refund})");
        }


        public static void InsertData(int doctorId, Prescription presc)
        {
            Properties.dbContext.ExecuteQuery($@"INSERT INTO MedicalDescription 
                                                                    VALUES ({doctorId},{presc.Medicine},{presc.Description},{presc.Date},{presc.Refund})");
        }






    }
}
