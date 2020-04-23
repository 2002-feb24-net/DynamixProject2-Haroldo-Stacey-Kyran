using Dynamix.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dynamix.API.Interfaces
{
    public interface ILocationVisitorRepository
    {

        public void Add(LocationVisitor entity);

        public void AddRange(IEnumerable<LocationVisitor> entities);

        public IEnumerable<LocationVisitor> Find(int id)
        ;

        public IEnumerable<LocationVisitor> Find(Expression<Func<LocationVisitor, bool>> predicate, string includeName) // only include one navigational property
        ;

        public IEnumerable<LocationVisitor> Find(Expression<Func<LocationVisitor, bool>> predicate, string includeNameFirst, string includeNameSecond) //  include two navigational properties
        ;

        public IEnumerable<LocationVisitor> Find(Expression<Func<LocationVisitor, bool>> predicate, string includeNameFirst, string includeNameSecond, string includeNameThird) //  include three navigational properties
        ;

        public IEnumerable<LocationVisitor> Find(Expression<Func<LocationVisitor, bool>> predicate);

        /// <summary>
        /// async functions require bodies. EF Core FindAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<LocationVisitor> FindAsync(int id)
        ;

        public LocationVisitor Get(int id);

        public Task<IEnumerable<LocationVisitor>> GetAll();

        /// <summary>
        /// same as get all. Returns a list
        /// </summary>
        /// <returns></returns>
        public  Task<IEnumerable<LocationVisitor>> ToListAsync()
        ;

        public void Remove(LocationVisitor entity);

        public void RemoveRange(IEnumerable<LocationVisitor> entities);

        public bool Any(Expression<Func<LocationVisitor, bool>> predicate);

        // need to implement a put method but it requires indepth knowledge of how entity state works

        public void Save();

        /// <summary>
        /// Implementation (wraps SaveChangesAsync from Entity Framework in case their methods change. Centralized place here to update their saveasync for example)
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveChangesAsync();
    }
}