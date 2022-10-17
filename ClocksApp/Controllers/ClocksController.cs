using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClocksApp.Data;
using ClocksApp.Models;

namespace ClocksApp.Controllers
{
    public class ClocksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClocksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clocks
        public async Task<IActionResult> Index(string searchString)
        {
            var clocks = from c in _context.Clocks
                         select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                clocks = clocks.Where(s => s.Name.Contains(searchString));
            }


            return View(await _context.Clocks.ToListAsync());
        }

        // GET: Clocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clocks = await _context.Clocks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clocks == null)
            {
                return NotFound();
            }

            return View(clocks);
        }

        // GET: Clocks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ReleaseDate,Type,Price")] Clocks clocks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clocks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clocks);
        }

        // GET: Clocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clocks = await _context.Clocks.FindAsync(id);
            if (clocks == null)
            {
                return NotFound();
            }
            return View(clocks);
        }

        // POST: Clocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ReleaseDate,Type,Price")] Clocks clocks)
        {
            if (id != clocks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clocks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClocksExists(clocks.Id))
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
            return View(clocks);
        }

        // GET: Clocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clocks = await _context.Clocks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clocks == null)
            {
                return NotFound();
            }

            return View(clocks);
        }

        // POST: Clocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clocks = await _context.Clocks.FindAsync(id);
            _context.Clocks.Remove(clocks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClocksExists(int id)
        {
            return _context.Clocks.Any(e => e.Id == id);
        }
    }
}
