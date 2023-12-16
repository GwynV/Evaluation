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
    public class EvaluationDetailsController : Controller
    {
        private readonly EvaluationSystemContext _context;

        public EvaluationDetailsController(EvaluationSystemContext context)
        {
            _context = context;
        }

        // GET: EvaluationDetails
        public async Task<IActionResult> Index()
        {
            var evaluationSystemContext = _context.EvaluationDetails.Include(e => e.EvaluationCategory).Include(e => e.EvaluationRating);
            return View(await evaluationSystemContext.ToListAsync());
        }

        // GET: EvaluationDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EvaluationDetails == null)
            {
                return NotFound();
            }

            var evaluationDetails = await _context.EvaluationDetails
                .Include(e => e.EvaluationCategory)
                .Include(e => e.EvaluationRating)
                .FirstOrDefaultAsync(m => m.EvaluationDetailsId == id);
            if (evaluationDetails == null)
            {
                return NotFound();
            }

            return View(evaluationDetails);
        }

        // GET: EvaluationDetails/Create
        public IActionResult Create()
        {

            ViewData["EvaluationCategoryId"] = new SelectList(_context.EvaluationCategory, "EvaluationId", "EvaluationCategoryName");
            ViewData["EvaluationRatingId"] = new SelectList(_context.EvaluationRating, "EvaluationRatingId", "EvaluationRatingId");
            return View();
        }

        // POST: EvaluationDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EvaluationDetailsId,EvaluationRatingId,EvaluationCategoryId")] EvaluationDetails evaluationDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evaluationDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EvaluationCategoryId"] = new SelectList(_context.EvaluationCategory, "EvaluationId", "EvaluationId", evaluationDetails.EvaluationCategoryId);
            ViewData["EvaluationRatingId"] = new SelectList(_context.EvaluationRating, "EvaluationRatingId", "EvaluationRatingId", evaluationDetails.EvaluationRatingId);
            return View(evaluationDetails);
        }

        // GET: EvaluationDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EvaluationDetails == null)
            {
                return NotFound();
            }

            var evaluationDetails = await _context.EvaluationDetails.FindAsync(id);
            if (evaluationDetails == null)
            {
                return NotFound();
            }
            ViewData["EvaluationCategoryId"] = new SelectList(_context.EvaluationCategory, "EvaluationId", "EvaluationId", evaluationDetails.EvaluationCategoryId);
            ViewData["EvaluationRatingId"] = new SelectList(_context.EvaluationRating, "EvaluationRatingId", "EvaluationRatingId", evaluationDetails.EvaluationRatingId);
            return View(evaluationDetails);
        }

        // POST: EvaluationDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EvaluationDetailsId,EvaluationRatingId,EvaluationCategoryId")] EvaluationDetails evaluationDetails)
        {
            if (id != evaluationDetails.EvaluationDetailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluationDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluationDetailsExists(evaluationDetails.EvaluationDetailsId))
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
            ViewData["EvaluationCategoryId"] = new SelectList(_context.EvaluationCategory, "EvaluationId", "EvaluationId", evaluationDetails.EvaluationCategoryId);
            ViewData["EvaluationRatingId"] = new SelectList(_context.EvaluationRating, "EvaluationRatingId", "EvaluationRatingId", evaluationDetails.EvaluationRatingId);
            return View(evaluationDetails);
        }

        // GET: EvaluationDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EvaluationDetails == null)
            {
                return NotFound();
            }

            var evaluationDetails = await _context.EvaluationDetails
                .Include(e => e.EvaluationCategory)
                .Include(e => e.EvaluationRating)
                .FirstOrDefaultAsync(m => m.EvaluationDetailsId == id);
            if (evaluationDetails == null)
            {
                return NotFound();
            }

            return View(evaluationDetails);
        }

        // POST: EvaluationDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EvaluationDetails == null)
            {
                return Problem("Entity set 'EvaluationSystemContext.EvaluationDetails'  is null.");
            }
            var evaluationDetails = await _context.EvaluationDetails.FindAsync(id);
            if (evaluationDetails != null)
            {
                _context.EvaluationDetails.Remove(evaluationDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluationDetailsExists(int id)
        {
          return (_context.EvaluationDetails?.Any(e => e.EvaluationDetailsId == id)).GetValueOrDefault();
        }
    }
}
