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
    public class HorseGrainController : Controller
    {
        private readonly CapitolFarmsProjectContext _context;

        public HorseGrainController(CapitolFarmsProjectContext context)
        {
            _context = context;
        }

        // GET: HorseGrain
        public async Task<IActionResult> Index()
        {
            return View(await _context.HorseGrain.Include(hg => hg.Grain).Include(hg => hg.Horse).ToListAsync());
        }

        // GET: HorseGrain/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horseGrain = await _context.HorseGrain
                .FirstOrDefaultAsync(m => m.HorseGrainId == id);
            if (horseGrain == null)
            {
                return NotFound();
            }

            return View(horseGrain);
        }

        // GET: HorseGrain/Create
        public IActionResult Create()
        {
            

            return View(new HorseGrainViewModel(_context));
        }

        // POST: HorseGrain/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HorseGrainId,Amount,AMReport,PMReport,HorseId,GrainId")] HorseGrain horseGrain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horseGrain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(horseGrain);
        }

        // GET: HorseGrain/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horseGrain = await _context.HorseGrain.FindAsync(id);
            if (horseGrain == null)
            {
                return NotFound();
            }
            return View(new HorseGrainViewModel(_context, horseGrain));
        }

        // POST: HorseGrain/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HorseGrainId,Amount,AMReport,PMReport,HorseId,GrainId")] HorseGrain horseGrain)
        {
            if (id != horseGrain.HorseGrainId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horseGrain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorseGrainExists(horseGrain.HorseGrainId))
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
            return View(horseGrain);
        }

        // GET: HorseGrain/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horseGrain = await _context.HorseGrain
                .FirstOrDefaultAsync(m => m.HorseGrainId == id);
            if (horseGrain == null)
            {
                return NotFound();
            }

            return View(horseGrain);
        }

        // POST: HorseGrain/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horseGrain = await _context.HorseGrain.FindAsync(id);
            _context.HorseGrain.Remove(horseGrain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorseGrainExists(int id)
        {
            return _context.HorseGrain.Any(e => e.HorseGrainId == id);
        }
    }
}
