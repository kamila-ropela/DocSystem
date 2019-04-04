using Microsoft.AspNetCore.Mvc;

namespace DocSystem.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult DoctorView()
        {
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



    }
}