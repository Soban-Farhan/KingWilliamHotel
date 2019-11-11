using System;
using System.Collections.Generic;

namespace KingWilliamHotelManagementAPI.Models
{
    public partial class TblChargeableItems
    {
        public TblChargeableItems()
        {
            TblMenu = new HashSet<TblMenu>();
        }

        public int ChargeableItemId { get; set; }
        public int ItemId { get; set; }
        public decimal Price { get; set; }

        public virtual LkpItems Item { get; set; }
        public virtual ICollection<TblMenu> TblMenu { get; set; }
    }
}
