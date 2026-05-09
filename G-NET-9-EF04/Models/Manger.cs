using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace G_NET_9_EF04.Models
{
    public class Manger
    {


        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public Branch BranchManger { get; set; }
        public int BranchCode { get; set; }


    }
}
