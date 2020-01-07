using System;
using System.Collections.Generic;

namespace KingWilliamHotelManagementAPI.Models
{
    public partial class TblRoomHouseKeeping
    {
        public int RoomHouseKeepingId { get; set; }
        public int EmployeeId { get; set; }
        public int RoomNumber { get; set; }
        public DateTime RoomHouseKeepingDatetime { get; set; }

        public virtual TblEmployee Employee { get; set; }
        public virtual TblRooms RoomNumberNavigation { get; set; }
    }
}
