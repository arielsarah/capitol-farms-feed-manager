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
    public class GrainController : Controller
    {
        private readonly CapitolFarmsProjectContext _context;

        public GrainController(CapitolFarmsProjectContext context)
        {
            _context = context;
        }

        // GET: Grain
        public async Task<IActionResult> Index()
        {
            return View(await _context.Grain.ToListAsync());
        }

        // GET: Grain/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grain = await _context.Grain
                .FirstOrDefaultAsync(m => m.GrainId == id);
            if (grain == null)
            {
                return NotFound();
            }

            return View(grain);
        }

        // GET: Grain/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grain/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GrainId,GrainName")] Grain grain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grain);
        }

        // GET: Grain/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grain = await _context.Grain.FindAsync(id);
            if (grain == null)
            {
                return NotFound();
            }
            return View(grain);
        }

        // POST: Grain/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GrainId,GrainName")] Grain grain)
        {
            if (id != grain.GrainId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrainExists(grain.GrainId))
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
            return View(grain);
        }

        // GET: Grain/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grain = await _context.Grain
                .FirstOrDefaultAsync(m => m.GrainId == id);
            if (grain == null)
            {
                return NotFound();
            }

            return View(grain);
        }

        // POST: Grain/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grain = await _context.Grain.FindAsync(id);
            _context.Grain.Remove(grain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrainExists(int id)
        {
            return _context.Grain.Any(e => e.GrainId == id);
        }
    }
}
