using System;
using System.Collections.Generic;

namespace Dynamix.API.Models
{
    public partial class Review
    {
        public Review()
        {
            Comment = new HashSet<Comment>();
            LocationVisitor = new HashSet<LocationVisitor>();
        }

        public int ReviewId { get; set; }
        public string Title { get; set; }
        public string ReviewText { get; set; }
        public string ReviewImageUrl { get; set; }
        public int RatingEmojiId { get; set; }
        public int LocationId { get; set; }
        public int CreatorUserId { get; set; }

        public virtual User CreatorUser { get; set; }
        public virtual Location Location { get; set; }
        public virtual EmojiRating RatingEmoji { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<LocationVisitor> LocationVisitor { get; set; }
    }
}
