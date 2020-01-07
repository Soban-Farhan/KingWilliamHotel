using System;
using System.Collections.Generic;

namespace KingWilliamHotelManagementAPI.Models
{
    public partial class TblEmployee
    {
        public TblEmployee()
        {
            TblPosition = new HashSet<TblPosition>();
            TblRoomHouseKeeping = new HashSet<TblRoomHouseKeeping>();
            TblRoomMaintenance = new HashSet<TblRoomMaintenance>();
        }

        public int EmployeeId { get; set; }
        public string EmergencyContactNumber { get; set; }
        public string EmergencyContactName { get; set; }

        public virtual TblPerson Employee { get; set; }
        public virtual ICollection<TblPosition> TblPosition { get; set; }
        public virtual ICollection<TblRoomHouseKeeping> TblRoomHouseKeeping { get; set; }
        public virtual ICollection<TblRoomMaintenance> TblRoomMaintenance { get; set; }
    }
}
