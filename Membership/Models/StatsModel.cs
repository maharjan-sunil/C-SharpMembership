using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Membership.Models
{
    public class StatsModel
    {
        public decimal Min { get; set; }
        public decimal Max { get; set; }
        public decimal Avg { get; set; }
        public decimal Count { get; set; }
        public decimal Sum { get; set; }

    }
}