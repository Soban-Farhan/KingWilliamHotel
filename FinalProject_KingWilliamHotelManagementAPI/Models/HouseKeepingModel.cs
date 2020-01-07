using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KingWilliamHotelManagementAPI.Models
{
    public class HouseKeepingModel
    {
        public int houseKeepingId { get; set; }

        [Required]
        public int empID { get; set; }

        [Display(Name = "Employee Name: ")]
        public string employeeName { get; set; }

        [Display(Name = "Room #: ")]
        [Required]
        public int roomNumber { get; set; }

        [Display(Name = "House Keeping Time: ")]
        public DateTime houseKeepingDate { get; set; }
    }
}
