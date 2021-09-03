using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Core;

namespace Test.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userSercice;

        public UserController (IUserServices service)
        {
            _userSercice = service;

        }
        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok(_userSercice.GetUsers());
        }

        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<User> GetUser(string id)
        {

            return Ok(_userSercice.GetUser(id));
        }
  
     

        [HttpPost]
        public IActionResult Create (User user)
        {
            _userSercice.Create(user);
               return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }
    }
}
