using System;
using System.Collections.Generic;
using System.Text;

namespace G_NET_9_EF04.Models
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string? AccountType  { get; set; }
        public DateTime OpenDate { get; set; }
        public Branch BranchAccount { get; set; }
        public List<Transaction> TransactionList { get; set; }
        public List<AccountCustomer> AccountCustomers { get; set; }
        //[ForeignKey("BranchAccount")]
        public int BranchId { get; set; }
    }
}
