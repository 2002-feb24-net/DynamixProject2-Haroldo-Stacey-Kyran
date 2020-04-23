using Dynamix.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dynamix.API.Interfaces
{
    public interface IUsersRepository
    {
        

        public void Add(Users entity);

        public void AddRange(IEnumerable<Users> entities);

        public IEnumerable<Users> Find(int id)
        ;

        public IEnumerable<Users> Find(Expression<Func<Users, bool>> predicate, string includeName) // only include one navigational property
        ;

        public IEnumerable<Users> Find(Expression<Func<Users, bool>> predicate, string includeNameFirst, string includeNameSecond) //  include two navigational properties
        ;

        public IEnumerable<Users> Find(Expression<Func<Users, bool>> predicate, string includeNameFirst, string includeNameSecond, string includeNameThird) //  include three navigational properties
        ;

        public IEnumerable<Users> Find(Expression<Func<Users, bool>> predicate);

        /// <summary>
        /// async functions require bodies. EF Core FindAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Users> FindAsync(int id)
        ;

        public Users Get(int id);

        public Task<IEnumerable<Users>> GetAll();

        /// <summary>
        /// same as get all. Returns a list
        /// </summary>
        /// <returns></returns>
        public  Task<IEnumerable<Users>> ToListAsync()
        ;

        public void Remove(Users entity);

        public void RemoveRange(IEnumerable<Users> entities);

        public bool Any(Expression<Func<Users, bool>> predicate);

        // need to implement a put method but it requires indepth knowledge of how entity state works

        public void Save();

        /// <summary>
        /// Implementation (wraps SaveChangesAsync from Entity Framework in case their methods change. Centralized place here to update their saveasync for example)
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveChangesAsync();
    }

}