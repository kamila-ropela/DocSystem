using DocSystem.DatabaseFiles.Helper;
using DocSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Data;
using System.Linq;
using DocSystem.DatabaseFiles;
using SelectPdf;
using Microsoft.AspNetCore.Http;

namespace DocSystem.Controllers
{
    public class DoctorController : Controller
    {
        public static int patientId;
        public static string nameOfTest;

        [HttpPost]
        public ActionResult AddDescription([FromForm] MedicalDescription model)
        {
            String des = model.Description;
            if (des.Length>0) {
                DateTime time = DateTime.Now.Date;
                string date = time.ToString("yyyy-MM-dd");
                MedicalDescriptionTable.AddDescription(Properties.UserId, patientId, model.Type, model.Description, date);
            }

            return RedirectToAction("Visit", "Doctor", new { id = Properties.VisitId });
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
                } else return RedirectToAction("DoctorView", "Doctor", patient[0] );
            }
            catch {
                return View();
            }
        }


        public IActionResult AddDescription(int id) {
            ViewBag.var = id; 


            var data = VisitTable.GetDataById(id);
            var patients = PatientTable.GetPatientById(patientId);

            ViewData["patient"] = patients[0];
            ViewData["visit"] = data[0]; 
            return View(); 
        }
    
        public IActionResult AddDocumentationView(int id)
        {
            ViewBag.var = id;

            var patients = PatientTable.GetPatientById(patientId);

            ViewData["patient"] = patients[0];
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDocumentationView([FromForm]Documentation documentation)
        {
            DateTime time = DateTime.Now.Date;
            string date = time.ToString("yyyy-MM-dd");
            DocumentationTable.InsertData(Properties.UserId,patientId, documentation, date);
            return RedirectToAction("Visit", "Doctor", new { id = Properties.VisitId });
        }


        public IActionResult MedicalDescription(int id)
        {
            return View();
        }

        public IActionResult Visit(int id)
        {
            ViewBag.var = id;
            ViewBag.patient = Properties.patient;
            Properties.VisitId = id;

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
            Properties.patient = patient;

            var doctorSpecialization = DoctorTable.GetSpecializationById(Properties.UserId);
            if (patient.Name == null)
                patient.Id = 100;

            List<Visit> visits = VisitTable.GetDataByPatientIdAndSpecialization(patient.Id, doctorSpecialization[0].Specialization);
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

            ViewBag.var = id;
            var patients = PatientTable.GetPatientById(patientId);

            ViewData["patient"] = patients[0];

            return View();       
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoctorPrescription([FromForm] Prescription presc)
        {
            var patients = PatientTable.GetPatientById(patientId);

            DateTime time = DateTime.Now.Date;
            string date = time.ToString("yyyy-MM-dd");
            PrescriptionTable.InsertData( patients[0].Id, Properties.UserId, presc.Medicine, presc.Description, date, presc.Refund);
            return RedirectToAction("Visit", "Doctor", new { id = Properties.VisitId });

        }
        public IActionResult DoctorVisit(int id)
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoctorVisit([FromForm]Visit visits)
        {

            var patients = PatientTable.GetPatientById(patientId);

            DateTime time = DateTime.Now.Date;
            string date = time.ToString("yyyy-MM-dd");
            if (visits.Type == "visit")
                visits.Status = "in progress";
            else if (visits.Type == "referral")
                visits.Status = "pending";
            else if (visits.Type == "test")
            {
                TestTable.InsertData( patientId, Properties.UserId, "", date); 
                visits.Status = "pending";
            }

            VisitTable.InsertD(patients[0].Id, Properties.UserId, visits.Type, visits.Doctor, visits.Status, date);

            return RedirectToAction("DoctorView", "Doctor", PatientTable.GetPatientById(patientId)[0]);


        }

        public ActionResult DoctorSickLeave(int id)
        {

            ViewBag.var = id;
            var patients = PatientTable.GetPatientById(patientId);

            ViewData["patient"] = patients[0];

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoctorSickLeave([FromForm]SickLeave sl)
        {
            var patients = PatientTable.GetPatientById(patientId);
            DateTime time = DateTime.Now.Date;
            string date = time.ToString("yyyy-MM-dd");
            SickLeaveTable.InsertD(patients[0].Id, Properties.UserId, sl.Days, sl.Description, date);

            return RedirectToAction("Visit", "Doctor", new { id = Properties.VisitId });


        }


      
        public IActionResult Results(int id)
        {
            ViewBag.var = id;

            IEnumerable<Result> data = ResultTable.GetDataByTestId(id);

            return View(data);
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