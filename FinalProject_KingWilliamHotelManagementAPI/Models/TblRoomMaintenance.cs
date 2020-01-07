using System;
using System.Collections.Generic;

namespace KingWilliamHotelManagementAPI.Models
{
    public partial class TblRoomMaintenance
    {
        public int RoomMaintenanceId { get; set; }
        public int EmployeeId { get; set; }
        public int RoomNumber { get; set; }
        public int MaintenanceCode { get; set; }
        public string Description { get; set; }
        public DateTime StartDatetime { get; set; }
        public DateTime? EndDatetime { get; set; }

        public virtual TblEmployee Employee { get; set; }
        public virtual TblRooms RoomNumberNavigation { get; set; }
    }
}
