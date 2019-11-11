using System;
using System.Collections.Generic;

namespace KingWilliamHotelManagementAPI.Models
{
    public partial class TblReservation
    {
        public int ReservationId { get; set; }
        public int PersonId { get; set; }
        public int RoomNumber { get; set; }
        public DateTime ExpectedArriveDate { get; set; }
        public DateTime? ExpectedLeaveDate { get; set; }
        public string ReservationNotes { get; set; }

        public virtual TblPerson Person { get; set; }
        public virtual TblRooms RoomNumberNavigation { get; set; }
    }
}
