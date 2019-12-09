using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingWilliamHotelManagementAPI.Models
{
    public class InvoiceModel
    {
        public TblPerson TblPerson { get; set; }

        public TblRooms TblRooms { get; set; }

        public TblGuestStay TblGuestStay { get; set; }

        public TblGuestInvoice TblGuestInvoice { get; set; }

        public List<TblGuestLineItems> TblGuestLineItems { get; set; }
    }
}
