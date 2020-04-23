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
    public class UserRepository : IUsersRepository
    {
        DbDynamixContext _context;
        public UserRepository (DbDynamixContext context)
        {
            this._context = context;
        }

        public void Add(Users entity)
        {
            _context.Set<Users>().Add(entity);
        }

        public void AddRange(IEnumerable<Users> entities)
        {
            _context.Set<Users>().AddRange(entities);
        }

        public IEnumerable<Users> Find(int id)
        {
            yield return _context.Set<Users>().Find(id);
        }

        public IEnumerable<Users> Find(Expression<Func<Users, bool>> predicate, string includeName) // only include one navigational property
        {
            return _context.Set<Users>().Where(predicate).Include($"{includeName}");
        }

        public IEnumerable<Users> Find(Expression<Func<Users, bool>> predicate, string includeNameFirst, string includeNameSecond) //  include two navigational properties
        {
            return _context.Set<Users>().Where(predicate).Include($"{includeNameFirst}").Include($"{includeNameSecond}");
        }

        public IEnumerable<Users> Find(Expression<Func<Users, bool>> predicate, string includeNameFirst, string includeNameSecond, string includeNameThird) //  include three navigational properties
        {
            return _context.Set<Users>().Where(predicate).Include($"{includeNameFirst}").Include($"{includeNameSecond}").Include($"{includeNameThird}");
        }

        public IEnumerable<Users> Find(Expression<Func<Users, bool>> predicate)
        {
            return _context.Set<Users>().Where(predicate);
        }

        public async Task<Users> FindAsync(int id)
        {
            return await _context.Set<Users>().FindAsync(id);
        }

        public Users Get(int id)
        {
            return _context.Set<Users>().Find(id); //return single object of class
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
            return await _context.Set<Users>().ToListAsync();
        }

        /// <summary>
        /// same as get all. Returns a list
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Users>> ToListAsync()
        {
            return await _context.Set<Users>().ToListAsync();
        }

        public void Remove(Users entity)
        {
            _context.Set<Users>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<Users> entities)
        {
            _context.Set<Users>().RemoveRange(entities);
        }

        public bool Any(Expression<Func<Users, bool>> predicate)
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

