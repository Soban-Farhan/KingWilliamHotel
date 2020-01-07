using System;
using System.Collections.Generic;

namespace KingWilliamHotelManagementAPI.Models
{
    public partial class TblGuestStay
    {
        public TblGuestStay()
        {
            TblGuestInvoice = new HashSet<TblGuestInvoice>();
            TblGuestLineItems = new HashSet<TblGuestLineItems>();
        }

        public int GuestStayId { get; set; }
        public int CustomerId { get; set; }
        public int RoomNumber { get; set; }
        public DateTime StartDatetime { get; set; }
        public DateTime? EndDatetime { get; set; }

        public virtual TblCustomer Customer { get; set; }
        public virtual TblRooms RoomNumberNavigation { get; set; }
        public virtual ICollection<TblGuestInvoice> TblGuestInvoice { get; set; }
        public virtual ICollection<TblGuestLineItems> TblGuestLineItems { get; set; }
    }
}
