using System;
using System.Collections.Generic;

namespace KingWilliamHotelManagementAPI.Models
{
    public partial class LkpPositionTypes
    {
        public LkpPositionTypes()
        {
            TblPosition = new HashSet<TblPosition>();
        }

        public int PositionId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TblPosition> TblPosition { get; set; }
    }
}
