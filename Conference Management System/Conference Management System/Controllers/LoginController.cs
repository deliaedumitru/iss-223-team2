using Conference_Management_System.Models;
using Conference_Management_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Conference_Management_System.Controllers
{
    public class LoginController
    {
        private  ICrudRepository<String,User> _UserRepository;

        public LoginController(ICrudRepository<String,User> UserRepository)
        {
            _UserRepository = UserRepository;
        }

        /*<summary>
       * Gets all the Users of the repository
       * </summary>
       * Returns : A queryable(ie. list) of all the the items in the repo 
       */
        public IQueryable<User> FindAllUsers()
        {
            return _UserRepository.FindAll();
        }

        /*<summary>
        * Gets all the Users of the repository fulfilling a given role
        * </summary>
        * <returns> A queryable(ie. list) of all the the items in the repo </returns> 
        */
        public IQueryable<User> FindUserByRole(Role role)
        {
            Func<User, bool> findRole = delegate (User s)
            { return s.Role==role; };

            return _UserRepository.FindBy(Expression.Lambda<Func<User,bool>>(Expression.Call(findRole.Method)));
        }

        /*<summary>
        * Gets all the Users of the repository fulfilling a given affiliation
        * </summary>
        * <returns> A queryable(ie. list) of all the the items in the repo </returns> 
        */
        public IQueryable<User> FindUserByAffiliation(String affiliation)
        {
            Func<User, bool> findRole = delegate (User s)
            { return s.Affiliation.Equals(affiliation); };

            return _UserRepository.FindBy(Expression.Lambda<Func<User, bool>>(Expression.Call(findRole.Method)));
        }


        /*<summary>
       * Gets all the Users of the repository fulfilling a given username and password
       * </summary>
       * <returns> A queryable(ie. list) of all the the items in the repo </returns> 
       */
        public IQueryable<User> FindUserByLogin(String username,String password)
        {
            Func<User, bool> findRole = delegate (User s)
            { return s.Username.Equals(username)&s.Password.Equals(password); };

            return _UserRepository.FindBy(Expression.Lambda<Func<User, bool>>(Expression.Call(findRole.Method)));
        }

        /* <summary>
       * Adds an User to the repo
       * Raises a RespositoryException if the operation fails
       * </summary>
       * <param name="user">the User to add</param>
       */
        public void AddUser(User user)
        {
            _UserRepository.Add(user);
        }

        /*<summary>
       * Delete the User with the given id
       * Raises a RespositoryException if the operation fails(the id doesn't exist)
       * </summary>
       * <param name="id">the id of the User to remove</param>
       */
        public void DeleteUser(String username)
        {
            _UserRepository.Delete(username);
        }

        /* <summary>
       * Update a given User
       * Raises a RespositoryException if the operation fails(ie. the give id doesn't exist)
       * </summary>
       * <param name="user"> The new value for the User </param>
       */
        public void UpdateUser(User user)
        {
            _UserRepository.Update(user);
        }

    }
}
