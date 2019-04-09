using DocSystem.Models;
using System.Collections.Generic;

namespace DocSystem.DatabaseFiles.Helper
{
    public static class UsersTable
    {

        public static List<User> GetData()
        {
            return Properties.dbContext.GetUserDb(@"SELECT *
                                                    FROM Users");
        }

        public static List<User> GetDataByLogin(string login)
        {
            return Properties.dbContext.GetUserDb($@"SELECT *
                                                    FROM Users
                                                    WHERE Login = '{login}'");
        }

        public static void ChangePassword(string newPassword)
        {
            Properties.dbContext.ExecuteQuery($@"UPDATE Users
                                                 SET Password = '{newPassword}'
                                                 WHERE Role = 0");

            Properties.dbContext.ExecuteQuery($@"UPDATE Users
                                                 SET Password = '{newPassword}'
                                                 WHERE Role = 1");
        }

        public static (int, int) GetDataByNameAndSurname(string name, string surname)
        {
            var doctors = Properties.dbContext.GetDoctorDb($@"SELECT *
                                                              FROM Doctor
                                                              WHERE Name = '{name}' AND 
                                                              WHERE Surname = '{surname}'");

            var patients = Properties.dbContext.GetPatientDb($@"SELECT *
                                                                FROM Patient
                                                                WHERE Name = '{name}' AND 
                                                                WHERE Surname = '{surname}'");

            if(!(doctors.Count == 0 && patients.Count == 0))
            {
                if (doctors.Count != 0) return (doctors[0].Id, 1);
                else return (patients[0].Id, 0);
            }

            throw new System.ArgumentException("Duplicate");
        }
    }
}
