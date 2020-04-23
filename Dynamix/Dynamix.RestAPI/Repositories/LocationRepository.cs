using Dynamix.API.Interfaces;
using Dynamix.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dynamix.API.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        DbDynamixContext context;
        public LocationRepository(DbDynamixContext context)
        {
            this.context = context;
        }

        public DbDynamixContext Context => context;

    }
}
