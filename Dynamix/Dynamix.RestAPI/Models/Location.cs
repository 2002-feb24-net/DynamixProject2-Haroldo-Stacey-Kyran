using System;
using System.Collections.Generic;

namespace Dynamix.API.Models
{
    public partial class Location
    {
        public Location()
        {
            LocationVisitor = new HashSet<LocationVisitor>();
            Review = new HashSet<Review>();
        }

        public int LocationId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual ICollection<LocationVisitor> LocationVisitor { get; set; }
        public virtual ICollection<Review> Review { get; set; }
    }
}
