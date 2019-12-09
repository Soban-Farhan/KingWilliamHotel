using System;
using System.Collections.Generic;

namespace KingWilliamHotelManagementAPI.Models
{
    public partial class LkpCreditCard
    {
        public LkpCreditCard()
        {
            TblCustomer = new HashSet<TblCustomer>();
        }

        public long CreditCardNumber { get; set; }
        public string CreditCardName { get; set; }
        public DateTime CreditCardExpiryDate { get; set; }

        public virtual ICollection<TblCustomer> TblCustomer { get; set; }
    }
}
