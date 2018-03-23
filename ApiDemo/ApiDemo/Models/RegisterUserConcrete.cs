using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiDemo.Models
{
    public class RegisterUserConcrete : IRegisterUser
    {
        DatabaseContext _context;
        public RegisterUserConcrete()
        {
            _context = new DatabaseContext();
        }

        public void Add(RegisterUser registeruser)
        {
            _context.RegisterUser.Add(registeruser);
            _context.SaveChanges();
        }

        public int GetLoggedUserID(RegisterUser registeruser)
        {
            var usercount = (from User in _context.RegisterUser
                             where User.Username == registeruser.Username &&
                                   User.Password == registeruser.Password
                             select User.UserID).FirstOrDefault();

            return usercount;
        }

        public bool ValidateRegisteredUser(RegisterUser registeruser)
        {
            var usercount = (from User in _context.RegisterUser
                             where User.Username == registeruser.Username &&
                             User.Password == registeruser.Password
                             select User).Count();
            if (usercount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateUsername(RegisterUser registeruser)
        {
            var usercount = (from User in _context.RegisterUser
                             where User.Username == registeruser.Username
                             select User).Count();
            if (usercount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}