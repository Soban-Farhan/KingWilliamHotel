﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KingWilliamHotelManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace KingWilliamHotelManagementAPI.Controllers
{
    [Authorize(Roles = "Concierge")]
    public class ConciergeController : Controller
    {
        private readonly kwhotelContext _context;

        public ConciergeController(kwhotelContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Reservations()
        {
            return View(await _context.TblReservation.Include(t => t.Person).Include(t => t.RoomNumberNavigation).ToListAsync());
        }
        
        [HttpGet]
        public async Task<IActionResult> EditReservation(int id, int pId)
        {
            var person = await _context.TblPerson.FindAsync(pId);
            var reservation = await _context.TblReservation.FindAsync(id);

            ReservationModel reservationModel = new ReservationModel
            {
                PersonID = person.PersonId,
                ReservationID = id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                City = person.City,
                Country = person.Country,
                EmailAddress = person.EmailAddress,
                PhoneNumber = person.PhoneNumber,
                PostalCode = person.PostalCode,
                StreetNumber = person.StreetNumber,
                StreetName = person.StreetName,
                RoomNumber = reservation.RoomNumber,
                ExpectedArrivalDate = reservation.ExpectedArriveDate,
                Notes = reservation.ReservationNotes,
                ExpectedLeaveDate = reservation.ExpectedLeaveDate,
            };
            ViewData["RoomNumber"] = new SelectList(_context.TblRooms.Where(s => s.RoomStatus == 0), "RoomNumber", "RoomNumber");
            return View(reservationModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditReservation(ReservationModel reservationModel)
        {
            if(ModelState.IsValid)
            {
                TblPerson tblPerson = new TblPerson
                {
                    PersonId = reservationModel.PersonID,
                    FirstName = reservationModel.FirstName,
                    LastName = reservationModel.LastName,
                    City = reservationModel.City,
                    Country = reservationModel.Country,
                    EmailAddress = reservationModel.EmailAddress,
                    PhoneNumber = reservationModel.PhoneNumber,
                    PostalCode = reservationModel.PostalCode,
                    StreetName = reservationModel.StreetName,
                    StreetNumber = reservationModel.StreetNumber,
                };

                TblReservation tblReservation = new TblReservation
                {
                    ReservationId = reservationModel.ReservationID,
                    PersonId = tblPerson.PersonId,
                    ExpectedArriveDate = reservationModel.ExpectedArrivalDate,
                    ExpectedLeaveDate = reservationModel.ExpectedLeaveDate,
                    RoomNumber = reservationModel.RoomNumber,
                    ReservationNotes = reservationModel.Notes
                };

                _context.Update(tblPerson);
                _context.Update(tblReservation);

                await _context.SaveChangesAsync();

                return Redirect("~/Concierge/Reservations");
            }

            ViewData["RoomNumber"] = new SelectList(_context.TblRooms.Where(s => s.RoomStatus == 0), "RoomNumber", "RoomNumber");
            return View(reservationModel);
        }

        public async Task<IActionResult> ReservationCheckIn(int id, int roomNum, int res)
        {

            if(_context.TblCustomer.Any(x => x.CustomerId != id))
            {
                TblCustomer tblCustomer = new TblCustomer
                {
                    CustomerId = id,
                    CreditCardNumber = 8261572984188170
                };

                await _context.TblCustomer.AddAsync(tblCustomer);
            }

            TblGuestStay tblGuestStay = new TblGuestStay
            {
                CustomerId = id,
                RoomNumber = roomNum,
                StartDatetime = DateTime.Now,
            };

            await _context.TblGuestStay.AddAsync(tblGuestStay);

            var room = await _context.TblRooms.FindAsync(roomNum);

            room.RoomStatus = 4;

            _context.Update(room);
            
            _context.TblReservation.Remove(await _context.TblReservation.FindAsync(res));

            await _context.SaveChangesAsync();

            return Redirect("~/Concierge/Reservations");
        }

        public async Task<IActionResult> ReservationCheckOut()
        {
            return View(await _context.TblGuestStay.Include(x => x.Customer.Customer)
                                                   .Include(x => x.RoomNumberNavigation)
                                                   .Where( x => x.EndDatetime == null)
                                                   .ToListAsync());
        }

        public async Task<IActionResult> CheckOut(int id)
        {
            var guestStay = await _context.TblGuestStay.FindAsync(id);
            guestStay.EndDatetime = DateTime.Now;

            var room = await _context.TblRooms.FindAsync(guestStay.RoomNumber);
            room.RoomStatus = 0;

            _context.Update(guestStay);
            _context.Update(room);

            await _context.TblGuestInvoice.AddAsync(new TblGuestInvoice
            {
                GuestStayId = id,
                InvoiceDateTime = DateTime.Now
            });

            await _context.SaveChangesAsync();

            return Redirect("~/Concierge/Reservations");
        }

        public async Task<IActionResult> HouseKeeping()
        {
            var tblRoomHouseKeeping = await _context.TblRoomHouseKeeping.Include(t => t.Employee).Include(t => t.RoomNumberNavigation).ToListAsync();

            List<HouseKeepingModel> tblRoomHouses = new List<HouseKeepingModel>();

            foreach (var x in tblRoomHouseKeeping)
            {
                var person = _context.TblPerson.Find(x.EmployeeId);

                tblRoomHouses.Add(new HouseKeepingModel {
                    houseKeepingId = x.RoomHouseKeepingId,
                    empID = x.EmployeeId,
                    employeeName = person.FirstName + " " + person.LastName,
                    roomNumber = x.RoomNumber,
                    houseKeepingDate = x.RoomHouseKeepingDatetime
                });
            }
            return View(tblRoomHouses);
        }

        [HttpGet]
        public async Task<IActionResult> CreateHouseKeeping(int id)
        {
            var employee = await _context.TblPosition.Where(x => x.PositionId == 7 && x.EndDate == null).ToListAsync();
            List<EmployeeDropdown> employees = new List<EmployeeDropdown>();

            foreach(var x in employee)
            {
                var person = _context.TblPerson.Find(x.EmployeeId);
                employees.Add(new EmployeeDropdown
                {
                    employeeId = x.EmployeeId,
                    employeeName = person.FirstName + " " + person.LastName
                });
            }

            ViewData["EmployeeId"] = employees.ToList();
            ViewData["RoomNumber"] = new SelectList(_context.TblRooms, "RoomNumber", "RoomNumber");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateHouseKeeping(HouseKeepingModel houseKeepingModel)
        {

            if(ModelState.IsValid)
            {
                TblRoomHouseKeeping tblRoomHouse = new TblRoomHouseKeeping
                {
                    EmployeeId = houseKeepingModel.empID,
                    RoomNumber = houseKeepingModel.roomNumber,
                    RoomHouseKeepingDatetime = DateTime.Now
                };

                await _context.TblRoomHouseKeeping.AddAsync(tblRoomHouse);

                await _context.SaveChangesAsync();

                return Redirect("~/Concierge/HouseKeeping");
            }

            var employee = await _context.TblPosition.Where(x => x.PositionId == 7 && x.EndDate == null ).ToListAsync();
            List<EmployeeDropdown> employees = new List<EmployeeDropdown>();

            foreach (var x in employee)
            {
                var person = _context.TblPerson.Find(x.EmployeeId);
                employees.Add(new EmployeeDropdown
                {
                    employeeId = x.EmployeeId,
                    employeeName = person.FirstName + " " + person.LastName
                });
            }

            ViewData["EmployeeId"] = employees.ToList();
            ViewData["RoomNumber"] = new SelectList(_context.TblRooms, "RoomNumber", "RoomNumber");
            return View();
        }

        public async Task<IActionResult> DeleteHouseKeeping(int id)
        {
            var houseKeeping = await _context.TblRoomHouseKeeping.FindAsync(id);

            _context.TblRoomHouseKeeping.Remove(houseKeeping);

            await _context.SaveChangesAsync();

            return Redirect("~/Concierge/Housekeeping");
        }

        [HttpGet]
        public async Task<IActionResult> Maintenance()
        {
            var maintenance = await _context.TblRoomMaintenance.Include(x => x.Employee.Employee)
                                                                .Include(x => x.RoomNumberNavigation)
                                                                .ToListAsync();
            return View(maintenance);
        }

        [HttpGet]
        public async Task<IActionResult> CreateMaintenance()
        {
            var employee = await _context.TblPosition.Where(x => x.PositionId == 5 && x.EndDate == null).ToListAsync();
            List<EmployeeDropdown> employees = new List<EmployeeDropdown>();

            foreach (var x in employee)
            {
                var person = _context.TblPerson.Find(x.EmployeeId);
                employees.Add(new EmployeeDropdown
                {
                    employeeId = x.EmployeeId,
                    employeeName = person.FirstName + " " + person.LastName
                });
            }

            ViewData["EmployeeId"] = employees.ToList();
            ViewData["RoomNumber"] = new SelectList(_context.TblRooms, "RoomNumber", "RoomNumber");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMaintenance(TblRoomMaintenance roomMaintenance)
        {
            if(ModelState.IsValid)
            {
                TblRoomMaintenance tblRoom = new TblRoomMaintenance
                {
                    EmployeeId = roomMaintenance.EmployeeId,
                    Description = roomMaintenance.Description,
                    MaintenanceCode = roomMaintenance.MaintenanceCode,
                    RoomNumber = roomMaintenance.RoomNumber,
                    StartDatetime = DateTime.Now,
                };

                await _context.TblRoomMaintenance.AddAsync(tblRoom);

                await _context.SaveChangesAsync();

                return Redirect("~/Concierge/Maintenance");
            }

            var employee = await _context.TblPosition.Where(x => x.PositionId == 5 && x.EndDate == null).ToListAsync();
            List<EmployeeDropdown> employees = new List<EmployeeDropdown>();

            foreach (var x in employee)
            {
                var person = _context.TblPerson.Find(x.EmployeeId);
                employees.Add(new EmployeeDropdown
                {
                    employeeId = x.EmployeeId,
                    employeeName = person.FirstName + " " + person.LastName
                });
            }

            ViewData["EmployeeId"] = employees.ToList();
            ViewData["RoomNumber"] = new SelectList(_context.TblRooms, "RoomNumber", "RoomNumber");
            return View();
        }

        public async Task<IActionResult> CompleteMaintenance(int id)
        {
            var maintenance = await _context.TblRoomMaintenance.FindAsync(id);
            maintenance.EndDatetime = DateTime.Now;

            _context.Update(maintenance);

            await _context.SaveChangesAsync();

            return Redirect("~/Concierge/Maintenance");
        }

        public async Task<IActionResult> DeleteMaintenance(int id)
        {
            var maintenance = await _context.TblRoomMaintenance.FindAsync(id);

            _context.TblRoomMaintenance.Remove(maintenance);

            await _context.SaveChangesAsync();

            return Redirect("~/Concierge/Maintenance");
        }
    }
}