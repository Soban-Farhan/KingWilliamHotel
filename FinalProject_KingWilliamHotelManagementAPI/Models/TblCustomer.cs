using System;
using System.Collections.Generic;

namespace KingWilliamHotelManagementAPI.Models
{
    public partial class TblCustomer
    {
        public TblCustomer()
        {
            TblGuestStay = new HashSet<TblGuestStay>();
        }

        public int CustomerId { get; set; }
        public int CreditCardNumber { get; set; }

        public virtual LkpCreditCard CreditCardNumberNavigation { get; set; }
        public virtual TblPerson Customer { get; set; }
        public virtual ICollection<TblGuestStay> TblGuestStay { get; set; }
    }
}
