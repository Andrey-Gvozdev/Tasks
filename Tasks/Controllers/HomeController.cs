using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tasks.Data;
using Tasks.Models;

namespace Tasks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext db;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Tasks.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> UserPage()
        {
            return View(await db.Tasks.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.Task task)
        {
            db.Tasks.Add(task);
            await db.SaveChangesAsync();
            return RedirectToAction("UserPage");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var task = await db.Tasks.FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
                return NotFound();

            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await db.Tasks.FindAsync(id);
            db.Tasks.Remove(movie);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(UserPage));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var task = await db.Tasks.FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
                return NotFound();

            return View(task);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var task = await db.Tasks.FindAsync(id);
            if (task == null)
                return NotFound();

            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,TheTask,Theme,Answer,UserId")] Models.Task task)
        {
            if (id != task.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                db.Update(task);
                await db.SaveChangesAsync();
                return RedirectToAction("UserPage");
            }
            return View(task);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
