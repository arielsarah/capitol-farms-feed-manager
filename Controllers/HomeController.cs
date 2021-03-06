﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CapitolFarmsProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace CapitolFarmsProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly CapitolFarmsProjectContext _context;

        public HomeController(CapitolFarmsProjectContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "This is the feed management program for Capitol Farms.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact Ariel Tuley for questions regarding this program.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Users()
        {
            ViewData["Message"] = "Master List of Users";

            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Reports()
        {
            ViewData["Title"] = "Combined Report";
            ViewData["Combined Button"] = "active" ; 

            return View(await _context.HorseGrain
                                      .Include(hg => hg.Grain)
                                      .Include(hg => hg.Horse)
                                      .OrderBy(hg => hg.Horse.Location)
                                      .ThenBy(hg => hg.Grain.GrainName)
                                      .GroupBy(keySelector: hg => hg.Horse.Location)
                                      .ToListAsync());
        }

        [AllowAnonymous]
        public async Task<IActionResult> AMReport()
        {
            ViewData["Title"] = "AM Report";
            ViewData["AM Button"] = "active" ;

            return View("Reports", await _context.HorseGrain
                                      .Include(hg => hg.Grain)
                                      .Include(hg => hg.Horse)
                                      .Where(hg => hg.AMReport)
                                      .OrderBy(hg => hg.Horse.Location)
                                      .ThenBy(hg => hg.Grain.GrainName)
                                      .GroupBy(keySelector: hg => hg.Horse.Location)
                                      .ToListAsync());
        }

        [AllowAnonymous]
        public async Task<IActionResult> PMReport()
        {
            ViewData["Title"] = "PM Report";
            ViewData["PM Button"] = "active" ;

            return View("Reports", await _context.HorseGrain
                                      .Include(hg => hg.Grain)
                                      .Include(hg => hg.Horse)
                                      .Where(hg => hg.PMReport)
                                      .OrderBy(hg => hg.Horse.Location)
                                      .ThenBy(hg => hg.Grain.GrainName)
                                      .GroupBy(keySelector: hg => hg.Horse.Location)
                                      .ToListAsync());
        }
    }
}
