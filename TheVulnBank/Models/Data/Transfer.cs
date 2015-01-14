using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheVulnBank.Models.Data
{
    public class Transfer
    {
        public int Id { get; set; }
        public int SendAccId { get; set; }
        public int RecAccId { get; set; }
        public double Amount { get; set; }
        public string Message { get; set; }
    }
}