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

        private DataAccess dataAccess;

        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult ValidateUser(User loginUser)
        {
            getValidation(loginUser);

            return StatusCode(200, loginUser);
        }


        private bool getValidation(User loginUser)
        {
            dataAccess.Validate(loginUser);

            return getValidation(loginUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User userRegister)
        {
            string responseMessage = "User Register";

            register(userRegister, responseMessage);

            return StatusCode(200, responseMessage);
        }

        private void register(User usersRegistered, string responseMessage)
        {
            dataAccess.Register(usersRegistered, responseMessage);
        }

        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateUser(int userid, User user)
        {
            dataAccess.Update(userid, user);

            return StatusCode(204, userid);
        }

        //POST: Users/Delete/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUser(int userid)
        {
            dataAccess.Delete(userid);

            return StatusCode(204, userid);
        }
    }
}
