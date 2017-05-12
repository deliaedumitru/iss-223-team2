using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Conference_Management_System.Repositories;
using Conference_Management_System.Models;
using System.Linq.Expressions;

namespace Conference_Management_System.Controllers
{
    public class SingupController
    {
        ICrudRepository<String,User> repo;

        public SingupController()
        {
            //repo = new UserRepository();
        }

        public SingupController(ICrudRepository<String,User> repo)
        {
            this.repo = repo;
        }


        /* <summary>
        * Adds an User to the repo
        * Raises a RespositoryException if the operation fails
        * </summary>
        * <param name="user">the User to add</param>
        */
        public void Add(User user)
        {
            repo.Add(user);
        }


        /*<summary>
        * Delete the User with the given id
        * Raises a RespositoryException if the operation fails(the id doesn't exist)
        * </summary>
        * <param name="id">the id of the User to remove</param>
        */
        public void Delete(string id)
        {
            repo.Delete(id);
        }


        /* <summary>
        * Update a given User
        * Raises a RespositoryException if the operation fails(ie. the give id doesn't exist)
        * </summary>
        * <param name="user"> The new value for the User </param>
        */
        public void Update(User user)
        {
            repo.Update(user);
        }


        /*<summary>
        * Gets all the Users of the repository
        * </summary>
        * Returns : A queryable(ie. list) of all the the items in the repo 
        */
        public IQueryable<User> FindAll()
        {
            return repo.FindAll();
        }


        /*<summary>
        * Gets all the Users of the repository fulfilling a given predicate
        * </summary>
        * <returns> A queryable(ie. list) of all the the items in the repo </returns> 
        */
        public IQueryable<User> FindBy(Expression<Func<User, bool>> predicate)
        {
            return repo.FindBy(predicate);
        }
    }
}