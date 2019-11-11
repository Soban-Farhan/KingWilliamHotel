using System;
using System.Collections.Generic;

namespace KingWilliamHotelManagementAPI.Models
{
    public partial class TblGuestInvoice
    {
        public int InvoiceId { get; set; }
        public int GuestStayId { get; set; }
        public DateTime InvoiceDateTime { get; set; }

        public virtual TblGuestStay GuestStay { get; set; }
    }
}
