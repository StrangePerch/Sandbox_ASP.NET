using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sandbox_ASP.NET.Data;
using Sandbox_ASP.NET.Models;

namespace Sandbox_ASP.NET.Controllers
{
    public class LevelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LevelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Public Levels";
            return View("Index", await _context.Levels.Where((l=> l.Public)).ToListAsync());
        }
        
        // GET: Levels
        public async Task<IActionResult> Public()
        {
            ViewBag.Title = "Public Levels";
            ViewBag.Edit = false;
            return View("Index", await _context.Levels.Where((l=> l.Public)).ToListAsync());
        }
        
        public async Task<IActionResult> Private()
        {
            ViewBag.Title = "Your Levels";
            ViewBag.Edit = true;
            return View("Index", await _context.Levels.Where((l=> l.Author == User.Identity.Name)).ToListAsync());
        }
        

        // GET: Levels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var levelViewModel = await _context.Levels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (levelViewModel == null)
            {
                return NotFound();
            }

            return View(levelViewModel);
        }

        // GET: Levels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Levels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Author,Public,Map")] LevelModel levelViewModel)
        {
            if (ModelState.IsValid)
            {
                levelViewModel.Id = Guid.NewGuid();
                _context.Add(levelViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(levelViewModel);
        }

        // GET: Levels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var levelViewModel = await _context.Levels.FindAsync(id);
            if (levelViewModel == null)
            {
                return NotFound();
            }
            return View(levelViewModel);
        }

        // POST: Levels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Author,Public,Map")] LevelModel levelViewModel)
        {
            if (id != levelViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(levelViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LevelViewModelExists(levelViewModel.Id))
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
            return View(levelViewModel);
        }

        // GET: Levels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var levelViewModel = await _context.Levels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (levelViewModel == null)
            {
                return NotFound();
            }

            return View(levelViewModel);
        }

        // POST: Levels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var levelViewModel = await _context.Levels.FindAsync(id);
            _context.Levels.Remove(levelViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LevelViewModelExists(Guid id)
        {
            return _context.Levels.Any(e => e.Id == id);
        }
    }
}
