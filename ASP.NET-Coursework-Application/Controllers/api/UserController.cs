using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COMP2001_ASP.NET_Coursework_Application.Models;

namespace COMP2001_ASP.NET_Coursework_Application.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly COMP2001_CLongContext _context;

        public UserController(COMP2001_CLongContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<User>> updateUser(User user)
        {
            getValidation(user);

            if (getValidation(user) == true)
            {
                return StatusCode(200, getValidation(user));
            }

            return StatusCode(404, getValidation(user));
        }

        private bool getValidation(User user)
        {
            DataAccess dataAccess = new DataAccess(_context);

            dataAccess.Validate(user);

            if (dataAccess.Validate(user) == true)
            {
                return true;
            }

            return false;
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            string responseMessage = "";

            if (user == null)
            {
                return StatusCode(404);
            }

            register(user, responseMessage);

            return StatusCode(200, responseMessage);
        }

        private void register(User usersRegistered, string responseMessage)
        {
            DataAccess dataAccess = new DataAccess(_context);
            dataAccess.Register(usersRegistered, responseMessage);
        }

        // UPDATE: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> updateUser(int id, User user)
        {
            DataAccess dataAccess = new DataAccess(_context);
            dataAccess.Update(id, user);

            return StatusCode(204, id);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteUser(int id)
        {
            DataAccess dataAccess = new DataAccess(_context);
            dataAccess.Delete(id);

            return StatusCode(204, id);
        }
    }
}
