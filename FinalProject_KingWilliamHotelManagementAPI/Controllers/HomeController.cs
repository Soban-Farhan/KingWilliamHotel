using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KingWilliamHotelManagementAPI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KingWilliamHotelManagementAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly KingWilliamHotel_ManagementSystemContext _context;

        public HomeController(KingWilliamHotel_ManagementSystemContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Reservation()
        {
            ViewData["RoomNumber"] = new SelectList(_context.TblRooms.Where(s => s.RoomStatus == 0), "RoomNumber", "RoomNumber");
            return View();
        }

        [HttpGet]
        public ActionResult Room(int? id)
        {
            if(id == null)
            {
                return Redirect("/");
            }
            ViewData["RoomID"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reservation(ReservationModel reservationModel)
        {
            if (ModelState.IsValid)
            {
                TblPerson tblPerson = new TblPerson
                {
                    FirstName = reservationModel.FirstName,
                    LastName = reservationModel.LastName,
                    EmailAddress = reservationModel.EmailAddress,
                    PhoneNumber = reservationModel.PhoneNumber,
                    StreetNumber = reservationModel.StreetNumber,
                    StreetName = reservationModel.StreetName,
                    City = reservationModel.City,
                    PostalCode = reservationModel.PostalCode,
                    Country = reservationModel.Country,
                };
                await _context.TblPerson.AddAsync(tblPerson);

                TblReservation tblReservation = new TblReservation
                {
                    PersonId = tblPerson.PersonId,
                    RoomNumber = reservationModel.RoomNumber,
                    ExpectedArriveDate = reservationModel.ExpectedArrivalDate,
                    ExpectedLeaveDate = reservationModel.ExpectedLeaveDate,
                    ReservationNotes = reservationModel.Notes,
                };
                await _context.TblReservation.AddAsync(tblReservation);

                await _context.SaveChangesAsync();

                return Redirect("/");
            }
            return View();
        }
    }
}
