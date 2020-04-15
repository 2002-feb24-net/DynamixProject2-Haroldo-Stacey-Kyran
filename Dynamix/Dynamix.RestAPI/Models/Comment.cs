using System;
using System.Collections.Generic;

namespace Dynamix.API.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public int ReviewId { get; set; }
        public int UserId { get; set; }

        public virtual Review Review { get; set; }
        public virtual User User { get; set; }
    }
}
