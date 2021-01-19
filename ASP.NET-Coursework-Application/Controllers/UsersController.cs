using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using COMP2001_ASP.NET_Coursework_Application.Models;
using System.Net.Http;

namespace COMP2001_ASP.NET_Coursework_Application.Controllers
{
    public class UsersController : Controller
    {
        
        private DataAccess dataAccess;


        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult ValidateUser(User user)
        {
            getValidation(user);

            if (getValidation(user) ==  true)
            {
                return StatusCode(200);
            }

            return ValidateUser(user);
        }

        private bool getValidation(User userValidate)
        {
            dataAccess.Validate(userValidate);

            return getValidation(userValidate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User userRegister)
        {
            string responseMessage = "test message";

            register(userRegister, responseMessage);

            //if ()
            //{

            //}

            return StatusCode(200);
        }

        private void register(User usersRegistered, string responseMessage)
        {
            dataAccess.Register(usersRegistered, responseMessage);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateUser(int userid, User user)
        {
            dataAccess.Update(userid, user);

            return StatusCode(204);
        }

        //POST: Users/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUser(int userid)
        {
            dataAccess.Delete(userid);

            return StatusCode(204);
        }
    }
}
