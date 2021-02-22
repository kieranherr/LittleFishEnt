using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LittleFishEnt.Data;
using LittleFishEnt.Models;

namespace LittleFishEnt.Controllers
{
    public class BiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bios.ToListAsync());
        }

        // GET: Bios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bios = await _context.Bios
                .FirstOrDefaultAsync(m => m.BioId == id);
            if (bios == null)
            {
                return NotFound();
            }

            return View(bios);
        }

        // GET: Bios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BioId,Title,Tags,Logline,Type")] Bios bios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bios);
        }

        // GET: Bios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bios = await _context.Bios.FindAsync(id);
            if (bios == null)
            {
                return NotFound();
            }
            return View(bios);
        }

        // POST: Bios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BioId,Title,Tags,Logline,Type")] Bios bios)
        {
            if (id != bios.BioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiosExists(bios.BioId))
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
            return View(bios);
        }

        // GET: Bios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bios = await _context.Bios
                .FirstOrDefaultAsync(m => m.BioId == id);
            if (bios == null)
            {
                return NotFound();
            }

            return View(bios);
        }

        // POST: Bios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bios = await _context.Bios.FindAsync(id);
            _context.Bios.Remove(bios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiosExists(int id)
        {
            return _context.Bios.Any(e => e.BioId == id);
        }
    }
}
