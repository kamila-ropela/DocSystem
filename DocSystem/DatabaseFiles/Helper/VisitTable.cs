using DocSystem.Models;
using System.Collections.Generic;

namespace DocSystem.DatabaseFiles.Helper
{
    public static class VisitTable
    {
        public static List<Visit> GetData()
        {
            return Properties.dbContext.GetVisitDb(@"SELECT Visit.Id,
                                                            Concat(Patient.Name, ' ', Patient.Surname) AS PatientName,
                                                            Concat(Doctor.Name, ' ', Doctor.Surname) AS DoctorName,
                                                            Visit.Type,
                                                            Visit.Doctor,
                                                            Visit.Status,
                                                            Visit.Date
                                                     FROM Visit
                                                     INNER JOIN Patient ON Visit.PatientId = Patient.Id
                                                     INNER JOIN Doctor ON Visit.DoctorId = Doctor.Id");
        }

        public static List<Visit> GetDataById(int id)
        {
            return Properties.dbContext.GetVisitDb($@"SELECT Visit.Id,
                                                            Concat(Patient.Name, ' ', Patient.Surname) AS PatientName,
                                                            Concat(Doctor.Name, ' ', Doctor.Surname) AS DoctorName,
                                                            Visit.Type,
                                                            Visit.Doctor,
                                                            Visit.Status,
                                                            Visit.Date
                                                     FROM Visit
                                                     INNER JOIN Patient ON Visit.PatientId = Patient.Id
                                                     INNER JOIN Doctor ON Visit.DoctorId = Doctor.Id
                                                     WHERE Visit.Id = {id}");
        }
    }
}
