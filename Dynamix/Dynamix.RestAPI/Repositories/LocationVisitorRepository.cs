using Dynamix.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dynamix.API.Repositories
{
    public class LocationVisitorRepository : Repository<LocationVisitor>
    {
        DbDynamixContext context;
        public LocationVisitorRepository(DbDynamixContext context)
        {
            this.context = context;
        }
    }
}
