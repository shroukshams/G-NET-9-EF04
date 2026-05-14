using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace G_NET_9_EF04.Models
{
    public class AccountCustomer
    {
        public string OwnershipType { get; set; }
        public DateTime OwnerStartDate { get; set; }
        public string AccountStuatus { get; set; }
        public Account Account { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey(nameof(Account))]
         public int AccountId { get; set; }
        public int CustomerId { get; set; }


    }
}
