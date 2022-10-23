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
    public class ImmunizationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImmunizationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Immunizations
        public async Task<IActionResult> Index()
        {
              return View(await _context.Immunization.ToListAsync());
        }

        // GET: Immunizations/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Immunization == null)
            {
                return NotFound();
            }

            var immunization = await _context.Immunization
                .FirstOrDefaultAsync(m => m.Id == id);
            if (immunization == null)
            {
                return NotFound();
            }

            return View(immunization);
        }

        // GET: Immunizations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Immunizations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OfficialName,TradeName,LotNumber,ExpirationDate,CreationTime,UpdatedTime")] Immunization immunization)
        {
            if (ModelState.IsValid)
            {
                immunization.Id = Guid.NewGuid();
                _context.Add(immunization);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(immunization);
        }

        // GET: Immunizations/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Immunization == null)
            {
                return NotFound();
            }

            var immunization = await _context.Immunization.FindAsync(id);
            if (immunization == null)
            {
                return NotFound();
            }
            return View(immunization);
        }

        // POST: Immunizations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,OfficialName,TradeName,LotNumber,ExpirationDate,CreationTime,UpdatedTime")] Immunization immunization)
        {
            if (id != immunization.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(immunization);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImmunizationExists(immunization.Id))
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
            return View(immunization);
        }

        // GET: Immunizations/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Immunization == null)
            {
                return NotFound();
            }

            var immunization = await _context.Immunization
                .FirstOrDefaultAsync(m => m.Id == id);
            if (immunization == null)
            {
                return NotFound();
            }

            return View(immunization);
        }

        // POST: Immunizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Immunization == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Immunization'  is null.");
            }
            var immunization = await _context.Immunization.FindAsync(id);
            if (immunization != null)
            {
                _context.Immunization.Remove(immunization);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImmunizationExists(Guid id)
        {
          return _context.Immunization.Any(e => e.Id == id);
        }
    }
}
