using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COMP2001___RESTful_API.Models;
using COMP2001___RESTful_API.Attributes;

namespace COMP2001___RESTful_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class userController : ControllerBase
    {
        private readonly DataAccess database;

        public userController(DataAccess context)
        {
            database = context;
        }

        [HttpGet]
        [HttpHead("Content-Type: application/json, application/xml")]
        [HttpHead("Accept: application/json, application/xml")]
        [Produces("application/xml", "application/json")]
        public IActionResult loginUser(User user)
        {
            if (getValidation(user) == true)
            {
                return Ok(new { verified = "true" });
            }

            return Ok(new { verified = "false" });
        }

        private bool getValidation(User user)
        {
            if (database.Validate(user) == true)
            {
                return true;
            }

            return false;
        }

        [HttpPost]
        [HttpHead("Content-Type: application/json, application/xml")]
        [HttpHead("Accept: application/json, application/xml")]
        [Consumes("application/json", "application/xml")]
        [Produces("application/xml", "application/json")]
        public IActionResult RegisterUser(User user)
        {
            string responseMessage = "";

            register(user, out responseMessage);

            if (user == null)
            {
                return StatusCode(404);
            }
            return Ok(new { UserID = responseMessage });
        }

        private void register(User usersRegistered, out string responseMessage)
        {
            database.Register(usersRegistered, out responseMessage);
        }

        // UPDATE: api/User/5
        [HttpPut("{id}")]
        [HttpHead("Content-Type: application/json, application/xml")]
        [HttpHead("Accept: application/json, application/xml")]
        [Consumes("application/json", "application/xml")]
        [Produces("application/xml", "application/json")]
        public IActionResult updateUser(int id, User user)
        {

            database.Update(id, user);

            return StatusCode(204);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        [HttpHead("Content-Type: application/json, application/xml")]
        [HttpHead("Accept: application/json, application/xml")]
        [Produces("application/xml", "application/json")]
        public IActionResult deleteUser(int id)
        {
            database.Delete(id);

            return StatusCode(204);
        }
    }
}
