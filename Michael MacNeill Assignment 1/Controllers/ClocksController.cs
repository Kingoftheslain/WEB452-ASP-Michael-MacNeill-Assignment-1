using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Michael_MacNeill_Assignment_1.Data;
using Michael_MacNeill_Assignment_1.Models;

namespace Michael_MacNeill_Assignment_1.Controllers
{
    public class ClocksController : Controller
    {
        private readonly ClockContext _context;

        public ClocksController(ClockContext context)
        {
            _context = context;
        }

        // GET: Clocks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clock.ToListAsync());
        }

        // GET: Clocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clock = await _context.Clock
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clock == null)
            {
                return NotFound();
            }

            return View(clock);
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
        public async Task<IActionResult> Create([Bind("Id,Name,ReleaseDate,Type,Price")] Clock clock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clock);
        }

        // GET: Clocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clock = await _context.Clock.FindAsync(id);
            if (clock == null)
            {
                return NotFound();
            }
            return View(clock);
        }

        // POST: Clocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ReleaseDate,Type,Price")] Clock clock)
        {
            if (id != clock.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClockExists(clock.Id))
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
            return View(clock);
        }

        // GET: Clocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clock = await _context.Clock
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clock == null)
            {
                return NotFound();
            }

            return View(clock);
        }

        // POST: Clocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clock = await _context.Clock.FindAsync(id);
            _context.Clock.Remove(clock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClockExists(int id)
        {
            return _context.Clock.Any(e => e.Id == id);
        }
    }
}
