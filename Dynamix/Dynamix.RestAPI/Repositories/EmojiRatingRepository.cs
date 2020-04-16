using Dynamix.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dynamix.API.Repositories
{
    public class EmojiRatingRepository : Repository<EmojiRating>
    {
        DbDynamixContext context;
        public EmojiRatingRepository(DbDynamixContext context)
        {
            this.context = context;
        }
    }
}
