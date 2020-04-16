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

        private readonly DbDynamixContext context;

        public CommentRepository commentRepo;
        public EmojiRatingRepository emojiRRepo;
        public LocationRepository locationRepo;
        public LocationVisitorRepository locationVisitorRepo;
        public ReviewRepository reviewRepo;
        public UserRepository userRepo;
        public DynamixRepository(
            DbDynamixContext context
            )
        {
            // initialize all repos so they cannot go out of sync
            // use dependency injection
            commentRepo = new CommentRepository(context);
            emojiRRepo = new EmojiRatingRepository(context);
            locationRepo = new LocationRepository(context);
            reviewRepo = new ReviewRepository(context);
            userRepo = new UserRepository(context);

        }
    }
}
