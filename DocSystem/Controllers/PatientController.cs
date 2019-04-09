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

        public ActionResult PatientInfo()
        {
            ViewData["sickLeaveData"] = SickLeaveTable.GetData(); ;
            ViewData["prescriptioneData"] = PrescriptionTable.GetData();
            ViewData["visitData"] = VisitTable.GetData();
            return View(); 
        }
    }
}