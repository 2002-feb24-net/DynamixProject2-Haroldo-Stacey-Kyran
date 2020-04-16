using Dynamix.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dynamix.API.Repositories
{
    public class UserRepository : Repository<User>
    {
        DbDynamixContext context;
        public UserRepository (DbDynamixContext context)
        {
            this.context = context;
        }
    }
}
