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
    public class HeadEvaluationsController : Controller
    {
        private readonly EvaluationSystemContext _context;

        private List<User> users = new List<User>();
        private List<EvaluationCategory> categories = new List<EvaluationCategory>();
        private List<EvaluationRating> ratings = new List<EvaluationRating>();
        private CommentEval comment = new CommentEval();

        public HeadEvaluationsController(EvaluationSystemContext context)
        {
            _context = context;
        }

        // GET: HeadEvaluations
        public async Task<IActionResult> Index()
        {
            var evaluationSystemContext = _context.HeadEvaluation.Include(h => h.Evaluation).Include(h => h.EvaluationDetails);
            return View(await evaluationSystemContext.ToListAsync());
        }

        // GET: HeadEvaluations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HeadEvaluation == null)
            {
                return NotFound();
            }

            var headEvaluation = await _context.HeadEvaluation
                .Include(h => h.Evaluation)
                .Include(h => h.EvaluationDetails)
                .FirstOrDefaultAsync(m => m.HeadEvaluationId == id);
            if (headEvaluation == null)
            {
                return NotFound();
            }

            return View(headEvaluation);
        }

        // GET: HeadEvaluations/Create
        public IActionResult Create()
        {
            ViewData["EvaluationId"] = new SelectList(_context.Evaluation, "EvaluationId", "EvaluationId");
            ViewData["EvaluationDetailsId"] = new SelectList(_context.EvaluationDetails, "EvaluationDetailsId", "EvaluationDetailsId");
            return View();
        }

        // POST: HeadEvaluations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HeadEvaluationId,EvaluationId,EvaluationDetailsId")] HeadEvaluation headEvaluation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(headEvaluation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EvaluationId"] = new SelectList(_context.Evaluation, "EvaluationId", "EvaluationId", headEvaluation.EvaluationId);
            ViewData["EvaluationDetailsId"] = new SelectList(_context.EvaluationDetails, "EvaluationDetailsId", "EvaluationDetailsId", headEvaluation.EvaluationDetailsId);
            return View(headEvaluation);
        }

        // GET: HeadEvaluations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HeadEvaluation == null)
            {
                return NotFound();
            }

            var headEvaluation = await _context.HeadEvaluation.FindAsync(id);
            if (headEvaluation == null)
            {
                return NotFound();
            }
            ViewData["EvaluationId"] = new SelectList(_context.Evaluation, "EvaluationId", "EvaluationId", headEvaluation.EvaluationId);
            ViewData["EvaluationDetailsId"] = new SelectList(_context.EvaluationDetails, "EvaluationDetailsId", "EvaluationDetailsId", headEvaluation.EvaluationDetailsId);
            return View(headEvaluation);
        }

        // POST: HeadEvaluations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HeadEvaluationId,EvaluationId,EvaluationDetailsId")] HeadEvaluation headEvaluation)
        {
            if (id != headEvaluation.HeadEvaluationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(headEvaluation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeadEvaluationExists(headEvaluation.HeadEvaluationId))
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
            ViewData["EvaluationId"] = new SelectList(_context.Evaluation, "EvaluationId", "EvaluationId", headEvaluation.EvaluationId);
            ViewData["EvaluationDetailsId"] = new SelectList(_context.EvaluationDetails, "EvaluationDetailsId", "EvaluationDetailsId", headEvaluation.EvaluationDetailsId);
            return View(headEvaluation);
        }

        // GET: HeadEvaluations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HeadEvaluation == null)
            {
                return NotFound();
            }

            var headEvaluation = await _context.HeadEvaluation
                .Include(h => h.Evaluation)
                .Include(h => h.EvaluationDetails)
                .FirstOrDefaultAsync(m => m.HeadEvaluationId == id);
            if (headEvaluation == null)
            {
                return NotFound();
            }

            return View(headEvaluation);
        }

        // POST: HeadEvaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HeadEvaluation == null)
            {
                return Problem("Entity set 'EvaluationSystemContext.HeadEvaluation'  is null.");
            }
            var headEvaluation = await _context.HeadEvaluation.FindAsync(id);
            if (headEvaluation != null)
            {
                _context.HeadEvaluation.Remove(headEvaluation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeadEvaluationExists(int id)
        {
          return (_context.HeadEvaluation?.Any(e => e.HeadEvaluationId == id)).GetValueOrDefault();
        }
    }
}
