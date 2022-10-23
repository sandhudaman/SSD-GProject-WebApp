using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class RecordBasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecordBasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RecordBases
        public async Task<IActionResult> Index()
        {
              return View(await _context.RecordBase.ToListAsync());
        }

        // GET: RecordBases/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.RecordBase == null)
            {
                return NotFound();
            }

            var recordBase = await _context.RecordBase
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recordBase == null)
            {
                return NotFound();
            }

            return View(recordBase);
        }

        // GET: RecordBases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecordBases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreationTime")] RecordBase recordBase)
        {
            if (ModelState.IsValid)
            {
                recordBase.Id = Guid.NewGuid();
                _context.Add(recordBase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recordBase);
        }

        // GET: RecordBases/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.RecordBase == null)
            {
                return NotFound();
            }

            var recordBase = await _context.RecordBase.FindAsync(id);
            if (recordBase == null)
            {
                return NotFound();
            }
            return View(recordBase);
        }

        // POST: RecordBases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CreationTime")] RecordBase recordBase)
        {
            if (id != recordBase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recordBase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecordBaseExists(recordBase.Id))
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
            return View(recordBase);
        }

        // GET: RecordBases/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.RecordBase == null)
            {
                return NotFound();
            }

            var recordBase = await _context.RecordBase
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recordBase == null)
            {
                return NotFound();
            }

            return View(recordBase);
        }

        // POST: RecordBases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.RecordBase == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RecordBase'  is null.");
            }
            var recordBase = await _context.RecordBase.FindAsync(id);
            if (recordBase != null)
            {
                _context.RecordBase.Remove(recordBase);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecordBaseExists(Guid id)
        {
          return _context.RecordBase.Any(e => e.Id == id);
        }
    }
}
