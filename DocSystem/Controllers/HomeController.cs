using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DocSystem.Models;
using DocSystem.DatabaseFiles;

namespace DocSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Properties.dbContext = HttpContext.RequestServices.GetService(typeof(DbContext)) as DbContext;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
