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
    public class CommentEvalsController : Controller
    {
        private readonly EvaluationSystemContext _context;

        public CommentEvalsController(EvaluationSystemContext context)
        {
            _context = context;
        }

        // GET: CommentEvals
        public async Task<IActionResult> Index()
        {
            var evaluationSystemContext = _context.CommentEval.Include(c => c.Evaluation);
            return View(await evaluationSystemContext.ToListAsync());
        }

        // GET: CommentEvals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CommentEval == null)
            {
                return NotFound();
            }

            var commentEval = await _context.CommentEval
                .Include(c => c.Evaluation)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (commentEval == null)
            {
                return NotFound();
            }

            return View(commentEval);
        }

        // GET: CommentEvals/Create
        public IActionResult Create()
        {
            ViewData["EvaluationId"] = new SelectList(_context.Evaluation, "EvaluationId", "EvaluationId");
            return View();
        }

        // POST: CommentEvals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,EvaluationComment,CommentedById,EvaluationId")] CommentEval commentEval)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commentEval);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EvaluationId"] = new SelectList(_context.Evaluation, "EvaluationId", "EvaluationId", commentEval.EvaluationId);
            return View(commentEval);
        }

        // GET: CommentEvals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CommentEval == null)
            {
                return NotFound();
            }

            var commentEval = await _context.CommentEval.FindAsync(id);
            if (commentEval == null)
            {
                return NotFound();
            }
            ViewData["EvaluationId"] = new SelectList(_context.Evaluation, "EvaluationId", "EvaluationId", commentEval.EvaluationId);
            return View(commentEval);
        }

        // POST: CommentEvals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentId,EvaluationComment,CommentedById,EvaluationId")] CommentEval commentEval)
        {
            if (id != commentEval.CommentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commentEval);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentEvalExists(commentEval.CommentId))
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
            ViewData["EvaluationId"] = new SelectList(_context.Evaluation, "EvaluationId", "EvaluationId", commentEval.EvaluationId);
            return View(commentEval);
        }

        // GET: CommentEvals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CommentEval == null)
            {
                return NotFound();
            }

            var commentEval = await _context.CommentEval
                .Include(c => c.Evaluation)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (commentEval == null)
            {
                return NotFound();
            }

            return View(commentEval);
        }

        // POST: CommentEvals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CommentEval == null)
            {
                return Problem("Entity set 'EvaluationSystemContext.CommentEval'  is null.");
            }
            var commentEval = await _context.CommentEval.FindAsync(id);
            if (commentEval != null)
            {
                _context.CommentEval.Remove(commentEval);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentEvalExists(int id)
        {
          return (_context.CommentEval?.Any(e => e.CommentId == id)).GetValueOrDefault();
        }
    }
}
