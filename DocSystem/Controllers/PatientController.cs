﻿using Microsoft.AspNetCore.Mvc;
using DocSystem.DatabaseFiles.Helper;
using System;
using DocSystem.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DocSystem.DatabaseFiles;

namespace Patients.Controllers
{
    public class PatientController : Controller
    {
        public static string nameOfTest;
         public static int patientId;

        public ActionResult PatientView(Patient patient)

        {
           
            //Properties.UserId=patient.Id;

            List<Patient> name = PatientTable.GetDataByPatientId(patient.Id);
            List<Visit> visits = VisitTable.GetDataByPatientId(patient.Id);
            List<Prescription> prescriptions = PrescriptionTable.GetDataByPatientId(patient.Id);
            List<Test> tests = TestTable.GetDataByPatientId(patient.Id);
            List<Documentation> docs = DocumentationTable.GetDataByPatientId(patient.Id);
            List<MedicalDescription> list = MedicalDescriptionTable.GetDataByPatientId(patient.Id);


            ViewData["PatientName"] = name;
            ViewData["documentation"] = docs;
            ViewData["visitData"] = visits;
            ViewData["prescriptioneData"] = prescriptions;
            ViewData["Tests"] = tests;
            ViewData["Medical Descriptions"] = list;
            return View();


          
        }
        public ActionResult Visits()
        {
            return View();
        }
        public ActionResult MedicalDescriptions()
        {
            return View();
        }

        public ActionResult PatientTests()
        {
            DateTime date = DateTime.Now;
            Test test = new Test { Id = 1, Date = date, Description = "", DoctorName = "", PatientId = 1};
            List<Test> list = new List<Test>();
            list.Add(test);
            return View(list);
        }

        public IActionResult Results(int id)
        {
            DateTime date = DateTime.Now;
            Result res = new Result { Id = 1, Name="H2O",TestId=111, Unit="mm",Value=100};
            List<Result> list = new List<Result>();
            list.Add(res);
            return View(list);
        }
        public ActionResult ChartView(string name)
        {
            nameOfTest = name;
            ViewBag.name = name;

            return View();
        }

        [HttpPost]
        public JsonResult NewChart()
        {
            List<object> data = new List<object>();
            DataTable dt = new DataTable();
            dt.Columns.Add("Value", System.Type.GetType("System.Double"));
            dt.Columns.Add("Data", System.Type.GetType("System.String"));
            DataRow dr;
            
            var dataTest = TestTable.GetDataByPatientId(Properties.UserId);
            foreach (var test in dataTest)
            {
                var dataResult = ResultTable.GetDataByTestIdAndName(test.Id, nameOfTest);
                if (dataResult.Count != 0)
                {
                    for (int i = 0; i < dataResult.Count(); i++)
                    {
                        dr = dt.NewRow();
                        dr["Value"] = dataResult[i].Value;
                        dr["Data"] = test.Date.ToString("dd.MM.yyyy");
                        dt.Rows.Add(dr);
                    }                    
                }
            }

            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                data.Add(x);
            }

            return Json(data);
        }
        public ActionResult Course()
        {
            List<Documentation> docList = new List<Documentation>();
            List<Documentation> diseaseList = new List<Documentation>();

            Properties.UserId = 9;
            docList.Add(new Documentation {Id = 0, DoctorName = "", PatientId = 9, Disease = "a", Date = DateTime.Now});
            docList.Add(new Documentation { Id = 1, DoctorName = "", PatientId = 9, Disease = "b", Date = DateTime.Now });
            docList.Add(new Documentation { Id = 2, DoctorName = "", PatientId = 9, Disease = "a", Date = DateTime.Now });

            //docList.AddRange(DocumentationTable.GetDataByPatientId(Properties.UserId));
            var tmp = docList.Select(documentation => documentation.Disease).Distinct();
            foreach (var item in tmp)
            {
                diseaseList.Add(new Documentation {Disease = item });
            }
            return View(diseaseList);
        }
    }
}