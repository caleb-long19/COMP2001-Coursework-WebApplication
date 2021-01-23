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
using System.Configuration;
using System.Text;

namespace COMP2001_ASP.NET_Coursework_Application.Models
{
    public class DataAccess
    {

        private readonly COMP2001_CLongContext _context;

        public DataAccess(COMP2001_CLongContext context)
        {
            _context = context;
        }

        private string connectionString = "Data Source=socem1.uopnet.plymouth.ac.uk;Initial Catalog=COMP2001_CLong;Persist Security Info=True;User ID=CLong;Password=XqlC535+";

        public bool Validate(User userValidate)
        {
            string salt = CreateSaltHash(5);

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("ValidateUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Email", userValidate.Email.ToString()));
            cmd.Parameters.Add(new SqlParameter("@Password", PasswordHashGenerator(userValidate.Password.ToString(), salt)));
            cmd.Parameters.Add("@Validated", SqlDbType.Int).Direction=ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();
            conn.Close();

            int returnValue = int.Parse(cmd.Parameters["@Validated"].Value.ToString());

            if (returnValue == 1)
            {
                return true;
            }

            return false;
        }

        public void Register(User userRegisterData, string responseMessage) 
        {
            string salt = CreateSaltHash(5);

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("Register", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@FirstName", userRegisterData.FirstName.ToString()));
            cmd.Parameters.Add(new SqlParameter("@LastName", userRegisterData.LastName.ToString()));
            cmd.Parameters.Add(new SqlParameter("@Email", userRegisterData.Email.ToString()));
            cmd.Parameters.Add(new SqlParameter("@Password", PasswordHashGenerator(userRegisterData.Password.ToString(), salt)));
            cmd.ExecuteNonQuery();

            return;
        }

        public void Update(int id, User userEdit) 
        {
            string salt = CreateSaltHash(5);

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("UpdateUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@UserID", id));
            cmd.Parameters.Add(new SqlParameter("@FirstName", userEdit.FirstName.ToString()));
            cmd.Parameters.Add(new SqlParameter("@LastName", userEdit.LastName.ToString()));
            cmd.Parameters.Add(new SqlParameter("@Email", userEdit.Email.ToString()));
            cmd.Parameters.Add(new SqlParameter("@Password", PasswordHashGenerator(userEdit.Password.ToString(), salt)));
            cmd.ExecuteNonQuery();

            return;
        }

        public void Delete (int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("DeleteUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@UserID", id));
            cmd.ExecuteNonQuery();
            conn.Close();

            return;
        }

        #region Password Hashing Methods (Salt and Hash)
        public static string HexToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hex.AppendFormat("{0:x2}", b);
            }

            return hex.ToString();
        }

        public string CreateSaltHash(int size)
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new Byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public string PasswordHashGenerator(string input, string salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + salt);
            System.Security.Cryptography.SHA256Managed sha256hashstring = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256hashstring.ComputeHash(bytes);

            return HexToString(hash);
        }
        #endregion
    }
}
