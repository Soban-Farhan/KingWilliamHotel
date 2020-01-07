using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KingWilliamHotelManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace KingWilliamHotelManagementAPI.Controllers
{
    [Authorize(Roles = "House Keeping")]
    public class HouseKeepingController : Controller
    {
        private readonly kwhotelContext _context;
        public HouseKeepingController(kwhotelContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tblRoomHouseKeeping = await _context.TblRoomHouseKeeping.Include(t => t.Employee).Include(t => t.RoomNumberNavigation).ToListAsync();

            List<HouseKeepingModel> tblRoomHouses = new List<HouseKeepingModel>();

            foreach (var x in tblRoomHouseKeeping)
            {
                var person = _context.TblPerson.Find(x.EmployeeId);

                tblRoomHouses.Add(new HouseKeepingModel
                {
                    houseKeepingId = x.RoomHouseKeepingId,
                    empID = x.EmployeeId,
                    employeeName = person.FirstName + " " + person.LastName,
                    roomNumber = x.RoomNumber,
                    houseKeepingDate = x.RoomHouseKeepingDatetime
                });
            }
            return View(tblRoomHouses);
        }

        public async Task<IActionResult> DeleteHouseKeeping(int id)
        {
            var houseKeeping = await _context.TblRoomHouseKeeping.FindAsync(id);

            _context.TblRoomHouseKeeping.Remove(houseKeeping);

            await _context.SaveChangesAsync();

            return Redirect("~/HouseKeeping");
        }
    }
}