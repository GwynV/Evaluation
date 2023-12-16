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
    public class EvaluationCategoriesController : Controller
    {
        private readonly EvaluationSystemContext _context;

        public EvaluationCategoriesController(EvaluationSystemContext context)
        {
            _context = context;
        }

        // GET: EvaluationCategories
        public async Task<IActionResult> Index()
        {
              return _context.EvaluationCategory != null ? 
                          View(await _context.EvaluationCategory.ToListAsync()) :
                          Problem("Entity set 'EvaluationSystemContext.EvaluationCategory'  is null.");
        }

        // GET: EvaluationCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EvaluationCategory == null)
            {
                return NotFound();
            }

            var evaluationCategory = await _context.EvaluationCategory
                .FirstOrDefaultAsync(m => m.EvaluationCategoryId == id);
            if (evaluationCategory == null)
            {
                return NotFound();
            }

            return View(evaluationCategory);
        }

        // GET: EvaluationCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EvaluationCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EvaluationId,EvaluationCategoryName")] EvaluationCategory evaluationCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evaluationCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(evaluationCategory);
        }

        // GET: EvaluationCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EvaluationCategory == null)
            {
                return NotFound();
            }

            var evaluationCategory = await _context.EvaluationCategory.FindAsync(id);
            if (evaluationCategory == null)
            {
                return NotFound();
            }
            return View(evaluationCategory);
        }

        // POST: EvaluationCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EvaluationId,EvaluationCategoryName")] EvaluationCategory evaluationCategory)
        {
            if (id != evaluationCategory.EvaluationCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluationCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluationCategoryExists(evaluationCategory.EvaluationCategoryId))
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
            return View(evaluationCategory);
        }

        // GET: EvaluationCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EvaluationCategory == null)
            {
                return NotFound();
            }

            var evaluationCategory = await _context.EvaluationCategory
                .FirstOrDefaultAsync(m => m.EvaluationCategoryId == id);
            if (evaluationCategory == null)
            {
                return NotFound();
            }

            return View(evaluationCategory);
        }

        // POST: EvaluationCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EvaluationCategory == null)
            {
                return Problem("Entity set 'EvaluationSystemContext.EvaluationCategory'  is null.");
            }
            var evaluationCategory = await _context.EvaluationCategory.FindAsync(id);
            if (evaluationCategory != null)
            {
                _context.EvaluationCategory.Remove(evaluationCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluationCategoryExists(int id)
        {
          return (_context.EvaluationCategory?.Any(e => e.EvaluationCategoryId == id)).GetValueOrDefault();
        }
    }
}
