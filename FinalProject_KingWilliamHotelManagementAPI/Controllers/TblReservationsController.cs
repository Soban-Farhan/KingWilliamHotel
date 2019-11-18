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
    public class TblReservationsController : Controller
    {
        private readonly KingWilliamHotel_ManagementSystemContext _context;

        public TblReservationsController(KingWilliamHotel_ManagementSystemContext context)
        {
            _context = context;
        }

        // GET: TblReservations
        public async Task<IActionResult> Index()
        {
            var kingWilliamHotel_ManagementSystemContext = _context.TblReservation.Include(t => t.Person).Include(t => t.RoomNumberNavigation);
            return View(await kingWilliamHotel_ManagementSystemContext.ToListAsync());
        }

        // GET: TblReservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblReservation = await _context.TblReservation
                .Include(t => t.Person)
                .Include(t => t.RoomNumberNavigation)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (tblReservation == null)
            {
                return NotFound();
            }

            return View(tblReservation);
        }

        // GET: TblReservations/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.TblPerson, "PersonId", "City");
            ViewData["RoomNumber"] = new SelectList(_context.TblRooms, "RoomNumber", "Description");
            return View();
        }

        // POST: TblReservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationId,PersonId,RoomNumber,ExpectedArriveDate,ExpectedLeaveDate,ReservationNotes")] TblReservation tblReservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblReservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.TblPerson, "PersonId", "City", tblReservation.PersonId);
            ViewData["RoomNumber"] = new SelectList(_context.TblRooms, "RoomNumber", "Description", tblReservation.RoomNumber);
            return View(tblReservation);
        }

        // GET: TblReservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblReservation = await _context.TblReservation.FindAsync(id);
            if (tblReservation == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.TblPerson, "PersonId", "City", tblReservation.PersonId);
            ViewData["RoomNumber"] = new SelectList(_context.TblRooms, "RoomNumber", "Description", tblReservation.RoomNumber);
            return View(tblReservation);
        }

        // POST: TblReservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationId,PersonId,RoomNumber,ExpectedArriveDate,ExpectedLeaveDate,ReservationNotes")] TblReservation tblReservation)
        {
            if (id != tblReservation.ReservationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblReservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblReservationExists(tblReservation.ReservationId))
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
            ViewData["PersonId"] = new SelectList(_context.TblPerson, "PersonId", "City", tblReservation.PersonId);
            ViewData["RoomNumber"] = new SelectList(_context.TblRooms, "RoomNumber", "Description", tblReservation.RoomNumber);
            return View(tblReservation);
        }

        // GET: TblReservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblReservation = await _context.TblReservation
                .Include(t => t.Person)
                .Include(t => t.RoomNumberNavigation)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (tblReservation == null)
            {
                return NotFound();
            }

            return View(tblReservation);
        }

        // POST: TblReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblReservation = await _context.TblReservation.FindAsync(id);
            _context.TblReservation.Remove(tblReservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblReservationExists(int id)
        {
            return _context.TblReservation.Any(e => e.ReservationId == id);
        }
    }
}
