﻿using Microsoft.AspNetCore.Mvc;

namespace DocSystem.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult DoctorView()
        {
            return View();
        }
    }
}