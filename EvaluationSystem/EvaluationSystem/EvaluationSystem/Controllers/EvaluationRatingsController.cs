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
    public class EvaluationRatingsController : Controller
    {
        private readonly EvaluationSystemContext _context;

        public EvaluationRatingsController(EvaluationSystemContext context)
        {
            _context = context;
        }

        // GET: EvaluationRatings
        public async Task<IActionResult> Index()
        {
              return _context.EvaluationRating != null ? 
                          View(await _context.EvaluationRating.ToListAsync()) :
                          Problem("Entity set 'EvaluationSystemContext.EvaluationRating'  is null.");
        }

        // GET: EvaluationRatings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EvaluationRating == null)
            {
                return NotFound();
            }

            var evaluationRating = await _context.EvaluationRating
                .FirstOrDefaultAsync(m => m.EvaluationRatingId == id);
            if (evaluationRating == null)
            {
                return NotFound();
            }

            return View(evaluationRating);
        }

        // GET: EvaluationRatings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EvaluationRatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EvaluationRatingId,EvaluationRatingName,IsActive,EvaluationScore")] EvaluationRating evaluationRating)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evaluationRating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(evaluationRating);
        }

        // GET: EvaluationRatings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EvaluationRating == null)
            {
                return NotFound();
            }

            var evaluationRating = await _context.EvaluationRating.FindAsync(id);
            if (evaluationRating == null)
            {
                return NotFound();
            }
            return View(evaluationRating);
        }

        // POST: EvaluationRatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EvaluationRatingId,EvaluationRatingName,IsActive,EvaluationScore")] EvaluationRating evaluationRating)
        {
            if (id != evaluationRating.EvaluationRatingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluationRating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluationRatingExists(evaluationRating.EvaluationRatingId))
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
            return View(evaluationRating);
        }

        // GET: EvaluationRatings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EvaluationRating == null)
            {
                return NotFound();
            }

            var evaluationRating = await _context.EvaluationRating
                .FirstOrDefaultAsync(m => m.EvaluationRatingId == id);
            if (evaluationRating == null)
            {
                return NotFound();
            }

            return View(evaluationRating);
        }

        // POST: EvaluationRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EvaluationRating == null)
            {
                return Problem("Entity set 'EvaluationSystemContext.EvaluationRating'  is null.");
            }
            var evaluationRating = await _context.EvaluationRating.FindAsync(id);
            if (evaluationRating != null)
            {
                _context.EvaluationRating.Remove(evaluationRating);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluationRatingExists(int id)
        {
          return (_context.EvaluationRating?.Any(e => e.EvaluationRatingId == id)).GetValueOrDefault();
        }
    }
}
