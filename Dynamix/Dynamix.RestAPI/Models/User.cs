using System;
using System.Collections.Generic;

namespace Dynamix.API.Models
{
    public partial class User
    {
        public User()
        {
            Comment = new HashSet<Comment>();
            LocationVisitor = new HashSet<LocationVisitor>();
            Review = new HashSet<Review>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<LocationVisitor> LocationVisitor { get; set; }
        public virtual ICollection<Review> Review { get; set; }
    }
}
