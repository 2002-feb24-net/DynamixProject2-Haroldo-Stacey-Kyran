﻿using Dynamix.API.Interfaces;
using Dynamix.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dynamix.API.Repositories
{
    public class LocationVisitorRepository : Repository<LocationVisitor>, ILocationVisitorRepository
    {
        DbDynamixContext _context;
        public LocationVisitorRepository(DbDynamixContext context)
        {
            this._context = context;
        }

        public void Add(LocationVisitor entity)
        {
            _context.Set<LocationVisitor>().Add(entity);
        }

        public void AddRange(IEnumerable<LocationVisitor> entities)
        {
            _context.Set<LocationVisitor>().AddRange(entities);
        }

        public IEnumerable<LocationVisitor> Find(int id)
        {
            yield return _context.Set<LocationVisitor>().Find(id);
        }

        public IEnumerable<LocationVisitor> Find(Expression<Func<LocationVisitor, bool>> predicate, string includeName) // only include one navigational property
        {
            return _context.Set<LocationVisitor>().Where(predicate).Include($"{includeName}");
        }

        public IEnumerable<LocationVisitor> Find(Expression<Func<LocationVisitor, bool>> predicate, string includeNameFirst, string includeNameSecond) //  include two navigational properties
        {
            return _context.Set<LocationVisitor>().Where(predicate).Include($"{includeNameFirst}").Include($"{includeNameSecond}");
        }

        public IEnumerable<LocationVisitor> Find(Expression<Func<LocationVisitor, bool>> predicate, string includeNameFirst, string includeNameSecond, string includeNameThird) //  include three navigational properties
        {
            return _context.Set<LocationVisitor>().Where(predicate).Include($"{includeNameFirst}").Include($"{includeNameSecond}").Include($"{includeNameThird}");
        }

        public IEnumerable<LocationVisitor> Find(Expression<Func<LocationVisitor, bool>> predicate)
        {
            return _context.Set<LocationVisitor>().Where(predicate);
        }

        public async Task<LocationVisitor> FindAsync(int id)
        {
            return await _context.Set<LocationVisitor>().FindAsync(id);
        }

        public LocationVisitor Get(int id)
        {
            return _context.Set<LocationVisitor>().Find(id); //return single object of class
        }

        public async Task<IEnumerable<LocationVisitor>> GetAll()
        {
            return await _context.Set<LocationVisitor>().ToListAsync();
        }

        /// <summary>
        /// same as get all. Returns a list
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LocationVisitor>> ToListAsync()
        {
            return await _context.Set<LocationVisitor>().ToListAsync();
        }

        public void Remove(LocationVisitor entity)
        {
            _context.Set<LocationVisitor>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<LocationVisitor> entities)
        {
            _context.Set<LocationVisitor>().RemoveRange(entities);
        }

        public bool Any(Expression<Func<LocationVisitor, bool>> predicate)
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
