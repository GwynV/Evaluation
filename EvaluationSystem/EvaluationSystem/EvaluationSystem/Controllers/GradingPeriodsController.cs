using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvaluationSystem.Data;
using EvaluationSystem.Models;

namespace EvaluationSystem.Controllers
{
    public class GradingPeriodsController : Controller
    {
        private readonly EvaluationSystemContext _context;

        public GradingPeriodsController(EvaluationSystemContext context)
        {
            _context = context;
        }

        // GET: GradingPeriods
        public async Task<IActionResult> Index()
        {
              return _context.GradingPeriod != null ? 
                          View(await _context.GradingPeriod.ToListAsync()) :
                          Problem("Entity set 'EvaluationSystemContext.GradingPeriod'  is null.");
        }

        // GET: GradingPeriods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GradingPeriod == null)
            {
                return NotFound();
            }

            var gradingPeriod = await _context.GradingPeriod
                .FirstOrDefaultAsync(m => m.GradingPeriodId == id);
            if (gradingPeriod == null)
            {
                return NotFound();
            }

            return View(gradingPeriod);
        }

        // GET: GradingPeriods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GradingPeriods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GradingPeriodId,GradingPeriodName")] GradingPeriod gradingPeriod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gradingPeriod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gradingPeriod);
        }

        // GET: GradingPeriods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GradingPeriod == null)
            {
                return NotFound();
            }

            var gradingPeriod = await _context.GradingPeriod.FindAsync(id);
            if (gradingPeriod == null)
            {
                return NotFound();
            }
            return View(gradingPeriod);
        }

        // POST: GradingPeriods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GradingPeriodId,GradingPeriodName")] GradingPeriod gradingPeriod)
        {
            if (id != gradingPeriod.GradingPeriodId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gradingPeriod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradingPeriodExists(gradingPeriod.GradingPeriodId))
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
            return View(gradingPeriod);
        }

        // GET: GradingPeriods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GradingPeriod == null)
            {
                return NotFound();
            }

            var gradingPeriod = await _context.GradingPeriod
                .FirstOrDefaultAsync(m => m.GradingPeriodId == id);
            if (gradingPeriod == null)
            {
                return NotFound();
            }

            return View(gradingPeriod);
        }

        // POST: GradingPeriods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GradingPeriod == null)
            {
                return Problem("Entity set 'EvaluationSystemContext.GradingPeriod'  is null.");
            }
            var gradingPeriod = await _context.GradingPeriod.FindAsync(id);
            if (gradingPeriod != null)
            {
                _context.GradingPeriod.Remove(gradingPeriod);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradingPeriodExists(int id)
        {
          return (_context.GradingPeriod?.Any(e => e.GradingPeriodId == id)).GetValueOrDefault();
        }
    }
}
