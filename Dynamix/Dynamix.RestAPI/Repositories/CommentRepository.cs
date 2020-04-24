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
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        DbDynamixContext _context;
        public CommentRepository(DbDynamixContext context)
        {
            this._context = context;
        }

        public void Add(Comment entity)
        {
            _context.Set<Comment>().Add(entity);
        }

        public void AddRange(IEnumerable<Comment> entities)
        {
            _context.Set<Comment>().AddRange(entities);
        }

        public IEnumerable<Comment> Find(int id)
        {
            yield return _context.Set<Comment>().Find(id);
        }

        public IEnumerable<Comment> Find(Expression<Func<Comment, bool>> predicate, string includeName) // only include one navigational property
        {
            return _context.Set<Comment>().Where(predicate).Include($"{includeName}");
        }

        public IEnumerable<Comment> Find(Expression<Func<Comment, bool>> predicate, string includeNameFirst, string includeNameSecond) //  include two navigational properties
        {
            return _context.Set<Comment>().Where(predicate).Include($"{includeNameFirst}").Include($"{includeNameSecond}");
        }

        public IEnumerable<Comment> Find(Expression<Func<Comment, bool>> predicate, string includeNameFirst, string includeNameSecond, string includeNameThird) //  include three navigational properties
        {
            return _context.Set<Comment>().Where(predicate).Include($"{includeNameFirst}").Include($"{includeNameSecond}").Include($"{includeNameThird}");
        }

        public IEnumerable<Comment> Find(Expression<Func<Comment, bool>> predicate)
        {
            return _context.Set<Comment>().Where(predicate);
        }

        public async Task<Comment> FindAsync(int id)
        {
            return await _context.Set<Comment>().FindAsync(id);
        }

        public Comment Get(int id)
        {
            return _context.Set<Comment>().Find(id); //return single object of class
        }

        public async Task<IEnumerable<Comment>> GetAll()
        {
            return await _context.Set<Comment>().ToListAsync();
        }

        /// <summary>
        /// same as get all. Returns a list
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Comment>> ToListAsync()
        {
            return await _context.Set<Comment>().ToListAsync();
        }

        public void Remove(Comment entity)
        {
            _context.Set<Comment>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<Comment> entities)
        {
            _context.Set<Comment>().RemoveRange(entities);
        }

        public bool Any(Expression<Func<Comment, bool>> predicate)
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
