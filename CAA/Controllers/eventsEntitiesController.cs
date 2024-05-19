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
    public class eventsEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public eventsEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: eventsEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Events.ToListAsync());
        }

        // GET: eventsEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventsEntity = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventsEntity == null)
            {
                return NotFound();
            }

            return View(eventsEntity);
        }

        // GET: eventsEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: eventsEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EventDate,EventTitle,Desc,Capacity,Email")] eventsEntity eventsEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventsEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventsEntity);
        }

        // GET: eventsEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventsEntity = await _context.Events.FindAsync(id);
            if (eventsEntity == null)
            {
                return NotFound();
            }
            return View(eventsEntity);
        }

        // POST: eventsEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EventDate,EventTitle,Desc,Capacity,Email")] eventsEntity eventsEntity)
        {
            if (id != eventsEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventsEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!eventsEntityExists(eventsEntity.Id))
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
            return View(eventsEntity);
        }

        // GET: eventsEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventsEntity = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventsEntity == null)
            {
                return NotFound();
            }

            return View(eventsEntity);
        }

        // POST: eventsEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventsEntity = await _context.Events.FindAsync(id);
            if (eventsEntity != null)
            {
                _context.Events.Remove(eventsEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool eventsEntityExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
