using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KingWilliamHotelManagementAPI.Models
{
    public class EmployeeModel
    {
        [Required(ErrorMessage = "Please enter employee's first name.")]
        [DisplayName("First:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter employee's last name.")]
        [DisplayName("Last:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter employee's house number.")]
        [DisplayName("Street or Apt #:")]
        [Range(1, 9999)]
        public int StreetNumber { get; set; }

        [Required(ErrorMessage = "Please enter employee's house address.")]
        [DisplayName("Street or Apt Name:")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "Please enter employee's Postal Code.")]
        [DisplayName("Postal Code:")]
        [StringLength(6, ErrorMessage = "Invalid Postal Code.", MinimumLength = 6)]
        public virtual string PostalCode { get; set; }

        [Required(ErrorMessage = "Please enter employee's city.")]
        [DisplayName("City:")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter employee's country.")]
        [DisplayName("Country:")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter employee's phone number.")]
        [DisplayName("Phone:")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter employee's email address.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [DisplayName("Email Address & Username:")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please enter employee's emergency number.")]
        [DisplayName("Emergency Contact Number:")]
        public string EmergencyContactNumber { get; set; }

        [Required(ErrorMessage = "Please enter employee's emergency contact name.")]
        [DisplayName("Emergency Contact Name:")]
        public string EmergencyContactName { get; set; }

        [Required(ErrorMessage = "Please select employee's position.")]
        [DisplayName("Position: ")]
        public int Position { get; set; }

        public int PersonID { get; set; }
    }
}
