using System;
using System.Collections.Generic;

namespace Dynamix.API.Models
{
    public partial class EmojiRating
    {
        public EmojiRating()
        {
            Review = new HashSet<Review>();
        }

        public int EmojiRatingId { get; set; }
        public byte[] EmojiPicture { get; set; }

        public virtual ICollection<Review> Review { get; set; }
    }
}
