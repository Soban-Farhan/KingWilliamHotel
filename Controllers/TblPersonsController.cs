using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KingWilliamHotelManagementAPI.Models;

namespace KingWilliamHotelManagementAPI
{
    public class TblPersonsController : Controller
    {
        private readonly KingWilliamHotel_ManagementSystemContext _context;

        public TblPersonsController(KingWilliamHotel_ManagementSystemContext context)
        {
            _context = context;
        }

        // GET: TblPersons
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblPerson.ToListAsync());
        }

        // GET: TblPersons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPerson = await _context.TblPerson
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (tblPerson == null)
            {
                return NotFound();
            }

            return View(tblPerson);
        }

        // GET: TblPersons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblPersons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,FirstName,LastName,StreetNumber,StreetName,City,PostalCode,Country,PhoneNumber,EmailAddress")] TblPerson tblPerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblPerson);
        }

        // GET: TblPersons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPerson = await _context.TblPerson.FindAsync(id);
            if (tblPerson == null)
            {
                return NotFound();
            }
            return View(tblPerson);
        }

        // POST: TblPersons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonId,FirstName,LastName,StreetNumber,StreetName,City,PostalCode,Country,PhoneNumber,EmailAddress")] TblPerson tblPerson)
        {
            if (id != tblPerson.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPersonExists(tblPerson.PersonId))
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
            return View(tblPerson);
        }

        // GET: TblPersons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPerson = await _context.TblPerson
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (tblPerson == null)
            {
                return NotFound();
            }

            return View(tblPerson);
        }

        // POST: TblPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblPerson = await _context.TblPerson.FindAsync(id);
            _context.TblPerson.Remove(tblPerson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPersonExists(int id)
        {
            return _context.TblPerson.Any(e => e.PersonId == id);
        }
    }
}
