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
    public class EmojiRatingRepository : Repository<EmojiRating>, IEmojiRatingRepository
    {
        DbDynamixContext _context;
        public EmojiRatingRepository(DbDynamixContext context)
        {
            this._context = context;
        }

        public void Add(EmojiRating entity)
        {
            _context.Set<EmojiRating>().Add(entity);
        }

        public void AddRange(IEnumerable<EmojiRating> entities)
        {
            _context.Set<EmojiRating>().AddRange(entities);
        }

        public IEnumerable<EmojiRating> Find(int id)
        {
            yield return _context.Set<EmojiRating>().Find(id);
        }

        public IEnumerable<EmojiRating> Find(Expression<Func<EmojiRating, bool>> predicate, string includeName) // only include one navigational property
        {
            return _context.Set<EmojiRating>().Where(predicate).Include($"{includeName}");
        }

        public IEnumerable<EmojiRating> Find(Expression<Func<EmojiRating, bool>> predicate, string includeNameFirst, string includeNameSecond) //  include two navigational properties
        {
            return _context.Set<EmojiRating>().Where(predicate).Include($"{includeNameFirst}").Include($"{includeNameSecond}");
        }

        public IEnumerable<EmojiRating> Find(Expression<Func<EmojiRating, bool>> predicate, string includeNameFirst, string includeNameSecond, string includeNameThird) //  include three navigational properties
        {
            return _context.Set<EmojiRating>().Where(predicate).Include($"{includeNameFirst}").Include($"{includeNameSecond}").Include($"{includeNameThird}");
        }

        public IEnumerable<EmojiRating> Find(Expression<Func<EmojiRating, bool>> predicate)
        {
            return _context.Set<EmojiRating>().Where(predicate);
        }

        public async Task<EmojiRating> FindAsync(int id)
        {
            return await _context.Set<EmojiRating>().FindAsync(id);
        }

        public EmojiRating Get(int id)
        {
            return _context.Set<EmojiRating>().Find(id); //return single object of class
        }

        public async Task<IEnumerable<EmojiRating>> GetAll()
        {
            return await _context.Set<EmojiRating>().ToListAsync();
        }

        /// <summary>
        /// same as get all. Returns a list
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EmojiRating>> ToListAsync()
        {
            return await _context.Set<EmojiRating>().ToListAsync();
        }

        public void Remove(EmojiRating entity)
        {
            _context.Set<EmojiRating>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<EmojiRating> entities)
        {
            _context.Set<EmojiRating>().RemoveRange(entities);
        }

        public bool Any(Expression<Func<EmojiRating, bool>> predicate)
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
