using EvaluationSystem.Data;
using EvaluationSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EvaluationSystem.Controllers
{
    public class EvaluateController : Controller
    {
        private readonly EvaluationSystemContext _context;

        public EvaluateController(EvaluationSystemContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            EvalVM vm = new EvalVM()
            {
                EvaluationList = _context.Evaluation.Include(q=>q.Term).Include(q => q.GradingPeriod).ToList(),
            };

            return View(vm);
        }

    }
}
