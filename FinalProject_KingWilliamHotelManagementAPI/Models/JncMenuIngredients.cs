using System;
using System.Collections.Generic;

namespace KingWilliamHotelManagementAPI.Models
{
    public partial class JncMenuIngredients
    {
        public int MenuOptionId { get; set; }
        public int ItemId { get; set; }
        public int QuantityNeeded { get; set; }

        public virtual LkpItems Item { get; set; }
        public virtual TblMenu MenuOption { get; set; }
    }
}
