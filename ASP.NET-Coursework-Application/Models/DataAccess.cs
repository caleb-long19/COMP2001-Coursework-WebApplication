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
using Microsoft.Data;
using System.Net.Http;
using System.Data;

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
                new SqlParameter("@Email", userValidate.Email.ToString()),
                new SqlParameter("@Password", userValidate.Password.ToString()));
            SqlParameter returnV = _context.Add("Validated", SqlDbType.Int);
            returnV.Direction = ParameterDirection.ReturnValue;
            int rv = (int)returnV.Value;

            if (rv == 1)
            {
                return true;
            }

            return false;
        }

        public void Register(User userRegisterData, string responseMessage) 
        {

            var User = _context.Database.ExecuteSqlRaw("EXEC Register @FirstName, @LastName, @Email, @Password",
                new SqlParameter("@@FirstName", userRegisterData.FirstName.ToString()),
                new SqlParameter("@LastName", userRegisterData.LastName.ToString()),
                new SqlParameter("@Email", userRegisterData.Email.ToString()),
                new SqlParameter("@Password", userRegisterData.Password.ToString()));

            return;
        }

        public void Update(int userid, User userEdit) 
        {
            var user = _context.Database.ExecuteSqlRaw("EXEC UpdateUser @UserID, @FirstName, @LastName, @Email, @Password",
                new SqlParameter("@UserID", userid),
                new SqlParameter("@FirstName", userEdit.FirstName.ToString()),
                new SqlParameter("@LastName", userEdit.LastName.ToString()),
                new SqlParameter("@Email", userEdit.Email.ToString()),
                new SqlParameter("@Password", userEdit.Password.ToString()));

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
