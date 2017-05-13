using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Conference_Management_System.Models;

namespace Conference_Management_System.Validators
{
    public class UserValidator : IValidator<User>
    {
        public UserValidator() { }

        public void Validate(User entity)
        {
            String username = entity.Username;
            String password = entity.Password;
            String name = entity.Name;
            String email = entity.Email;
            String affiliation = entity.Affiliation;

            //username characters: letters and numbers
            Regex r = new Regex("^[a-zA-Z0-9]+$", RegexOptions.IgnoreCase);
            Match m = r.Match(username);
            if (!m.Success)
                throw new ValidatorException("Username have to contains only letters and numbers !");

            //password characters: all permited
            if (password.Length < 6)
                throw new ValidatorException("Password must have at least 6 characters !");

            //name characters: letters and " "
            r = new Regex("^[a-zA-Z ]+$", RegexOptions.IgnoreCase);
            m = r.Match(name);
            if (!m.Success)
                throw new ValidatorException("Name have to contains only letters !");

            //email characters: letters, numbers, one "@" and "-+.'_ "
            r = new Regex("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$", RegexOptions.IgnoreCase);
            m = r.Match(email);
            if (!m.Success)
                throw new ValidatorException("Invalid email !");

            //afffiliation characters: letters and "-. "
            r = new Regex("^[a-zA-Z -.]+$", RegexOptions.IgnoreCase);
            m = r.Match(affiliation);
            if (!m.Success)
                throw new ValidatorException("Affiliation have to contains letters and '-. ' characters !");
        }
    }
}