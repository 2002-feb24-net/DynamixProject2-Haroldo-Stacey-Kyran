using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dynamix.API.Models;

namespace Dynamix.API.Repositories
{
    public class DynamixRepository
    {

        private readonly DbDynamixContext context;

        public CommentRepository commentRepo;
        public EmojiRatingRepository emojiRRepo;
        public LocationRepository locationRepo;
        public LocationVisitorRepository locationVisitorRepo;
        public ReviewRepository reviewRepo;
        public UserRepository userRepo;
        public DynamixRepository(DbDynamixContext context)
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
