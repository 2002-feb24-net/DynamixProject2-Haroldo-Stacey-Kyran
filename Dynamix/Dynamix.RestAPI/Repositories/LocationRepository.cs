using Dynamix.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dynamix.API.Repositories
{
    public class LocationRepository : Repository<Location>
    {
        DbDynamixContext context;
        public LocationRepository(DbDynamixContext context)
        {
            this.context = context;
        }
    }
}
