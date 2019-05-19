using DocSystem.DatabaseFiles.Helper;
using DocSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public ActionResult AddResults(IFormCollection result)
        {
            Result res = new Result();
            res.TestId = Convert.ToInt32(result["TestId"]);

            IList<string> names;
            names = result["Name"];
            IList<string> units;
            units = result["Unit"];
            IList<string> values;
            values = result["Value"];
            for(int i = 0; i < names.Count; i++) {
                if (names[i] == "")
                    break;
                res.Name = names[i];
                res.Unit = units[i];
                res.Value = Convert.ToDouble(values[i]);
                ResultTable.InsertData(res);
            }
            
            return View();
        }
    }
}