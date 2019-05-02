using DocSystem.DatabaseFiles.Helper;
using DocSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DocSystem.Controllers
{
    public class DoctorController : Controller
    {


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


        public ActionResult DoctorVisit()
        {
            return View();
        }

        public ActionResult DoctorSickLeave()
        {
            return View();
        }

        public ActionResult AddDocumentationView()
        {
            return View();
        }

        public IActionResult Results(int id)
        {
            DateTime date = DateTime.Now;
            Result res = new Result { Id = 1, Name = "", TestId = 111, Unit = "mm", Value = 100 };
            List<Result> list = new List<Result>();
            list.Add(res);
            return View(list);
        }
    }
}