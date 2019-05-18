using DocSystem.Models;
using System.Collections.Generic;

namespace DocSystem.DatabaseFiles.Helper
{
    public static class TestTable
    {

        public static List<Test> GetDataByPatientId(int id)
        {
            return Properties.dbContext.GetTestDb($@"SELECT Test.Id,
                                                     Test.PatientId,
                                                     Concat(Doctor.Name, ' ', Doctor.Surname) AS DoctorName,
                                                     Test.Description,
                                                     Test.Date
                                                     FROM Test
                                                     INNER JOIN Doctor ON Test.DoctorId = Doctor.Id
                                                     WHERE Test.PatientId = {id}");
        }

        public static List<Test> GetData(int id)
        {
            return Properties.dbContext.GetTestDb($@"SELECT Test.Id,
                                                     Test.PatientId,
                                                     Concat(Doctor.Name, ' ', Doctor.Surname) AS DoctorName,
                                                     Test.Description,
                                                     Test.Date
                                                     FROM Test
                                                     INNER JOIN Doctor ON Test.DoctorId = Doctor.Id
                                                     INNER JOIN Patient ON Test.PatientId = Patient.Id
                                                     WHERE Test.PatientId = {id}");
        }


    }
}
