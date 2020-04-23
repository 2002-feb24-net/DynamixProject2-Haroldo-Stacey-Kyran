using Dynamix.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dynamix.API.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {

        public void Add(TEntity entity);

        public void AddRange(IEnumerable<TEntity> entities);

        public IEnumerable<TEntity> Find(int id)
        ;

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, string includeName) // only include one navigational property
        ;

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, string includeNameFirst, string includeNameSecond) //  include two navigational properties
        ;

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, string includeNameFirst, string includeNameSecond, string includeNameThird) //  include three navigational properties
        ;

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// async functions require bodies. EF Core FindAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  Task<TEntity> FindAsync(int id);

        public TEntity Get(int id);

        public Task<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// same as get all. Returns a list
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<TEntity>> ToListAsync()
        ;

        public void Remove(TEntity entity);

        public void RemoveRange(IEnumerable<TEntity> entities);

        public bool Any(Expression<Func<TEntity, bool>> predicate);

        // need to implement a put method but it requires indepth knowledge of how entity state works

        public void Save();

        /// <summary>
        /// Implementation (wraps SaveChangesAsync from Entity Framework in case their methods change. Centralized place here to update their saveasync for example)
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveChangesAsync();
    }

}