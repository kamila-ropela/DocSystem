using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Patients.Controllers
{
    public class PatientController : Controller
    {
        
        public ActionResult PatientView()
        {
            return View();
        }
    }
}