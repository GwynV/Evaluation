using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EvaluationSystem.Data;
using EvaluationSystem.Models;
using EvaluationSystem.Services;

namespace EvaluationSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly EvaluationSystemContext _context;

        public LoginController(EvaluationSystemContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User user) 
        {
            string HashPassword = Hashing.HashData(user.Password);
            user.Password = HashPassword;
            User register = await _context.User.SingleOrDefaultAsync(q => q.UserName == user.UserName && q.Password == user.Password);
            if (register != null)
            {
                ViewData["LoginErrorMessage"] = null;
                return RedirectToAction("Index", "Home");
            }
            ViewData["LoginErrorMessage"] = "Incorrect Password or Email";
            return View("Index");  
        }
    }
}
