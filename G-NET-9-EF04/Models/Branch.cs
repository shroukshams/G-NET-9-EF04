using System;
using System.Collections.Generic;
using System.Text;

namespace G_NET_9_EF04.Models
{
    public class Branch
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Manger mangerBranch { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
