using DocSystem.DatabaseFiles.Helper;
using DocSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DocSystem.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult AddDescription() {
            return View(); 
        }


        public IActionResult MedicalDescription()
        {
            DateTime date = DateTime.Now;
            MedicalDescription des = new MedicalDescription() { Id = 1, Date = date, Description = "", DoctorId = 1, PatientId = 1, Type = "1" };
            List<MedicalDescription> list = new List<MedicalDescription>();
            list.Add(des);
            return View(list);
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

        public IActionResult DoctorView()
        {
            Patient patient = new Patient() { Id=1, Name="Ola", Surname="jhdhf", Address="jghvgfh", Pesel=6845264};
            DateTime date = DateTime.Now; 
            Visit visit = new Visit() { Date= date, Doctor = "", DoctorName = "11", Id = 1, PatientName = "11", Status = "a", Type = "a" };
            List<Visit> visits = new List<Visit>();
            visits.Add(visit);

            Prescription prescription = new Prescription() { Date = date, Description="",Medicine="", DoctorId = 11, Id = 99, PatientId = 11 };
            List<Prescription> prescriptions = new List<Prescription>();
            prescriptions.Add(prescription);

            Test test = new Test() { Date = date, Description = "",DoctorId = 11, Id = 99, PatientId = 11 };
            List<Test> tests = new List<Test>();
            tests.Add(test);


            Documentation doc = new Documentation() { Date = date, Disease="", DoctorId = 11, Id = 99, PatientId = 11 };
            List<Documentation> docs = new List<Documentation>();
            docs.Add(doc);

            MedicalDescription des = new MedicalDescription() { Id = 1, Date = date, Description = "", DoctorId = 1, PatientId = 1, Type = "1" };
            List<MedicalDescription> list = new List<MedicalDescription>();
            list.Add(des);

            ViewData["data"] = patient;
            ViewData["docs"] = docs;
            ViewData["visits"] = visits;
            ViewData["prescript"] = prescriptions;
            ViewData["tests"] = tests;
            ViewData["medicalDescriptionData"] = list;
            return View();
        }

        public ActionResult DoctorPrescription()
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