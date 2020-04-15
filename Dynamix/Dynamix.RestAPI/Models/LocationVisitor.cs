using System;
using System.Collections.Generic;

namespace Dynamix.API.Models
{
    public partial class LocationVisitor
    {
        public int LocationVisitorId { get; set; }
        public int LocationId { get; set; }
        public int UserId { get; set; }
        public int ReviewId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Review Review { get; set; }
        public virtual User User { get; set; }
    }
}
