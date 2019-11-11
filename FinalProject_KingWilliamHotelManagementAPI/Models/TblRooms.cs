using System;
using System.Collections.Generic;

namespace KingWilliamHotelManagementAPI.Models
{
    public partial class TblRooms
    {
        public TblRooms()
        {
            TblGuestStay = new HashSet<TblGuestStay>();
            TblReservation = new HashSet<TblReservation>();
            TblRoomHouseKeeping = new HashSet<TblRoomHouseKeeping>();
            TblRoomItems = new HashSet<TblRoomItems>();
            TblRoomMaintenance = new HashSet<TblRoomMaintenance>();
        }

        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public string RoomView { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int RoomStatus { get; set; }

        public virtual ICollection<TblGuestStay> TblGuestStay { get; set; }
        public virtual ICollection<TblReservation> TblReservation { get; set; }
        public virtual ICollection<TblRoomHouseKeeping> TblRoomHouseKeeping { get; set; }
        public virtual ICollection<TblRoomItems> TblRoomItems { get; set; }
        public virtual ICollection<TblRoomMaintenance> TblRoomMaintenance { get; set; }
    }
}
