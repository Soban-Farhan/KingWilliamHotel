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

        [Required(ErrorMessage = "Please enter your first name.")]
        [DisplayName("First:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        [DisplayName("Last:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your house number.")]
        [DisplayName("Street or Apt #:")]
        [Range(1,9999)]
        public int StreetNumber { get; set; }

        [Required(ErrorMessage = "Please enter your house address.")]
        [DisplayName("Street or Apt Name:")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "Please enter a Postal Code.")]
        [DisplayName("Postal Code:")]
        [StringLength(6, ErrorMessage ="Invalid Postal Code.", MinimumLength = 6)]
        public virtual string PostalCode { get; set; }

        [Required(ErrorMessage = "Please enter your city.")]
        [DisplayName("City:")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your country.")]
        [DisplayName("Country:")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        [DisplayName("Phone:")]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [DisplayName("Email Address:")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please enter your country.")]
        [DisplayName("Check in:")]
        public DateTime ExpectedArrivalDate { get; set; }

        [Required]
        [DisplayName("Check out:")]
        public DateTime? ExpectedLeaveDate { get; set; }

        [Required]
        [DisplayName("Available Room: ")]
        public int RoomNumber { get; set; }

        [DisplayName("Reservation Notes:")]
        public string Notes { get; set; }

        public int PersonID { get; set; }

        public int ReservationID { get; set; }
    }
}
