﻿using MetroMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MetroMvc.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
