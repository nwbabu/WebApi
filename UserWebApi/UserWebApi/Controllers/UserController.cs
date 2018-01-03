using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserWebApi.Models;
using System.Web.Http.Cors;

namespace UserWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        Iuser _user;
        public UserController(Iuser user)
        {
            _user = user;
        }
        //  UserBL objbl = new UserBL();
        [HttpPost]
        [Route("api/user/VaildateUser")]
        public IHttpActionResult  VaildateUser(User Obj)
        {
            var result = _user.GetUser(Obj.username, Obj.password);
            if (result.Count()>=1)
            {
                return Ok(Obj.username);
            }
            else
            {
                return NotFound();
            }
           
        }
        [HttpPost]
        [Route("api/user/Registeruser")]
        public IHttpActionResult Registeruser(User Obj)
        {
             _user.Registeruser(Obj);
            return Ok(Obj.username);
        }
    }
}
