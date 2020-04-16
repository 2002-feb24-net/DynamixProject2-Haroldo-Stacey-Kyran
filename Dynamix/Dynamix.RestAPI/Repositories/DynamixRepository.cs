using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dynamix.API.Models;

namespace Dynamix.API.Repositories
{
    public class DynamixRepository
    {
            private readonly List<User> _user;
            private readonly List<Review> _review;
            private readonly List<EmojiRating> _eRating;
            private readonly List<Location> _location;
            private readonly List<LocationVisitor> _locVisitor;
            private readonly List<Comment> _comment;
        public DynamixRepository()
        {
                        
        }
    }
}
