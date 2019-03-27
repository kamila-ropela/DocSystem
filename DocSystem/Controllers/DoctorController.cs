using DocSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DocSystem.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult DoctorView()
        {
            Patient patient = new Patient() { Id=1, Name="Ola", Surname="jhdhf", Address="jghvgfh", Pesel=6845264};
            DateTime date = DateTime.Now; 
            Visit visit = new Visit() { Date= date, Doctor = "", DoctorId = 11, Id = 99, PatientId = 11, Status = "a", Type = "a" };
            List<Visit> visits = new List<Visit>();
            visits.Add(visit);

            Prescription prescription = new Prescription() { Date = date, Description="",Medicine="", DoctorId = 11, Id = 99, PatientId = 11 };
            List<Prescription> prescriptions = new List<Prescription>();
            prescriptions.Add(prescription);

            Test test = new Test() { Date = date, Description = "", Type="",Value="" ,DoctorId = 11, Id = 99, PatientId = 11 };
            List<Test> tests = new List<Test>();
            tests.Add(test);


            Documentation doc = new Documentation() { Date = date, Disease="", DoctorId = 11, Id = 99, PatientId = 11 };
            List<Documentation> docs = new List<Documentation>();
            docs.Add(doc);

            ViewData["data"] = patient;
            ViewData["docs"] = docs;
            ViewData["visits"] = visits;
            ViewData["prescript"] = prescriptions;
            ViewData["tests"] = tests; 
            return View();
        }
    }
}