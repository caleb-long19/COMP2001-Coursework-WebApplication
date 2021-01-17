using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using COMP2001_ASP.NET_Coursework_Application.Models;

namespace COMP2001_ASP.NET_Coursework_Application.Controllers
{
    public class UsersController : Controller
    {
        private readonly COMP2001_CLongContext _context;
        private DataAccess dataAccess;

        public UsersController(COMP2001_CLongContext context)
        {
            _context = context;
        }

        #region Return Indexs for pages
        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult UpdateUser()
        {
            return View();
        }

        public IActionResult DeleteUser()
        {
            return View();
        }
        #endregion

        [HttpGet]
        public IActionResult ValidateUser(ValidateUser validateUser)
        {
            var rowsAffected = _context.Database.ExecuteSqlRaw("EXEC ValidateUser @UserID, @Email, @Password",
                new SqlParameter("@Email", validateUser.Email.ToString()),
                "@Password", validateUser.Password.ToString());

            ViewBag.Success = rowsAffected;

            return View("Index");
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            var rowsAffected = _context.Database.ExecuteSqlRaw("EXEC ValidateUser @FirstName, @LastName, @Email, @Password",
                new SqlParameter("@FirstName", register.FirstName.ToString()),
                "@LastName", register.LastName.ToString(),
                "@Email", register.Email.ToString(),
                "@Password", register.Password.ToString());

            ViewBag.Success = rowsAffected;

            return View("Register");
        }

        [HttpPut]
        public IActionResult UpdateUser(UpdateUser updateUser)
        {
            var rowsAffected = _context.Database.ExecuteSqlRaw("EXEC ValidateUser @UserID, @FirstName, @LastName, @Email, @Password",
                new SqlParameter("@UserID", updateUser.UserID.ToString()),
                "@FirstName", updateUser.FirstName.ToString(),
                "@LastName", updateUser.LastName.ToString(),
                "@Email", updateUser.Email.ToString(),
                "@Password", updateUser.Password.ToString());

            ViewBag.Success = rowsAffected;

            return View("UpdateUser");
        }

        [HttpDelete]
        public IActionResult DeleteUser(DeleteUser deleteUser)
        {
            var rowsAffected = _context.Database.ExecuteSqlRaw("EXEC ValidateUser @UserID",
                new SqlParameter("@UserID", deleteUser.UserID.ToString()));

            ViewBag.Success = rowsAffected;

            return View("DeleteUser");
        }

        private bool getValidation;

        private void register(string user) { }

    }
}
