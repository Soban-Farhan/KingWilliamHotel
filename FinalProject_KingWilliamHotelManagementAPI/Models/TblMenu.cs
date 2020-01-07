using System;
using System.Collections.Generic;

namespace KingWilliamHotelManagementAPI.Models
{
    public partial class TblMenu
    {
        public TblMenu()
        {
            JncMenuIngredients = new HashSet<JncMenuIngredients>();
        }

        public int MenuOptionId { get; set; }
        public int ChargeableItemId { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; }

        public virtual TblChargeableItems ChargeableItem { get; set; }
        public virtual ICollection<JncMenuIngredients> JncMenuIngredients { get; set; }
    }
}
