using Dynamix.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dynamix.API.Interfaces
{
    public interface IEmojiRatingRepository
    {

        public DbDynamixContext Context { get; set; }

        public void Add(EmojiRating entity);

        public void AddRange(IEnumerable<EmojiRating> entities);

        public IEnumerable<EmojiRating> Find(int id)
        ;

        public IEnumerable<EmojiRating> Find(Expression<Func<EmojiRating, bool>> predicate, string includeName) // only include one navigational property
        ;

        public IEnumerable<EmojiRating> Find(Expression<Func<EmojiRating, bool>> predicate, string includeNameFirst, string includeNameSecond) //  include two navigational properties
        ;

        public IEnumerable<EmojiRating> Find(Expression<Func<EmojiRating, bool>> predicate, string includeNameFirst, string includeNameSecond, string includeNameThird) //  include three navigational properties
        ;

        public IEnumerable<EmojiRating> Find(Expression<Func<EmojiRating, bool>> predicate);

        /// <summary>
        /// async functions require bodies. EF Core FindAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  Task<EmojiRating> FindAsync(int id)
        ;

        public EmojiRating Get(int id);

        public Task<IEnumerable<EmojiRating>> GetAll();

        /// <summary>
        /// same as get all. Returns a list
        /// </summary>
        /// <returns></returns>
        public  Task<IEnumerable<EmojiRating>> ToListAsync()
        ;

        public void Remove(EmojiRating entity);

        public void RemoveRange(IEnumerable<EmojiRating> entities);

        public bool Any(Expression<Func<EmojiRating, bool>> predicate);

        // need to implement a put method but it requires indepth knowledge of how entity state works

        public void Save();

        /// <summary>
        /// Implementation (wraps SaveChangesAsync from Entity Framework in case their methods change. Centralized place here to update their saveasync for example)
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveChangesAsync();
}
}