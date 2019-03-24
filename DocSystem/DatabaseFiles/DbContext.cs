﻿using DocSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DocSystem.DatabaseFiles
{
    public class DbContext
    {
        public string ConnectionString { get; set; }

        public DbContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public int ExecuteQuery(string sqlCommand)
        {
            int result;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public List<User> GetUserDb(string sqlCommand)
        {
            List<User> list = new List<User>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new User()
                        {
                            Login = reader["Login"].ToString(),
                            Password = reader["Password"].ToString(),
                            Role = reader["Role"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public List<Patient> GetPatientDb(string sqlCommand)
        {
            List<Patient> list = new List<Patient>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Patient()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            Pesel = Convert.ToInt32(reader["Pesel"]),
                            Address = reader["Address"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public List<Doctor> GetDoctorDb(string sqlCommand)
        {
            List<Doctor> list = new List<Doctor>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Doctor()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            Specialization = reader["Address"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public List<Test> GetTestDb(string sqlCommand)
        {
            List<Test> list = new List<Test>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Test()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            PatientId = Convert.ToInt32(reader["PatientId"]),
                            DoctorId = Convert.ToInt32(reader["DoctorId"]),
                            Type = reader["Type"].ToString(),
                            Value = reader["Value"].ToString(),
                            Description = reader["Description"].ToString(),
                            Date = Convert.ToDateTime(reader["Date"])
                        });
                    }
                }
            }
            return list;
        }

        public List<Documentation> GetDocumentationDb(string sqlCommand)
        {
            List<Documentation> list = new List<Documentation>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Documentation()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            PatientId = Convert.ToInt32(reader["PatientId"]),
                            DoctorId = Convert.ToInt32(reader["DoctorId"]),
                            Date = Convert.ToDateTime(reader["Address"])
                        });
                    }
                }
            }
            return list;
        }

        public List<Prescription> GetPrescriptionDb(string sqlCommand)
        {
            List<Prescription> list = new List<Prescription>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Prescription()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            PatientId = Convert.ToInt32(reader["PatientId"]),
                            DoctorId = Convert.ToInt32(reader["DoctorId"]),
                            Medicine = reader["Medicine"].ToString(),
                            Description = reader["Description"].ToString(),
                            Date = Convert.ToDateTime(reader["Date"])
                        });
                    }
                }
            }
            return list;
        }

        public List<SickLeave> GetSickLeaveDb(string sqlCommand)
        {
            List<SickLeave> list = new List<SickLeave>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new SickLeave()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            PatientId = Convert.ToInt32(reader["PatientId"]),
                            DoctorId = Convert.ToInt32(reader["DoctorId"]),
                            Days =Convert.ToInt32(reader["Days"].ToString()),
                            Description = reader["Description"].ToString(),
                            Date = Convert.ToDateTime(reader["Date"])
                        });
                    }
                }
            }
            return list;
        }

        public List<Note> GetNoteDb(string sqlCommand)
        {
            List<Note> list = new List<Note>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Note()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            PatientId = Convert.ToInt32(reader["PatientId"]),
                            DoctorId = Convert.ToInt32(reader["DoctorId"]),
                            Type = reader["Type"].ToString(),
                            Description = reader["Description"].ToString(),
                            Date = Convert.ToDateTime(reader["Date"])
                        });
                    }
                }
            }
            return list;
        }

        public List<Visit> GetVisitDb(string sqlCommand)
        {
            List<Visit> list = new List<Visit>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Visit()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            PatientId = Convert.ToInt32(reader["PatientId"]),
                            DoctorId = Convert.ToInt32(reader["DoctorId"]),
                            Type = reader["Type"].ToString(),
                            Doctor = reader["Doctor"].ToString(),
                            Status = reader["Status"].ToString(),
                            Date = Convert.ToDateTime(reader["Date"])
                        });
                    }
                }
            }
            return list;
        }
    }
}