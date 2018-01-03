using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using UserWebApi.Models;

namespace UserWebApi.Models
{
    public class UserBL:Iuser
    {
        UserDBContext objdb = new UserDBContext();
        public IEnumerable< User> GetUser(string username, string password)
        {
            return objdb.users.Where(u => u.username == username && u.password == password);
        }

        public void  Registeruser(User Obj)
        {
           // User objuser = new User() { id = 123, username = "test", password = "test123", firstName = "Singh", lastName = "Gujjar" };
               objdb.users.Add(Obj);
               objdb.SaveChanges();
           
        }
    }
}