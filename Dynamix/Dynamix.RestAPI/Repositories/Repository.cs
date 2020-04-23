using Dynamix.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dynamix.API.Repositories
{

    public abstract class Repository<TEntity>  where TEntity : class
    {
        public DbDynamixContext _context = new DbDynamixContext();
        /*public Repository(DbDynamixContext context)
        {
            this._context = context;
            // dependency injection

        }*/
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }
        
        public IEnumerable<TEntity> Find (int id)
        {
            yield return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, string includeName) // only include one navigational property
        {
            return _context.Set<TEntity>().Where(predicate).Include($"{includeName}");
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, string includeNameFirst, string includeNameSecond) //  include two navigational properties
        {
            return _context.Set<TEntity>().Where(predicate).Include($"{includeNameFirst}").Include($"{includeNameSecond}");
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, string includeNameFirst, string includeNameSecond, string includeNameThird) //  include three navigational properties
        {
            return _context.Set<TEntity>().Where(predicate).Include($"{includeNameFirst}").Include($"{includeNameSecond}").Include($"{includeNameThird}");
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id); //return single object of class
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// same as get all. Returns a list
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> ToListAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
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
          return await  _context.SaveChangesAsync();
        }
    }

    




    /* public IEnumerable<TEntity> Include(TEntity predicate)
     {
         return _context.Set<TEntity>().Include("predicate");
     }*/

    /* public object Include(Func<object, object> p)
     {
         return _context.Set<TEntity>().Include(p => p.);
     }*/

    /*public IQueryable<T> Include<T>(params Expression<Func<T, object>>[] includes)
where T : class
    {
        if (includes != null)
        {
            _context = includes.Aggregate(_context,
                      (current, include) => current.Include(include));
        }

        return _context;
    }*/


    /* public IEnumerable<TEntity> Include(Expression<Func<TEntity>> predicate1, Expression<Func<TEntity>> predicate2)
     {
         return _context.Set<TEntity>().Include(predicate1).Include(predicate2);
     }*/
}



