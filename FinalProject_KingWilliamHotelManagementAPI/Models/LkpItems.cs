using System;
using System.Collections.Generic;

namespace KingWilliamHotelManagementAPI.Models
{
    public partial class LkpItems
    {
        public LkpItems()
        {
            JncMenuIngredients = new HashSet<JncMenuIngredients>();
            TblChargeableItems = new HashSet<TblChargeableItems>();
            TblGuestLineItems = new HashSet<TblGuestLineItems>();
            TblOrder = new HashSet<TblOrder>();
            TblRoomItems = new HashSet<TblRoomItems>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int? QuantityOnHand { get; set; }

        public virtual ICollection<JncMenuIngredients> JncMenuIngredients { get; set; }
        public virtual ICollection<TblChargeableItems> TblChargeableItems { get; set; }
        public virtual ICollection<TblGuestLineItems> TblGuestLineItems { get; set; }
        public virtual ICollection<TblOrder> TblOrder { get; set; }
        public virtual ICollection<TblRoomItems> TblRoomItems { get; set; }
    }
}
