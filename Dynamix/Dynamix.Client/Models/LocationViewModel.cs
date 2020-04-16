using Dynamix.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dynamix.Client.Models
{
    public class LocationViewModel
    {
        public LocationViewModel()
        {
        }

        public LocationViewModel(Location loc)
        {
            LocationId = loc.LocationId;
            City = loc.City;
            State = loc.State;
            Country = loc.Country;
        }

        public int LocationId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public List<LocationVisitor> locVisit { get; set; }
    }
}
