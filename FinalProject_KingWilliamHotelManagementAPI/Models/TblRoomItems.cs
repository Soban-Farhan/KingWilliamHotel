using System;
using System.Collections.Generic;

namespace KingWilliamHotelManagementAPI.Models
{
    public partial class TblRoomItems
    {
        public int RoomItemId { get; set; }
        public int RoomNumber { get; set; }
        public int ItemId { get; set; }
        public DateTime RoomItemDatetime { get; set; }

        public virtual LkpItems Item { get; set; }
        public virtual TblRooms RoomNumberNavigation { get; set; }
    }
}
