using System;
using System.Collections.Generic;
using System.Text;

namespace G_NET_9_EF04.Models
{
    public class Transaction
    {
        public int TransactionNumber { get; set; }
        public DateTime TransactioDate {  get; set; }
        public string Amount { get; set; }
        public string Note { get; set; }
        public string TransactionType { get; set; }
        public Account AccountTransaction { get; set; }
        public int AccountId { get; set; }
    }
}
