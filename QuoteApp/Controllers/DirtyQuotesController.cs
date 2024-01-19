using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuoteApp.Data;
using QuoteApp.Models;

namespace QuoteApp.Controllers
{
    public class DirtyQuotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DirtyQuotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DirtyQuotes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DirtyQuotes.ToListAsync());
        }

        // GET: DirtyQuotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dirtyQuotes = await _context.DirtyQuotes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dirtyQuotes == null)
            {
                return NotFound();
            }

            return View(dirtyQuotes);
        }

        // GET: DirtyQuotes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DirtyQuotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quote,Author,Genre")] DirtyQuotes dirtyQuotes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dirtyQuotes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dirtyQuotes);
        }

        // GET: DirtyQuotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dirtyQuotes = await _context.DirtyQuotes.FindAsync(id);
            if (dirtyQuotes == null)
            {
                return NotFound();
            }
            return View(dirtyQuotes);
        }

        // POST: DirtyQuotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quote,Author,Genre")] DirtyQuotes dirtyQuotes)
        {
            if (id != dirtyQuotes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dirtyQuotes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirtyQuotesExists(dirtyQuotes.Id))
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
            return View(dirtyQuotes);
        }

        // GET: DirtyQuotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dirtyQuotes = await _context.DirtyQuotes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dirtyQuotes == null)
            {
                return NotFound();
            }

            return View(dirtyQuotes);
        }

        // POST: DirtyQuotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dirtyQuotes = await _context.DirtyQuotes.FindAsync(id);
            if (dirtyQuotes != null)
            {
                _context.DirtyQuotes.Remove(dirtyQuotes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirtyQuotesExists(int id)
        {
            return _context.DirtyQuotes.Any(e => e.Id == id);
        }
    }
}
