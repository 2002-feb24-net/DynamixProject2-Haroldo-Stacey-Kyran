using Dynamix.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dynamix.API.Interfaces
{
    public interface ILocationRepository
    {


        public void Add(Location entity);

        public void AddRange(IEnumerable<Location> entities);

        public IEnumerable<Location> Find(int id)
        ;

        public IEnumerable<Location> Find(Expression<Func<Location, bool>> predicate, string includeName) // only include one navigational property
        ;

        public IEnumerable<Location> Find(Expression<Func<Location, bool>> predicate, string includeNameFirst, string includeNameSecond) //  include two navigational properties
        ;

        public IEnumerable<Location> Find(Expression<Func<Location, bool>> predicate, string includeNameFirst, string includeNameSecond, string includeNameThird) //  include three navigational properties
        ;

        public IEnumerable<Location> Find(Expression<Func<Location, bool>> predicate);

        /// <summary>
        /// async functions require bodies. EF Core FindAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Location> FindAsync(int id);

        public Location Get(int id);

        public Task<IEnumerable<Location>> GetAll();

        /// <summary>
        /// same as get all. Returns a list
        /// </summary>
        /// <returns></returns>
        public  Task<IEnumerable<Location>> ToListAsync()
        ;

        public void Remove(Location entity);

        public void RemoveRange(IEnumerable<Location> entities);

        public bool Any(Expression<Func<Location, bool>> predicate);

        // need to implement a put method but it requires indepth knowledge of how entity state works

        public void Save();

        /// <summary>
        /// Implementation (wraps SaveChangesAsync from Entity Framework in case their methods change. Centralized place here to update their saveasync for example)
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveChangesAsync();
    }

}
