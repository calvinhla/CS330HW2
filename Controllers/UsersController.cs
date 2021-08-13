using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private UsersRepository userRepository { get; set; }

        public UsersController(UsersRepository repo)
        {
            userRepository = repo;
        }

        [HttpGet]
        public List<User> GetUsers()
        {
            return userRepository.Users;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser(Guid id)
        {
            var user = userRepository.Get(id);
            if (user == null)
            {
                var result = new JsonResult(null);
                result.StatusCode = (int)HttpStatusCode.NotFound;
                return result;
            }

            else
            {

                return new JsonResult(user);
            }
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User u)
        {                      
            if (userRepository.CheckEmail(u.Email))
            {
                return Conflict();
            }

            userRepository.Add(u);

            return Ok(u);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            if (userRepository.Exists(id))
            {
                userRepository.Remove(id);
                return NoContent();
            }

            return NotFound();
        }

    }
}
