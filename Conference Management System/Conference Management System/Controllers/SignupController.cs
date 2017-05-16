﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Conference_Management_System.Repositories;
using Conference_Management_System.Models;
using System.Web.Mvc;

namespace Conference_Management_System.Controllers
{
    public class SignupController:Controller
    {
        ICrudRepository<Int32,User> repo;

        public SignupController()
        {
            //repo = new UserRepository();
        }

        public SignupController(ICrudRepository<Int32,User> repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult Add()
        {
            //repo.Add(user);
            //repo.Save();
            return View();
        }



        /* <summary>
        * Adds an User to the repo
        * Raises a RespositoryException if the operation fails
        * </summary>
        * <param name="user">the User to add</param>
        */
        [HttpPost]
        public ActionResult Add(User user)
        {
            repo.Add(user);
            //repo.Save();
            return Redirect("/");
        }

    }
}