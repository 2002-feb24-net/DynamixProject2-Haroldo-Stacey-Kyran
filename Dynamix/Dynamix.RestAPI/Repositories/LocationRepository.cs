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
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        DbDynamixContext _context;
        public LocationRepository(DbDynamixContext context)
        {
            this._context = context;
        }

        public void Add(Location entity)
        {
            _context.Set<Location>().Add(entity);
        }

        public void AddRange(IEnumerable<Location> entities)
        {
            _context.Set<Location>().AddRange(entities);
        }

        public IEnumerable<Location> Find(int id)
        {
            yield return _context.Set<Location>().Find(id);
        }

        public IEnumerable<Location> Find(Expression<Func<Location, bool>> predicate, string includeName) // only include one navigational property
        {
            return _context.Set<Location>().Where(predicate).Include($"{includeName}");
        }

        public IEnumerable<Location> Find(Expression<Func<Location, bool>> predicate, string includeNameFirst, string includeNameSecond) //  include two navigational properties
        {
            return _context.Set<Location>().Where(predicate).Include($"{includeNameFirst}").Include($"{includeNameSecond}");
        }

        public IEnumerable<Location> Find(Expression<Func<Location, bool>> predicate, string includeNameFirst, string includeNameSecond, string includeNameThird) //  include three navigational properties
        {
            return _context.Set<Location>().Where(predicate).Include($"{includeNameFirst}").Include($"{includeNameSecond}").Include($"{includeNameThird}");
        }

        public IEnumerable<Location> Find(Expression<Func<Location, bool>> predicate)
        {
            return _context.Set<Location>().Where(predicate);
        }

        public async Task<Location> FindAsync(int id)
        {
            return await _context.Set<Location>().FindAsync(id);
        }

        public Location Get(int id)
        {
            return _context.Set<Location>().Find(id); //return single object of class
        }

        public async Task<IEnumerable<Location>> GetAll()
        {
            return await _context.Set<Location>().ToListAsync();
        }

        /// <summary>
        /// same as get all. Returns a list
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Location>> ToListAsync()
        {
            return await _context.Set<Location>().ToListAsync();
        }

        public void Remove(Location entity)
        {
            _context.Set<Location>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<Location> entities)
        {
            _context.Set<Location>().RemoveRange(entities);
        }

        public bool Any(Expression<Func<Location, bool>> predicate)
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
