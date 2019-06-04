using DocSystem.Models;
using System;
using System.Collections.Generic;

namespace DocSystem.DatabaseFiles.Helper
{
    public static class DocumentationTable
    {
        public static List<Documentation> GetDocByDisease(string disease,int pid)
        {
            return Properties.dbContext.GetDocumentationDb($@"SELECT Documentation.Id,
                                                     Documentation.PatientId,
                                                     Concat(Doctor.Name, ' ', Doctor.Surname) AS DoctorName,
                                                     Documentation.Disease,
                                                     Documentation.Date
                                                     FROM Documentation
                                                     INNER JOIN Doctor ON Documentation.DoctorId = Doctor.Id
                                                     WHERE Documentation.Disease = '{disease}' AND Documentation.PatientId={pid}");
        }

        public static List<Documentation> GetDataByPatientId(int id)
        {
            return Properties.dbContext.GetDocumentationDb($@"SELECT Documentation.Id,
                                                     Documentation.PatientId,
                                                     Concat(Doctor.Name, ' ', Doctor.Surname) AS DoctorName,
                                                     Documentation.Disease,
                                                     Documentation.Date
                                                     FROM Documentation
                                                     INNER JOIN Doctor ON Documentation.DoctorId = Doctor.Id
                                                     WHERE Documentation.PatientId = {id}");
        }

        public static List<Documentation> GetDataByDoctorId(int id,int pid)
        {
            return Properties.dbContext.GetDocumentationDb($@"SELECT Documentation.Id,
                                                     Documentation.PatientId,
                                                     Concat(Doctor.Name, ' ', Doctor.Surname) AS DoctorName,
                                                     Documentation.Disease,
                                                     Documentation.Date
                                                     FROM Documentation
                                                     INNER JOIN Doctor ON Documentation.DoctorId = Doctor.Id
                                                     WHERE Documentation.DoctorId = {id} AND  Documentation.PatientId = {pid}");
        }

        public static List<Documentation> AddDescriptionView(int patientId, int doctorId, string disease, DateTime date)
        {
            return Properties.dbContext.GetDocumentationDb($@"INSERT INTO Documentation (PatientId, DoctorId, Disease, Date) 
                                                     VALUES (" + patientId + "," + doctorId + ",'" +
                                                     disease + "','CURDATE()');");
        }
        public static void InsertData(int doctorId, int patientId, Documentation documentation, string date)
        {
            Properties.dbContext.ExecuteQuery($@"INSERT INTO Documentation (PatientId, DoctorId, Disease, Date) 
                                                     VALUES (" + patientId +"," + doctorId + ",'" +
                                                     documentation.Disease + "', '"+date+"')");
        }
    }
}
