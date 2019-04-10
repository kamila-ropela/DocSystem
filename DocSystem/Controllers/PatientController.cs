using Microsoft.AspNetCore.Mvc;
using DocSystem.DatabaseFiles.Helper;
using System;
using DocSystem.Models;
using System.Collections.Generic;

namespace Patients.Controllers
{
    public class PatientController : Controller
    {
        public ActionResult PatientView()
        {
            ViewData["PatientName"] = new Patient() { Id = 2, Name = "Hania", Surname = "fgf", Pesel = 787879, Address = "Gdansk" };

            ViewData["medicalDescription"] = new List<MedicalDescription>() { new MedicalDescription { Date = DateTime.Now, PatientId = 9, DoctorId = 9, Description= "", Type="", Id=0 } };
            ViewData["documentation"] = new List<Documentation>() {new Documentation{ Id = 0, DoctorId = 0, PatientId = 9, Disease="", Date = DateTime.Now}};
            ViewData["Tests"] = new List<Test>() { new Test{ Id=9, DoctorId=0, PatientId=9, Date = DateTime.Now, Description=""} };

            ViewData["sickLeaveData"] = SickLeaveTable.GetData(); ;
            ViewData["prescriptioneData"] = PrescriptionTable.GetData();
            ViewData["visitData"] = VisitTable.GetData();
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
            Test test = new Test { Id = 1, Date = date, Description = "", DoctorId = 1, PatientId = 1};
            List<Test> list = new List<Test>();
            list.Add(test);
            return View(list);
        }

        public IActionResult Results(int id)
        {
            DateTime date = DateTime.Now;
            Result res = new Result { Id = 1, Name="",TestId=111, Unit="mm",Value=100};
            List<Result> list = new List<Result>();
            list.Add(res);
            return View(list);
        }
    }
}