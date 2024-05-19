using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CAA.Data;
using CAA.Models;

namespace CAA.Controllers
{
    public class signUpEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public signUpEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: signUpEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.signUpEntity.ToListAsync());
        }

        // GET: signUpEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signUpEntity = await _context.signUpEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signUpEntity == null)
            {
                return NotFound();
            }

            return View(signUpEntity);
        }

        // GET: signUpEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: signUpEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,PhoneNumber")] signUpEntity signUpEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(signUpEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(signUpEntity);
        }

        // GET: signUpEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signUpEntity = await _context.signUpEntity.FindAsync(id);
            if (signUpEntity == null)
            {
                return NotFound();
            }
            return View(signUpEntity);
        }

        // POST: signUpEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,PhoneNumber")] signUpEntity signUpEntity)
        {
            if (id != signUpEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signUpEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!signUpEntityExists(signUpEntity.Id))
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
            return View(signUpEntity);
        }

        // GET: signUpEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signUpEntity = await _context.signUpEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signUpEntity == null)
            {
                return NotFound();
            }

            return View(signUpEntity);
        }

        // POST: signUpEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var signUpEntity = await _context.signUpEntity.FindAsync(id);
            if (signUpEntity != null)
            {
                _context.signUpEntity.Remove(signUpEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool signUpEntityExists(int id)
        {
            return _context.signUpEntity.Any(e => e.Id == id);
        }
    }
}
