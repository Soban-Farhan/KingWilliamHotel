using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KingWilliamHotelManagementAPI.Models;

namespace KingWilliamHotelManagementAPI.Controllers
{
    public class lkpItemsController : Controller
    {
        private readonly KingWilliamHotel_ManagementSystemContext _context;

        public lkpItemsController(KingWilliamHotel_ManagementSystemContext context)
        {
            _context = context;
        }

        // GET: lkpItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.LkpItems.ToListAsync());
        }

        // GET: lkpItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lkpItems = await _context.LkpItems
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (lkpItems == null)
            {
                return NotFound();
            }

            return View(lkpItems);
        }

        // GET: lkpItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: lkpItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ItemName,Description,QuantityOnHand")] LkpItems lkpItems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lkpItems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lkpItems);
        }

        // GET: lkpItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lkpItems = await _context.LkpItems.FindAsync(id);
            if (lkpItems == null)
            {
                return NotFound();
            }
            return View(lkpItems);
        }

        // POST: lkpItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,ItemName,Description,QuantityOnHand")] LkpItems lkpItems)
        {
            if (id != lkpItems.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lkpItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LkpItemsExists(lkpItems.ItemId))
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
            return View(lkpItems);
        }

        // GET: lkpItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lkpItems = await _context.LkpItems
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (lkpItems == null)
            {
                return NotFound();
            }

            return View(lkpItems);
        }

        // POST: lkpItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lkpItems = await _context.LkpItems.FindAsync(id);
            _context.LkpItems.Remove(lkpItems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LkpItemsExists(int id)
        {
            return _context.LkpItems.Any(e => e.ItemId == id);
        }
    }
}
