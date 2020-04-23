﻿using Dynamix.API.Interfaces;
using Dynamix.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dynamix.API.Repositories
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        DbDynamixContext context;
        public ReviewRepository(DbDynamixContext context)
        {
            this.context = context;
        }

        public DbDynamixContext Context => context;

    }
}
