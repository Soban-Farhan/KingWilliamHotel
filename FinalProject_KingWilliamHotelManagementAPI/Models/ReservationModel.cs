using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KingWilliamHotelManagementAPI.Models
{
    public class ReservationModel
    {

        [Required]
        [DisplayName("First:")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last:")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Street Number:")]
        [Range(1,300)]
        public int StreetNumber { get; set; }

        [Required]
        [DisplayName("Street Name:")]
        public string StreetName { get; set; }

        [Required]
        [DisplayName("City:")]
        public string City { get; set; }

        [Required]
        [DisplayName("Postal Code:")]
        [StringLength(6, ErrorMessage ="Postal Code not valid", MinimumLength = 6)]
        public virtual string PostalCode { get; set; }

        [Required]
        [DisplayName("Country:")]
        public string Country { get; set; }

        [Required]
        [DisplayName("Phone:")]
        public string PhoneNumber { get; set; }
        
        
        [DisplayName("Email Address:")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [DisplayName("Arrival Date:")]
        public DateTime ExpectedArrivalDate { get; set; }

        [Required]
        [DisplayName("Leave Date:")]
        public DateTime ExpectedLeaveDate { get; set; }

        [Required]
        [DisplayName("Reservation Notes:")]
        public string Notes { get; set; }
    }
}
