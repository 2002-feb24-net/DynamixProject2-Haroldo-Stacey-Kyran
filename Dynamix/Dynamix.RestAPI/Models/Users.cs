﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dynamix.API.Models
{
    public partial class Users
    {
        public Users()
        {
            Comment = new HashSet<Comment>();
            LocationVisitor = new HashSet<LocationVisitor>();
            Review = new HashSet<Review>();
        }

        public int UserId { get; set; }
        public string FullName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<LocationVisitor> LocationVisitor { get; set; }
        public virtual ICollection<Review> Review { get; set; }
    }
}