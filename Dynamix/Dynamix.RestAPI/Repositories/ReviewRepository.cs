using Dynamix.API.Interfaces;
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
        DbDynamixContext _context;
        public ReviewRepository(DbDynamixContext context)
        {
            this._context = context;
        }

        public void Add(Review entity)
        {
            _context.Set<Review>().Add(entity);
        }

        public void AddRange(IEnumerable<Review> entities)
        {
            _context.Set<Review>().AddRange(entities);
        }

        public IEnumerable<Review> Find(int id)
        {
            yield return _context.Set<Review>().Find(id);
        }

        public IEnumerable<Review> Find(Expression<Func<Review, bool>> predicate, string includeName) // only include one navigational property
        {
            return _context.Set<Review>().Where(predicate).Include($"{includeName}");
        }

        public IEnumerable<Review> Find(Expression<Func<Review, bool>> predicate, string includeNameFirst, string includeNameSecond) //  include two navigational properties
        {
            return _context.Set<Review>().Where(predicate).Include($"{includeNameFirst}").Include($"{includeNameSecond}");
        }

        public IEnumerable<Review> Find(Expression<Func<Review, bool>> predicate, string includeNameFirst, string includeNameSecond, string includeNameThird) //  include three navigational properties
        {
            return _context.Set<Review>().Where(predicate).Include($"{includeNameFirst}").Include($"{includeNameSecond}").Include($"{includeNameThird}");
        }

        public IEnumerable<Review> Find(Expression<Func<Review, bool>> predicate)
        {
            return _context.Set<Review>().Where(predicate);
        }

        public async Task<Review> FindAsync(int id)
        {
            return await _context.Set<Review>().FindAsync(id);
        }

        public Review Get(int id)
        {
            return _context.Set<Review>().Find(id); //return single object of class
        }

        public async Task<IEnumerable<Review>> GetAll()
        {
            return await _context.Set<Review>().ToListAsync();
        }

        /// <summary>
        /// same as get all. Returns a list
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Review>> ToListAsync()
        {
            return await _context.Set<Review>().ToListAsync();
        }

        public void Remove(Review entity)
        {
            _context.Set<Review>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<Review> entities)
        {
            _context.Set<Review>().RemoveRange(entities);
        }

        public bool Any(Expression<Func<Review, bool>> predicate)
        {
            var entity = Find(predicate);
            if (entity == null)
            {
                return false;
            }
            else
                return true;    // there is something
        }

        // need to implement a put method but it requires indepth knowledge of how entity state works

        public void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Implementation (wraps SaveChangesAsync from Entity Framework in case their methods change. Centralized place here to update their saveasync for example)
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
