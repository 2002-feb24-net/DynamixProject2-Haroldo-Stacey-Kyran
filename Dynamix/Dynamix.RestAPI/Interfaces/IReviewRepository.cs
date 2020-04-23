using Dynamix.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dynamix.API.Interfaces
{
    public interface IReviewRepository
    {

        public void Add(Review entity);

        public void AddRange(IEnumerable<Review> entities);

        public IEnumerable<Review> Find(int id)
        ;

        public IEnumerable<Review> Find(Expression<Func<Review, bool>> predicate, string includeName) // only include one navigational property
        ;

        public IEnumerable<Review> Find(Expression<Func<Review, bool>> predicate, string includeNameFirst, string includeNameSecond) //  include two navigational properties
        ;

        public IEnumerable<Review> Find(Expression<Func<Review, bool>> predicate, string includeNameFirst, string includeNameSecond, string includeNameThird) //  include three navigational properties
        ;

        public IEnumerable<Review> Find(Expression<Func<Review, bool>> predicate);

        /// <summary>
        /// async functions require bodies. EF Core FindAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Review> FindAsync(int id)
        ;

        public Review Get(int id);

        public Task<IEnumerable<Review>> GetAll();

        /// <summary>
        /// same as get all. Returns a list
        /// </summary>
        /// <returns></returns>
        public  Task<IEnumerable<Review>> ToListAsync()
        ;

        public void Remove(Review entity);

        public void RemoveRange(IEnumerable<Review> entities);

        public bool Any(Expression<Func<Review, bool>> predicate);

        // need to implement a put method but it requires indepth knowledge of how entity state works

        public void Save();

        /// <summary>
        /// Implementation (wraps SaveChangesAsync from Entity Framework in case their methods change. Centralized place here to update their saveasync for example)
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveChangesAsync();
    }
}
