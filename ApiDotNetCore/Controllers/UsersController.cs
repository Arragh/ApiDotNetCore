using ApiDotNetCore.Models;
using ApiDotNetCore.Models.ContextModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace ApiDotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersRepository repository;
        public UsersController(IUsersRepository repository)
        {
            this.repository = repository;
            if (!repository.Users.Any())
            {
                repository.AddUser(new User { UserId = Guid.NewGuid(), FirstName = "Вася", LastName = "Васюков", Age = 15 });
                repository.AddUser(new User { UserId = Guid.NewGuid(), FirstName = "Петя", LastName = "Петюков", Age = 13 });
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get() => repository.Users.ToList(); //JsonSerializer.Serialize(repository.Users); //ActionResult<IEnumerable<User>>

        // GET api/users/5
        [HttpGet("{userId}")]
        public ActionResult<User> Get(Guid userId)
        {
            User user = repository.GetUser(userId);
            if (user != null)
            {
                return new ObjectResult(user);
            }
            return NotFound();
        }

        // POST api/users
        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            if (user != null)
            {
                repository.AddUser(user);
                return Ok(user);
            }
            return BadRequest();
        }

        // PUT api/users
        [HttpPut]
        public ActionResult Put(User user)
        {
            if (repository.GetUser(user.UserId) != null)
            {
                repository.UpdateUser(user);
                return Ok(user);
            }
            return NotFound();
        }

        // DELETE api/users/5
        [HttpDelete("{userId}")]
        public ActionResult Delete(Guid userId)
        {
            User user = repository.GetUser(userId);
            if (user != null)
            {
                repository.DeleteUser(userId);
                return Ok(user);
            }
            return NotFound();
        }
    }
}
