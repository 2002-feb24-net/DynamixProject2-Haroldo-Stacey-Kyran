using Dynamix.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dynamix.API.Repositories
{
    public class ReviewRepository : Repository<User>
    {
        DbDynamixContext context;
        public ReviewRepository(DbDynamixContext context)
        {
            this.context = context;
        }
    }
}
