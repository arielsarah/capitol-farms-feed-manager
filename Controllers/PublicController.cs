using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CapitolFarmsProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace CapitolFarmsProject.Controllers
{
    public class PublicController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        

        
    }
}
