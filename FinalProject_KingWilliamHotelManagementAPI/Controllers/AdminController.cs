﻿using KingWilliamHotelManagementAPI.Data;
using KingWilliamHotelManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KingWilliamHotelManagementAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly kwhotelContext _context;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AdminController(kwhotelContext context, ApplicationDbContext dbContext, 
                               UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Employee()
        {
            var employees = _context.TblEmployee.Select(s => s.EmployeeId);
            var person = _context.TblPerson.Where(r => employees.Contains(r.PersonId));
            //return View();

            return View(await person.ToListAsync());
        }
        [HttpGet]
        public IActionResult NewEmployee()
        {
            ViewData["Position"] = new SelectList(_context.LkpPositionTypes.Where(s => s.IsActive == true), "PositionId", "Description");
            ViewData["Error"] = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewEmployee(EmployeeModel employeeModel)
        {
            var person = _context.TblPerson.Where(x => x.EmailAddress == employeeModel.EmailAddress).ToList();
            ViewData["Error"] = "";
            foreach (var x in person)
            {
                if(x.EmailAddress == employeeModel.EmailAddress)
                {
                    ViewData["Position"] = new SelectList(_context.LkpPositionTypes.Where(s => s.IsActive == true), "PositionId", "Description");
                    ViewData["Error"] = "The email address for username is already taken.";
                    return View();
                }
            }

            if (ModelState.IsValid)
            {
                TblPerson tblPerson = new TblPerson
                {
                    FirstName = employeeModel.FirstName,
                    LastName = employeeModel.LastName,
                    EmailAddress = employeeModel.EmailAddress,
                    PhoneNumber = employeeModel.PhoneNumber,
                    StreetNumber = employeeModel.StreetNumber,
                    StreetName = employeeModel.StreetName,
                    City = employeeModel.City,
                    PostalCode = employeeModel.PostalCode,
                    Country = employeeModel.Country,
                };
                await _context.TblPerson.AddAsync(tblPerson);

                TblEmployee tblEmployee = new TblEmployee
                {
                    EmployeeId = tblPerson.PersonId,
                    EmergencyContactName = employeeModel.EmergencyContactName,
                    EmergencyContactNumber = employeeModel.EmergencyContactNumber,
                };
                await _context.TblEmployee.AddAsync(tblEmployee);

                TblPosition tblPosition = new TblPosition
                {
                    EmployeeId = tblEmployee.EmployeeId,
                    PositionId = employeeModel.Position,
                    StartDate = DateTime.Now,
                };
                await _context.TblPosition.AddAsync(tblPosition);

                var user = new ApplicationUser { UserName = employeeModel.EmailAddress, Email = employeeModel.EmailAddress };
                var result = await _userManager.CreateAsync(user, "Password@123");
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, _context.LkpPositionTypes.Find(employeeModel.Position).Description.ToString()).Wait();
                }

                await _context.SaveChangesAsync();

                return Redirect("/Admin/");
            }
            ViewData["Position"] = new SelectList(_context.LkpPositionTypes.Where(s => s.IsActive == true), "PositionId", "Description");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else if (_context.TblEmployee.Any(s=> s.EmployeeId == id))
            {
                var tblEmployee = await _context.TblEmployee.FindAsync(id);
                var tblPerson = await _context.TblPerson.FindAsync(id);
                var position = _context.TblPosition.Where(x => x.EmployeeId == tblEmployee.EmployeeId).Select(x=>x.PositionId).ToList();
                var positionID = 0;
                if (tblPerson == null)
                {
                    return NotFound();
                }
                
                foreach (var x in position)
                {
                    positionID = x;
                }

                EmployeeModel employeeModel = new EmployeeModel
                {
                    FirstName = tblPerson.FirstName,
                    LastName = tblPerson.LastName,
                    PhoneNumber = tblPerson.PhoneNumber,
                    Position = positionID,
                    City = tblPerson.City,
                    Country = tblPerson.Country,
                    EmailAddress = tblPerson.EmailAddress,
                    StreetName = tblPerson.StreetName,
                    StreetNumber = tblPerson.StreetNumber,
                    PostalCode = tblPerson.PostalCode,
                    EmergencyContactName = tblEmployee.EmergencyContactName,
                    EmergencyContactNumber = tblEmployee.EmergencyContactNumber,
                    PersonID = tblPerson.PersonId,
                };
                ViewData["Position"] = new SelectList(_context.LkpPositionTypes.Where(s => s.IsActive == true), "PositionId", "Description");
                return View(employeeModel);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEmployee(int? id, EmployeeModel employeeModel)
        {
            if (id != employeeModel.PersonID)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                TblPerson tblPerson = new TblPerson
                {
                    PersonId = employeeModel.PersonID,
                    FirstName = employeeModel.FirstName,
                    LastName = employeeModel.LastName,
                    EmailAddress = employeeModel.EmailAddress,
                    PhoneNumber = employeeModel.PhoneNumber,
                    StreetNumber = employeeModel.StreetNumber,
                    StreetName = employeeModel.StreetName,
                    City = employeeModel.City,
                    PostalCode = employeeModel.PostalCode,
                    Country = employeeModel.Country,
                };

                TblEmployee tblEmployee = new TblEmployee
                {
                    EmployeeId = employeeModel.PersonID,
                    EmergencyContactName = employeeModel.EmergencyContactName,
                    EmergencyContactNumber = employeeModel.EmergencyContactNumber,
                };

                _context.Update(tblPerson);
                _context.Update(tblEmployee);

                await _context.SaveChangesAsync();

                var position = _context.TblPosition.Where(x => x.EmployeeId == employeeModel.PersonID && x.EndDate == null).ToList();
                var positionID = 0;
                var previousRecordID = 0;
                foreach (var x in position)
                {
                    previousRecordID = x.Id;
                    positionID = x.PositionId;
                }

                if (positionID != employeeModel.Position)
                {
                    var previousRecord = _context.TblPosition.Find(previousRecordID);
                    previousRecord.EndDate = DateTime.Now;
                    _context.Update(previousRecord);

                    TblPosition tblPosition = new TblPosition
                    {
                        EmployeeId = employeeModel.PersonID,
                        PositionId = employeeModel.Position,
                        StartDate = DateTime.Now,
                    };
                    await _context.TblPosition.AddAsync(tblPosition);

                    var user = _userManager.Users.Where(x => x.UserName == employeeModel.EmailAddress).ToList();

                    foreach(var x in user)
                    {
                        var previousUser = _dbContext.Users.Find(x.Id);
                        var removeUser = await _userManager.RemoveFromRoleAsync(previousUser, _context.LkpPositionTypes.Find(positionID).Description.ToString());

                        if(removeUser.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(previousUser, _context.LkpPositionTypes.Find(employeeModel.Position).Description.ToString());
                        }
                    }

                    await _context.SaveChangesAsync();
                }

                return Redirect("/Admin/Employee");
            }
            ViewData["Position"] = new SelectList(_context.LkpPositionTypes.Where(s => s.IsActive == true), "PositionId", "Description");
            return View(employeeModel);
        }

        [HttpGet]
        public async Task<IActionResult> Invoice()
        {
            var invoice = await _context.TblGuestInvoice.Include(x => x.GuestStay)
                                                            .Include(x => x.GuestStay.Customer)
                                                            .Include(x => x.GuestStay.RoomNumberNavigation)
                                                            .ToListAsync();

            List<InvoiceModel> invoices = new List<InvoiceModel>();

            foreach (var item in invoice)
            {
                invoices.Add(new InvoiceModel {
                    TblGuestInvoice = item,
                    TblGuestStay = item.GuestStay,
                    TblPerson = await _context.TblPerson.FindAsync(item.GuestStay.Customer.CustomerId),
                    TblRooms = item.GuestStay.RoomNumberNavigation,
                    
                    //TblGuestLineItems = new List<TblGuestLineItems>( await _context.TblGuestLineItems
                    //                                                                .Where(x => x.GuestStayId == item.GuestStayId).ToListAsync())
                });

            }

            return View(invoices);
        }

        [HttpGet]
        public async Task<IActionResult> InvoiceView(int id)
        {
            var invoice = await _context.TblGuestInvoice.Where(x => x.InvoiceId == id)
                                                            .Include(x => x.GuestStay)
                                                            .Include(x => x.GuestStay.Customer)
                                                            .Include(x => x.GuestStay.RoomNumberNavigation)
                                                            .SingleOrDefaultAsync();

            InvoiceModel invoices = new InvoiceModel
            {
                TblGuestInvoice = invoice,
                TblGuestStay = invoice.GuestStay,
                TblPerson = await _context.TblPerson.FindAsync(invoice.GuestStay.Customer.CustomerId),
                TblGuestLineItems = new List<TblGuestLineItems>(await _context.TblGuestLineItems
                                                                                .Where(x => x.GuestStayId == invoice.GuestStayId).ToListAsync()),
                TblRooms = invoice.GuestStay.RoomNumberNavigation,
                LkpItems = new List<LkpItems> ()
            };

            foreach (var x in invoices.TblGuestLineItems)
            {
                invoices.LkpItems.Add(await _context.LkpItems.FindAsync(x.ItemId));
            }

            return View(invoices);
        }

        public IActionResult Orders()
        {
            return View();
        }
    }
}
