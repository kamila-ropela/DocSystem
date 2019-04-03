using Microsoft.AspNetCore.Mvc;

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
    }
}