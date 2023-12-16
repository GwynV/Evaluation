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
    public class EvaluationsController : Controller
    {
        private readonly EvaluationSystemContext _context;

        public EvaluationsController(EvaluationSystemContext context)
        {
            _context = context;
        }

        // GET: Evaluations
        public async Task<IActionResult> Index()
        {
            var evaluationSystemContext = _context.Evaluation.Include(e => e.GradingPeriod).Include(e => e.Term).Include(e => e.User);
            return View(await evaluationSystemContext.ToListAsync());
        }

        // GET: Evaluations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Evaluation == null)
            {
                return NotFound();
            }

            var evaluation = await _context.Evaluation
                .Include(e => e.GradingPeriod)
                .Include(e => e.Term)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.EvaluationId == id);
            if (evaluation == null)
            {
                return NotFound();
            }

            return View(evaluation);
        }

        // GET: Evaluations/Create
        public IActionResult Create()
        {
            ViewData["GradingPeriodId"] = new SelectList(_context.GradingPeriod, "GradingPeriodId", "GradingPeriodName");
            ViewData["TermId"] = new SelectList(_context.Term, "TermId", "TermName");
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId");
            return View();
        }

        // POST: Evaluations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EvaluationId,IsActive,UserId,TermId,GradingPeriodId")] Evaluation evaluation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evaluation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GradingPeriodId"] = new SelectList(_context.GradingPeriod, "GradingPeriodId", "GradingPeriodId", evaluation.GradingPeriodId);
            ViewData["TermId"] = new SelectList(_context.Term, "TermId", "TermId", evaluation.TermId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", evaluation.UserId);
            return View(evaluation);
        }

        // GET: Evaluations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Evaluation == null)
            {
                return NotFound();
            }

            var evaluation = await _context.Evaluation.FindAsync(id);
            if (evaluation == null)
            {
                return NotFound();
            }
            ViewData["GradingPeriodId"] = new SelectList(_context.GradingPeriod, "GradingPeriodId", "GradingPeriodId", evaluation.GradingPeriodId);
            ViewData["TermId"] = new SelectList(_context.Term, "TermId", "TermId", evaluation.TermId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", evaluation.UserId);
            return View(evaluation);
        }

        // POST: Evaluations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EvaluationId,IsActive,UserId,TermId,GradingPeriodId")] Evaluation evaluation)
        {
            if (id != evaluation.EvaluationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluationExists(evaluation.EvaluationId))
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
            ViewData["GradingPeriodId"] = new SelectList(_context.GradingPeriod, "GradingPeriodId", "GradingPeriodId", evaluation.GradingPeriodId);
            ViewData["TermId"] = new SelectList(_context.Term, "TermId", "TermId", evaluation.TermId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", evaluation.UserId);
            return View(evaluation);
        }

        // GET: Evaluations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Evaluation == null)
            {
                return NotFound();
            }

            var evaluation = await _context.Evaluation
                .Include(e => e.GradingPeriod)
                .Include(e => e.Term)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.EvaluationId == id);
            if (evaluation == null)
            {
                return NotFound();
            }

            return View(evaluation);
        }

        // POST: Evaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Evaluation == null)
            {
                return Problem("Entity set 'EvaluationSystemContext.Evaluation'  is null.");
            }
            var evaluation = await _context.Evaluation.FindAsync(id);
            if (evaluation != null)
            {
                _context.Evaluation.Remove(evaluation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluationExists(int id)
        {
          return (_context.Evaluation?.Any(e => e.EvaluationId == id)).GetValueOrDefault();
        }
    }
}
