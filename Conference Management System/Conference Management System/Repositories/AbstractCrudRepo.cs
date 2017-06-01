using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Conference_Management_System.Models;
using Microsoft.ApplicationInsights.Web;

namespace Conference_Management_System.Repositories
{
    public class AbstractCrudRepo<ID, E> : ICrudRepository<ID, E> where E : Entity<ID>
    {
        protected DbContext _context;

        public AbstractCrudRepo(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds the given entity to the db
        /// </summary>
        /// <param name="entity">the entity to add</param>
        public E Add(E entity)
        {
           return  _context.Set<E>().Add(entity);
        }

        public void Delete(ID id)
        {
            _context.Set<E>().Remove(_context.Set<E>().Find(id));
        }

        /// <summary>
        /// Retruns a queryable of all objects in the db
        /// </summary>
        /// <returns>the db set</returns>
        public IQueryable<E> FindAll()
        {
            return _context.Set<E>();
        }

        /// <summary>
        /// Finds all objects by a predicate expression
        /// </summary>
        /// <param name="predicate">the expression to filter by</param>
        /// <returns>A queryable object</returns>
        public IQueryable<E> FindBy(Expression<Func<E, bool>> predicate)
        {
            return _context.Set<E>().Where(predicate);
        }

        /// <summary>
        /// Saves the uncommited changes.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Receives an entity and sets the value of the eneity in the db with the same 
        /// id to the new one
        /// </summary>
        /// <param name="entity">The new entity</param>
        /// <exception cref=""></exception>
        public E Update(E entity)
        {
            // get by id and update
            var existing = _context.Set<E>().Find(entity.Id);
            if (existing == null)
            {
                throw new KeyNotFoundException("id doesn't exist in db");
            }
            _context.Entry(existing).CurrentValues.SetValues(entity);
            return entity;
        }

     
    }
}