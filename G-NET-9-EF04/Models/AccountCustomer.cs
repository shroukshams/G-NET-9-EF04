using System;
using System.Collections.Generic;
using System.Text;

namespace G_NET_9_EF04.Models
{
    public class AccountCustomer
    {
        public string OwnershipType { get; set; }
        public DateTime OwnerStartDate { get; set; }
        public bool AccountStuatus { get; set; }
        public Account Account { get; set; }
        public Customer Customer { get; set; }
         public int AccountId { get; set; }
        public int CustomerId { get; set; }


    }
}
