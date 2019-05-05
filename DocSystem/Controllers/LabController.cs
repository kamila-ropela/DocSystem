using DocSystem.DatabaseFiles.Helper;
using DocSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DocSystem.Controllers
{
    public class LabController : Controller
    {
        public IActionResult AddResults()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddResults([FromForm]Result result)
        {
            ResultTable.InsertData(result);
            return View();
        }
    }
}