using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chromebook_Management.Data;
using Chromebook_Management.Models;

namespace Chromebook_Management.Controllers
{
    public class ChromebooksController : Controller
    {
        private readonly ChromebookManagementContext _context;

        public ChromebooksController(ChromebookManagementContext context)
        {
            _context = context;
        }

        // GET: Chromebooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chromebooks.ToListAsync());
        }

        // GET: Chromebooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chromebook = await _context.Chromebooks
                .FirstOrDefaultAsync(m => m.ChromebookId == id);
            if (chromebook == null)
            {
                return NotFound();
            }

            return View(chromebook);
        }

        // GET: Chromebooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chromebooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChromebookId,CommunityId,OrderID,Refurbished,ChromebookType,Status,EnrollmentDate")] Chromebook chromebook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chromebook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chromebook);
        }

        // GET: Chromebooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chromebook = await _context.Chromebooks.FindAsync(id);
            if (chromebook == null)
            {
                return NotFound();
            }
            return View(chromebook);
        }

        // POST: Chromebooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChromebookId,CommunityId,OrderID,Refurbished,ChromebookType,Status,EnrollmentDate")] Chromebook chromebook)
        {
            if (id != chromebook.ChromebookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chromebook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChromebookExists(chromebook.ChromebookId))
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
            return View(chromebook);
        }

        // GET: Chromebooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chromebook = await _context.Chromebooks
                .FirstOrDefaultAsync(m => m.ChromebookId == id);
            if (chromebook == null)
            {
                return NotFound();
            }

            return View(chromebook);
        }

        // POST: Chromebooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chromebook = await _context.Chromebooks.FindAsync(id);
            _context.Chromebooks.Remove(chromebook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChromebookExists(int id)
        {
            return _context.Chromebooks.Any(e => e.ChromebookId == id);
        }
    }
}
