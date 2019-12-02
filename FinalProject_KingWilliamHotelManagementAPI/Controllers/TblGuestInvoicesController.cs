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
    public class TblGuestInvoicesController : Controller
    {
        private readonly KingWilliamHotel_ManagementSystemContext _context;

        public TblGuestInvoicesController(KingWilliamHotel_ManagementSystemContext context)
        {
            _context = context;
        }

        // GET: TblGuestInvoices
        public async Task<IActionResult> Index()
        {
            var kingWilliamHotel_ManagementSystemContext = _context.TblGuestInvoice.Include(t => t.GuestStay);
            return View(await kingWilliamHotel_ManagementSystemContext.ToListAsync());
        }

        // GET: TblGuestInvoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblGuestInvoice = await _context.TblGuestInvoice
                .Include(t => t.GuestStay)
                .FirstOrDefaultAsync(m => m.InvoiceId == id);
            if (tblGuestInvoice == null)
            {
                return NotFound();
            }

            return View(tblGuestInvoice);
        }

        // GET: TblGuestInvoices/Create
        public IActionResult Create()
        {
            ViewData["GuestStayId"] = new SelectList(_context.TblGuestStay, "GuestStayId", "GuestStayId");
            return View();
        }

        // POST: TblGuestInvoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvoiceId,GuestStayId,InvoiceDateTime")] TblGuestInvoice tblGuestInvoice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblGuestInvoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GuestStayId"] = new SelectList(_context.TblGuestStay, "GuestStayId", "GuestStayId", tblGuestInvoice.GuestStayId);
            return View(tblGuestInvoice);
        }

        // GET: TblGuestInvoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblGuestInvoice = await _context.TblGuestInvoice.FindAsync(id);
            if (tblGuestInvoice == null)
            {
                return NotFound();
            }
            ViewData["GuestStayId"] = new SelectList(_context.TblGuestStay, "GuestStayId", "GuestStayId", tblGuestInvoice.GuestStayId);
            return View(tblGuestInvoice);
        }

        // POST: TblGuestInvoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvoiceId,GuestStayId,InvoiceDateTime")] TblGuestInvoice tblGuestInvoice)
        {
            if (id != tblGuestInvoice.InvoiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblGuestInvoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblGuestInvoiceExists(tblGuestInvoice.InvoiceId))
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
            ViewData["GuestStayId"] = new SelectList(_context.TblGuestStay, "GuestStayId", "GuestStayId", tblGuestInvoice.GuestStayId);
            return View(tblGuestInvoice);
        }

        // GET: TblGuestInvoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblGuestInvoice = await _context.TblGuestInvoice
                .Include(t => t.GuestStay)
                .FirstOrDefaultAsync(m => m.InvoiceId == id);
            if (tblGuestInvoice == null)
            {
                return NotFound();
            }

            return View(tblGuestInvoice);
        }

        // POST: TblGuestInvoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblGuestInvoice = await _context.TblGuestInvoice.FindAsync(id);
            _context.TblGuestInvoice.Remove(tblGuestInvoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblGuestInvoiceExists(int id)
        {
            return _context.TblGuestInvoice.Any(e => e.InvoiceId == id);
        }
    }
}
