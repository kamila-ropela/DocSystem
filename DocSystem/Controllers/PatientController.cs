using Microsoft.AspNetCore.Mvc;
using DocSystem.DatabaseFiles.Helper;
using System;
using DocSystem.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DocSystem.DatabaseFiles;
using System.Text.RegularExpressions;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using SelectPdf;
using System.Dynamic;

namespace Patients.Controllers
{
    public class PatientController : Controller
    {
        public static string nameOfTest;

        public IActionResult Visit(int id)
        {
            ViewBag.var = id;

            var data = VisitTable.GetDataById(id);

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

        [HttpPost]
        public ActionResult SubmitAction(IFormCollection collection)
        {
         
            HtmlToPdf converter = new HtmlToPdf();
           
            PdfDocument doc = converter.ConvertUrl(collection["TxtUrl"]);
            byte[] pdf = doc.Save();
            doc.Close();

            FileResult fileResult = new FileContentResult(pdf, "application/pdf");
            fileResult.FileDownloadName = "Document.pdf";
            return fileResult;
          
        }

        [HttpPost]
        public ActionResult PatientView([FromForm]string searchString)
        {

            try
            {
                if (Regex.IsMatch(searchString, @"^[a-zA-Z]+$"))
                {
                    List<Doctor> doctor = DoctorTable.GetDoctorIdBySurname(searchString);
                    if (doctor.Count != 0)
                    {
                        int doctorId = doctor[0].Id;

                        var visit = VisitTable.GetDataByDoctorId(doctorId, Properties.UserId);
                        var prescript = PrescriptionTable.GetDataByDoctorId(doctorId, Properties.UserId);
                        var test = TestTable.GetDataByDoctorId(doctorId, Properties.UserId);
                        var sickleave = SickLeaveTable.GetDataByDoctorId(doctorId, Properties.UserId);
                        var description = MedicalDescriptionTable.GetDataByDoctorId(doctorId, Properties.UserId);
                        var doc = DocumentationTable.GetDataByDoctorId(doctorId, Properties.UserId);

                        ViewData["PatientName"] = PatientTable.GetPatientById(Properties.UserId)[0];
                        ViewData["visitData"] = visit;
                        ViewData["prescriptioneData"] = prescript;
                        ViewData["Tests"] = test;
                        ViewData["sickLeaveData"] = sickleave;
                        ViewData["medicalDescription"] = description;
                        ViewData["documentation"] = doc;
                        return View();
                    }
                    else
                    {
                        ViewData["PatientName"] = PatientTable.GetPatientById(Properties.UserId)[0];
                        ViewData["visitData"] = new List<Visit>();
                        ViewData["prescriptioneData"] = new List<Prescription>();
                        ViewData["Tests"] = new List<Test>();
                        ViewData["sickLeaveData"] = new List<SickLeave>();
                        ViewData["medicalDescription"] = new List<MedicalDescription>();
                        ViewData["documentation"] = new List<Documentation>();

                        var prescript = PrescriptionTable.GetPrescriptByMedicine(searchString);
                        if (prescript.Count != 0) {
                            ViewData["prescriptioneData"] = prescript;
                        }

                        var des = MedicalDescriptionTable.GetData(Properties.UserId, searchString);
                        if (des.Count != 0)
                        {
                            ViewData["medicalDescription"] = des;
                        }

                        View(); 
                    }
                }
                return View(); 
            }
            catch
            {
                return View();
            }
        }

        public ActionResult PatientView(Patient patient)

        {
            var patients = PatientTable.GetPatientById(Properties.UserId);
            var description = MedicalDescriptionTable.GetDataByPatientId(Properties.UserId);
            var visit = VisitTable.GetDataByPatientId(Properties.UserId);
            var prescript = PrescriptionTable.GetData(Properties.UserId);
            var test = TestTable.GetData(Properties.UserId);
            var leavesick = SickLeaveTable.GetDataByPatientId(Properties.UserId);
            var doc = DocumentationTable.GetDataByPatientId(Properties.UserId);

            //  ViewData["PatientName"] = PatientTable.GetPatientById(patient.Id);
            ViewData["PatientName"] = patients[0];
            ViewData["visitData"] = visit;
            ViewData["prescriptioneData"] = prescript;
            ViewData["Tests"] = test;
            ViewData["sickLeaveData"] = leavesick;
            ViewData["medicalDescription"] = description;
            ViewData["documentation"] = doc;
         
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

        public ActionResult PatientTests(int id)
        {
            ViewBag.var = id;

            var data = TestTable.GetDataByPatientId(id);

            return View(data[0]);
        }

        public IActionResult Results(int id)
        {
            ViewBag.var = id;

            IEnumerable<Result> data = ResultTable.GetDataByTestId(id);

            return View(data);
        }

        public IActionResult Prescription(int id)
        {
            ViewBag.var = id;

            var data = PrescriptionTable.GetDataById(id);

            return View(data[0]);
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
        public IActionResult SickLeave(int id, int patientId)
        {
            ViewBag.id = id;
            ViewBag.patientId = patientId;

            var data = SickLeaveTable.GetData(id);
            var patientData = PatientTable.GetPatientById(patientId);

            ViewData["PatientName"] = patientData[0];
            return View(data[0]);
        }
        public ActionResult Course(int id)
        {
            List<Visit> visitList = new List<Visit>();
            List<Test> testList = new List<Test>();
            List<Visit> tmpV = new List<Visit>();
            List<Test> tmpT = new List<Test>();
            visitList.AddRange(VisitTable.GetDataByPatientId(Properties.UserId));
            testList.AddRange(TestTable.GetDataByPatientId(Properties.UserId));
            dynamic output = new ExpandoObject();

            id--;
            Visit currentVisit = new Visit();
            currentVisit = visitList[id];
            visitList.RemoveRange(0,id);
            
            
            foreach(Visit v in visitList)
            {
                if (currentVisit.DoctorName == v.DoctorName && DateTime.Compare(currentVisit.Date, v.Date) <= 0)
                {
                    try
                    {
                        foreach (Test t in testList)
                        {
                            if (currentVisit.DoctorName == t.DoctorName && DateTime.Compare(currentVisit.Date, t.Date) <= 0)
                            {
                                tmpT.Add(t);
                                testList.Remove(t);
                                break;
                            }
                        }
                    }
                    catch { }
                    currentVisit = v;
                    tmpV.Add(v);
                }  
            }
            output.Visit = tmpV;
            output.Test = tmpT;
            return View(output);
        }
    }
}