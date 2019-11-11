using System;
using System.Collections.Generic;

namespace KingWilliamHotelManagementAPI.Models
{
    public partial class TblOrder
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int QuantityOrdered { get; set; }
        public DateTime OrderDateTime { get; set; }
        public int? QuantityReceived { get; set; }
        public DateTime? ReceivedDateTime { get; set; }

        public virtual LkpItems Item { get; set; }
    }
}
