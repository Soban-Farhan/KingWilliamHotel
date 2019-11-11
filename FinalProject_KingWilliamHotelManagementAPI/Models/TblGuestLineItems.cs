using System;
using System.Collections.Generic;

namespace KingWilliamHotelManagementAPI.Models
{
    public partial class TblGuestLineItems
    {
        public int GuestLineItemId { get; set; }
        public int GuestStayId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateTime { get; set; }
        public decimal ItemPrice { get; set; }

        public virtual TblGuestStay GuestStay { get; set; }
        public virtual LkpItems Item { get; set; }
    }
}
