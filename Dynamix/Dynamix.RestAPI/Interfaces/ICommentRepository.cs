using Dynamix.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dynamix.API.Interfaces
{
    public interface ICommentRepository
    {


        public void Add(Comment entity);

        public void AddRange(IEnumerable<Comment> entities);

        public IEnumerable<Comment> Find(int id)
        ;

        public IEnumerable<Comment> Find(Expression<Func<Comment, bool>> predicate, string includeName) // only include one navigational property
        ;

        public IEnumerable<Comment> Find(Expression<Func<Comment, bool>> predicate, string includeNameFirst, string includeNameSecond) //  include two navigational properties
        ;

        public IEnumerable<Comment> Find(Expression<Func<Comment, bool>> predicate, string includeNameFirst, string includeNameSecond, string includeNameThird) //  include three navigational properties
        ;

        public IEnumerable<Comment> Find(Expression<Func<Comment, bool>> predicate);

        /// <summary>
        /// async functions require bodies. EF Core FindAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  Task<Comment> FindAsync(int id)
        ;

        public Comment Get(int id);

        public Task<IEnumerable<Comment>> GetAll();

        /// <summary>
        /// same as get all. Returns a list
        /// </summary>
        /// <returns></returns>
        public  Task<IEnumerable<Comment>> ToListAsync()
        ;

        public void Remove(Comment entity);

        public void RemoveRange(IEnumerable<Comment> entities);

        public bool Any(Expression<Func<Comment, bool>> predicate);

        // need to implement a put method but it requires indepth knowledge of how entity state works

        public void Save();

        /// <summary>
        /// Implementation (wraps SaveChangesAsync from Entity Framework in case their methods change. Centralized place here to update their saveasync for example)
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveChangesAsync();
    }
}