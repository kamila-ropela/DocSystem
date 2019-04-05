using Microsoft.AspNetCore.Mvc;
using DocSystem.DatabaseFiles.Helper;

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
        public ActionResult PatientInfo()
        {
            ViewData["sickLeaveData"] = SickLeaveTable.GetData(); ;
            ViewData["prescriptioneData"] = PrescriptionTable.GetData();
            ViewData["visitData"] = VisitTable.GetData();
        }
    }
}