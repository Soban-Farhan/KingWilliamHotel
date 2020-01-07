using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingWilliamHotelManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KingWilliamHotelManagementAPI.Controllers
{
    [Authorize(Roles = "Maintenance")]
    public class MaintenanceController : Controller
    {
        private readonly kwhotelContext _context;

        public MaintenanceController(kwhotelContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var maintenance = await _context.TblRoomMaintenance.Include(x => x.Employee.Employee)
                                                                .Include(x => x.RoomNumberNavigation)
                                                                .ToListAsync();
            return View(maintenance);
        }

        public async Task<IActionResult> CompleteMaintenance(int id)
        {
            var maintenance = await _context.TblRoomMaintenance.FindAsync(id);
            maintenance.EndDatetime = DateTime.Now;

            _context.Update(maintenance);

            await _context.SaveChangesAsync();

            return Redirect("~/Maintenance");
        }
    }
}