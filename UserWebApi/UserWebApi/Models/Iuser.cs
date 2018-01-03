using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace UserWebApi.Models
{
    public interface Iuser
    {
        IEnumerable<User> GetUser(string username, string password);
        void Registeruser(User Obj);
    }
}