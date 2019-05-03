using DocSystem.Models;
using System.Collections.Generic;

namespace DocSystem.DatabaseFiles.Helper
{
    public static class DocumentationTable
    {
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
    }
}
