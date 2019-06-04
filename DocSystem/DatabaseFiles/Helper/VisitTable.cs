using DocSystem.Models;
using System;
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

        public static List<Visit> GetDataByPatientId(int id)
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
                                                     WHERE Visit.PatientId = {id}");
          
        }

        public static List<Visit> GetDataByPatientIdAndSpecialization(int id, string specialization)
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
                                                     WHERE Visit.PatientId = {id} AND 
                                                           Visit.Doctor = '{specialization}'");

        }

        public static List<Visit> GetDataByDoctorId(int id, int pid)
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
                                                     WHERE Visit.DoctorId = {id} AND Visit.PatientId = {pid}");

        }


        public static List<Visit> DoctorVisit ( int patientId, int doctorId, string type, string doctor, string status, String date)
        {
            return Properties.dbContext.GetVisitDb($@"INSERT INTO Visit (PatientId, DoctorId, Type, Doctor, Status, Date) 
                                                     VALUES ('" + patientId + "," + doctorId + "," +
                                                     type + "," + doctor + "," + status + "','"+date+"');");
        }

        public static void InsertD(int patientId, int doctorId, string type, string doctor, string status, string date)
        {
            Properties.dbContext.ExecuteQuery($@"INSERT INTO  Visit(PatientId, DoctorId, Type, Doctor, Status, Date) 
                                                     VALUES ({patientId},{doctorId},'{type}','{doctor}','{status}','{date}')");
        }

        public static void EditVisitById(int id, string status)
        {
            Properties.dbContext.ExecuteQuery($@"updated Visit set Status = '{status}' where Id = {id}");
        }















    }
}
