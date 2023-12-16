using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvaluationSystem.Data;
using EvaluationSystem.Models;
using EvaluationSystem.ViewModels;

namespace EvaluationSystem.Controllers
{
    public class PeerEvaluationsController : Controller
    {
        private readonly EvaluationSystemContext _context;

        private List<User> users = new List<User>();
        private List<EvaluationCategory> categories = new List<EvaluationCategory>();
        private List<EvaluationRating> ratings = new List<EvaluationRating>();
        private CommentEval comment = new CommentEval();

        public PeerEvaluationsController(EvaluationSystemContext context)
        {
            _context = context;
        }

        // GET: PeerEvaluations
        public async Task<IActionResult> Index()
        {
            PeerVM vm = new PeerVM();
            vm.Users = users;
            vm.Categories = categories;
            vm.Rating = ratings;
            vm.Comment = comment;
            var evaluationSystemContext = _context.PeerEvaluation.Include(p => p.Evaluation).Include(p => p.EvaluationDetails);
            return View(vm);
        }

        // GET: PeerEvaluations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PeerEvaluation == null)
            {
                return NotFound();
            }

            var peerEvaluation = await _context.PeerEvaluation
                .Include(p => p.Evaluation)
                .Include(p => p.EvaluationDetails)
                .FirstOrDefaultAsync(m => m.PeerEvaluationId == id);
            if (peerEvaluation == null)
            {
                return NotFound();
            }

            return View(peerEvaluation);
        }

        // GET: PeerEvaluations/Create
        public IActionResult Create()
        {
            ViewData["EvaluationId"] = new SelectList(_context.Evaluation, "EvaluationId", "EvaluationId");
            ViewData["EvaluationDetailsId"] = new SelectList(_context.EvaluationDetails, "EvaluationDetailsId", "EvaluationDetailsId");
            return View();
        }

        // POST: PeerEvaluations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PeerEvaluationId,EvaluationId,EvaluationDetailsId")] PeerEvaluation peerEvaluation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peerEvaluation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["EvaluationId"] = new SelectList(_context.Evaluation, "EvaluationId", "EvaluationId", peerEvaluation.EvaluationId);
            ViewData["EvaluationDetailsId"] = new SelectList(_context.EvaluationDetails, "EvaluationDetailsId", "EvaluationDetailsId", peerEvaluation.EvaluationDetailsId);
            return View(peerEvaluation);
        }

        // GET: PeerEvaluations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PeerEvaluation == null)
            {
                return NotFound();
            }

            var peerEvaluation = await _context.PeerEvaluation.FindAsync(id);
            if (peerEvaluation == null)
            {
                return NotFound();
            }
            ViewData["EvaluationId"] = new SelectList(_context.Evaluation, "EvaluationId", "EvaluationId", peerEvaluation.EvaluationId);
            ViewData["EvaluationDetailsId"] = new SelectList(_context.EvaluationDetails, "EvaluationDetailsId", "EvaluationDetailsId", peerEvaluation.EvaluationDetailsId);
            return View(peerEvaluation);
        }

        // POST: PeerEvaluations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PeerEvaluationId,EvaluationId,EvaluationDetailsId")] PeerEvaluation peerEvaluation)
        {
            if (id != peerEvaluation.PeerEvaluationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peerEvaluation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeerEvaluationExists(peerEvaluation.PeerEvaluationId))
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
            ViewData["EvaluationId"] = new SelectList(_context.Evaluation, "EvaluationId", "EvaluationId", peerEvaluation.EvaluationId);
            ViewData["EvaluationDetailsId"] = new SelectList(_context.EvaluationDetails, "EvaluationDetailsId", "EvaluationDetailsId", peerEvaluation.EvaluationDetailsId);
            return View(peerEvaluation);
        }

        // GET: PeerEvaluations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PeerEvaluation == null)
            {
                return NotFound();
            }

            var peerEvaluation = await _context.PeerEvaluation
                .Include(p => p.Evaluation)
                .Include(p => p.EvaluationDetails)
                .FirstOrDefaultAsync(m => m.PeerEvaluationId == id);
            if (peerEvaluation == null)
            {
                return NotFound();
            }

            return View(peerEvaluation);
        }

        // POST: PeerEvaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PeerEvaluation == null)
            {
                return Problem("Entity set 'EvaluationSystemContext.PeerEvaluation'  is null.");
            }
            var peerEvaluation = await _context.PeerEvaluation.FindAsync(id);
            if (peerEvaluation != null)
            {
                _context.PeerEvaluation.Remove(peerEvaluation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeerEvaluationExists(int id)
        {
          return (_context.PeerEvaluation?.Any(e => e.PeerEvaluationId == id)).GetValueOrDefault();
        }
    }
}
