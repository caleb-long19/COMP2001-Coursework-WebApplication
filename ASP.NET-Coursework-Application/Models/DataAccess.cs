using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using COMP2001_ASP.NET_Coursework_Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Net.Http;

namespace COMP2001_ASP.NET_Coursework_Application.Models
{
    public class DataAccess
    {

        private readonly COMP2001_CLongContext _context;

        public DataAccess(COMP2001_CLongContext context)
        {
            _context = context;
        }

        public bool Validate(User userValidate)
        {
            var user = _context.Database.ExecuteSqlRaw("EXEC ValidateUser @Email, @Password",
                new SqlParameter("@Email", userValidate.email.ToString()),
                new SqlParameter("@Password", userValidate.password.ToString()));

            if()
            {
                return true;
            }

            return false;
        }

        public void Register(User userRegisterData, string responseMessage) 
        {

            var User = _context.Database.ExecuteSqlRaw("EXEC Register @FirstName, @LastName, @Email, @Password",
                new SqlParameter("@@FirstName", userRegisterData.firstname.ToString()),
                new SqlParameter("@LastName", userRegisterData.lastname.ToString()),
                new SqlParameter("@Email", userRegisterData.email.ToString()),
                new SqlParameter("@Password", userRegisterData.password.ToString()));

            return;
        }

        public void Update(int userid, User userEdit) 
        {
            var user = _context.Database.ExecuteSqlRaw("EXEC UpdateUser @UserID, @FirstName, @LastName, @Email, @Password",
                new SqlParameter("@UserID", userid),
                new SqlParameter("@FirstName", userEdit.firstname.ToString()),
                new SqlParameter("@LastName", userEdit.lastname.ToString()),
                new SqlParameter("@Email", userEdit.email.ToString()),
                new SqlParameter("@Password", userEdit.password.ToString()));

            return;
        }

        public void Delete (int userId)
        {
             var user = _context.Database.ExecuteSqlRaw("EXEC DeleteUser @UserID",
                new SqlParameter("@UserID", userId));

            return;
        }
    
    }
}
