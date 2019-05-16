using DocSystem.DatabaseFiles.Helper;
using DocSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Data;
using System.Linq;
using DocSystem.DatabaseFiles;

namespace DocSystem.Controllers
{
    public class DoctorController : Controller
    {
        public static int patientId;
        public static string nameOfTest;

        [HttpPost]
        public ActionResult AddDescriptionAction([FromForm]string description)
        {
            if (!description.Length.Equals("")) { 
            }
            return View(); 
        }

            public IActionResult DoctorIndex()
        {
                return View();
           
        }

        [HttpPost]
        public ActionResult DoctorIndex([FromForm]string searchString)
        {
            try
            {
                Regex regex = new Regex("[0-9]");
                List<Patient> patient;
                if (regex.IsMatch(searchString))
                    patient = PatientTable.GetPatientByPesel(System.Convert.ToInt32(searchString));
                else patient = PatientTable.GetPatientBySurname(searchString);

                if (patient.Count == 0)
                {     
                    return View();
                } else return RedirectToAction("DoctorView", "Doctor", patient[0]);
            }
            catch {
                return View();
            }
        }


        public IActionResult AddDescription() {
            return View(); 
        }
    
        public IActionResult AddDocumentationView()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDocumentationView([FromForm]Documentation documentation)
        {
            Properties.UserId = 1;
            documentation.PatientId = 2;
            DocumentationTable.InsertData(Properties.UserId, documentation);
            return View();
        }


        public IActionResult MedicalDescription(int id)
        {
            return View();
        }

        public IActionResult Visit(int id)
        {
            var data = VisitTable.GetDataById(id);

            if (data.Count == 0)
                throw new ArgumentNullException();

            Visit visitData = new Visit()
            {
                PatientName = data[0].PatientName,
                DoctorName = data[0].DoctorName,
                Doctor = data[0].Doctor,
                Status = data[0].Status,
                Type = data[0].Type,
                Date = data[0].Date
            };

            return View(visitData);
        }


        public IActionResult DoctorView(Patient patient)
        {
            patientId = patient.Id;

            List<Visit> visits = VisitTable.GetDataByPatientId(patient.Id);
            List<Prescription> prescriptions = PrescriptionTable.GetDataByPatientId(patient.Id);
            List<Test> tests = TestTable.GetDataByPatientId(patient.Id);
            List<Documentation> docs = DocumentationTable.GetDataByPatientId(patient.Id);
            List<MedicalDescription> list = MedicalDescriptionTable.GetDataByPatientId(patient.Id);

            ViewData["data"] = patient;
            ViewData["docs"] = docs;
            ViewData["visits"] = visits;
            ViewData["prescript"] = prescriptions;
            ViewData["tests"] = tests;
            ViewData["medicalDescriptionData"] = list;
            return View();
        }

        public ActionResult DoctorPrescription(int id)
        {
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoctorPrescription([FromForm] Prescription prescription)
        {
            // DateTime date = DateTime.Now;
           // Properties.UserId = 1;
            prescription.PatientId = 2;
            PrescriptionTable.InsertData(Properties.UserId, prescription);
            return View();

            
        }

       
        public IActionResult DoctorVisit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoctorVisit([FromForm]Visit visits)
        {
            


           
            VisitTable.InsertData(Properties.UserId, visits);
            return View();

            
        }

        public ActionResult DoctorSickLeave()
        {

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoctorSickLeave([FromForm]SickLeave sickleave)
        {
            DateTime data = DateTime.Now;
            SickLeaveTable.InsertData(Properties.UserId, sickleave);
            return View();

         
        }


      
        public IActionResult Results(int id)
        {
            DateTime date = DateTime.Now;
            Result res = new Result { Id = 1, Name = "H2O", TestId = 111, Unit = "mm", Value = 100 };
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

            var dataTest = TestTable.GetDataByPatientId(patientId);
            foreach (var test in dataTest)
            {
                var dataResult = ResultTable.GetDataByTestIdAndName(test.Id, nameOfTest);
                if(dataResult.Count != 0)
                {
                    dr = dt.NewRow();
                    dr["Value"] = dataResult[0].Value;
                    dr["Data"] = test.Date.ToString("dd.MM.yyyy");
                    dt.Rows.Add(dr);
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
    }
}