using System;
using System.Collections.Generic;

namespace KingWilliamHotelManagementAPI.Models
{
    public partial class TblPerson
    {
        public TblPerson()
        {
            TblReservation = new HashSet<TblReservation>();
        }

        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public virtual TblCustomer TblCustomer { get; set; }
        public virtual TblEmployee TblEmployee { get; set; }
        public virtual ICollection<TblReservation> TblReservation { get; set; }
    }
}
