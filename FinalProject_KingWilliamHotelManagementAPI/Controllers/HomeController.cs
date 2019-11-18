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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reservation(ReservationModel reservationModel)
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
            }
            return View();
        }
    }
}
