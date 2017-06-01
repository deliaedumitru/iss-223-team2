using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Conference_Management_System.Models;

namespace Conference_Management_System.Repositories
{
    public class RepositoryException : ApplicationException
    {
        public RepositoryException() { }
        public RepositoryException(String mess) : base(mess) { }
        public RepositoryException(String mess, Exception e) : base(mess, e) { }
    }

    public interface ICrudRepository<ID, E> where E : Entity<ID>
    {
        /// <summary>
        /// Gets all the items of the repository
        /// </summary>
        /// <returns>A queryable(ie. list) of all the the items in the repo.</returns>
        IQueryable<E> FindAll();

        /// <summary>
        /// Gets all items fulfilling a given predicate
        /// </summary>
        /// <param name="predicate">the predicate to filter objects by</param>
        /// <returns>A filtered queryable of entities</returns>
        IQueryable<E> FindBy(Expression<Func<E, bool>> predicate);

        /// <summary>
        /// Adds an entity to the repo
        /// Raises a RespositoryException if the operation fails
        /// </summary>
        /// <param name="entity">the entity to add</param>
        /// <returns>The added object</returns>
        E Add(E entity);

        /// <summary>
        /// Delete the entity with the given id
        /// Raises a RespositoryException if the operation fails(the id doesn't exist)
        /// </summary>
        /// <param name="id">the id of the etitty to remove</param>
        void Delete(ID id);

        /// <summary>
        /// Update a given entity
        /// Raises a RespositoryException if the operation fails(ie. the give id doesn't exist)
        /// </summary>
        /// <param name="entity">The new value for the entity</param>
        /// <returns>the new entity</returns>
        E Update(E entity);

        /// <summary>
        /// Commits the operations.
        /// </summary>
        void Save();
    }
}
