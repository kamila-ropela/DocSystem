using DocSystem.Models;
using System.Collections.Generic;

namespace DocSystem.DatabaseFiles.Helper
{
    public static class PrescriptionTable
    {
        public static List<Prescription> GetData()
        {
            return Properties.dbContext.GetPrescriptionDb(@"SELECT *
                                                     FROM Prescription");
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
    }
}
