using Dynamix.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dynamix.API.Repositories
{
    public class CommentRepository : Repository<Comment>
    {
        DbDynamixContext context;
        public CommentRepository(DbDynamixContext context)
        {
            this.context = context;
        }
    }
}
