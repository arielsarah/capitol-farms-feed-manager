using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapitolFarmsProject.Models;

namespace CapitolFarmsProject.Controllers
{
    public class HorseController : Controller
    {
        private readonly CapitolFarmsProjectContext _context;

        public HorseController(CapitolFarmsProjectContext context)
        {
            _context = context;
        }

        // GET: Horse
        public async Task<IActionResult> Index()
        {
            var model = await _context.Horse.OrderBy(h => h.HorseName).ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> IndexByLocation()
        {
            var model = await _context.Horse.OrderBy(h => h.Location).ToListAsync();
            return View("Index", model);
        }
        // GET: Horse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horse = await _context.Horse
                .Include(m => m.HorseGrains)
                    .ThenInclude(m => m.Grain)
                .FirstOrDefaultAsync(m => m.HorseId == id);
            if (horse == null)
            {
                return NotFound();
            }

            return View(horse);
        }

        // GET: Horse/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Horse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HorseId,HorseName,Location,Notes,Photo")] Horse horse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(horse);
        }

        // GET: Horse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horse = await _context.Horse.FindAsync(id);
            if (horse == null)
            {
                return NotFound();
            }
            return View(horse);
        }

        // POST: Horse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HorseId,HorseName,Location,Notes,Photo")] Horse horse)
        {
            if (id != horse.HorseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorseExists(horse.HorseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(horse);
        }

        // GET: Horse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horse = await _context.Horse
                .FirstOrDefaultAsync(m => m.HorseId == id);
            if (horse == null)
            {
                return NotFound();
            }

            return View(horse);
        }

        // POST: Horse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horse = await _context.Horse.FindAsync(id);
            _context.Horse.Remove(horse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorseExists(int id)
        {
            return _context.Horse.Any(e => e.HorseId == id);
        }
    }
}
