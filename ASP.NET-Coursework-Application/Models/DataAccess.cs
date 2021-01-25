using System;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace COMP2001___RESTful_API.Models
{
    public partial class DataAccess : DbContext
    {
        public DataAccess()
        {
        }

        public DataAccess(DbContextOptions<DataAccess> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //                optionsBuilder.UseSqlServer("Server=socem1.uopnet.plymouth.ac.uk;Database=COMP2001_CLong;User Id=Clong; Password=XqlC535+");
            }
        }

        string connectionstring = "Data Source = socem1.uopnet.plymouth.ac.uk; Initial Catalog = COMP2001_CLong; Persist Security Info = True; User ID = CLong; Password = XqlC535+";

        public bool Validate(User userValidate)
        {

            //Store connection of database and open it
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();

            //Create an sql command to execute Validate User Procedure
            SqlCommand cmd = new SqlCommand("ValidateUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //Store Email/Password values into @Email/Password
            cmd.Parameters.Add(new SqlParameter("@Email", userValidate.Email.ToString()));
            cmd.Parameters.Add(new SqlParameter("@Password", userValidate.Password.ToString()));
            cmd.Parameters.Add("@Validated", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            //Execute Procedure
            cmd.ExecuteNonQuery();
            conn.Close();

            int returnValue = int.Parse(cmd.Parameters["@Validated"].Value.ToString());

            //Return true if return value is = 1 
            if (returnValue == 1)
            {
                return true;
            }

            return false;
        }

        public void Register(User userRegisterData, out string responseMessage)
        {
            string salt = CreateSaltHash(5);

            // Output parameter must be declared in advance so its direction can be set to output (output parameters are also needed to get return values)
            SqlParameter response = new SqlParameter("@ResponseMessage", SqlDbType.VarChar, 100);
            response.Direction = ParameterDirection.Output;

            //Register Method contains a call to execute the Register Proceudre in our Database
            Database.ExecuteSqlRaw("EXEC Register @FirstName, @LastName, @Email, @Password, @ResponseMessage OUTPUT",
                new SqlParameter("@FirstName", userRegisterData.FirstName),
                new SqlParameter("@LastName", userRegisterData.LastName),
                new SqlParameter("@Email", userRegisterData.Email),
                new SqlParameter("@Password", PasswordHashGenerator(userRegisterData.Password, salt)),
                response);

            responseMessage = response.Value.ToString();  // This will contain the value that the stored procedure placed in @ResponseMessage

            return;
        }

        public void Update(int id, User userEdit)
        {
            //store random salt in salt string
            string salt = CreateSaltHash(5);

            //Delete Update contains a call to execute the UpdateUser Proceudre in our Database
            Database.ExecuteSqlRaw("EXEC UpdateUser @UserID, @FirstName, @LastName, @Email, @Password",
                 new SqlParameter("@UserID", id),
                 new SqlParameter("@FirstName", userEdit.FirstName),
                 new SqlParameter("@LastName", userEdit.LastName),
                 new SqlParameter("@Email", userEdit.Email),
                 new SqlParameter("@Password", PasswordHashGenerator(userEdit.Password, salt)));
            return;
        }

        //Delete Method contains a call to execute the DeleteUser Proceudre in our Database
        public void Delete(int id)
        {
            Database.ExecuteSqlRaw("EXEC DeleteUser @UserID",
            new SqlParameter("@UserID", id));

            return;
        }

        #region Password Hashing Methods (Salt and Hash)
        public static string HexToString(byte[] ba)
        {
            //Build string characters
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                //apply hex format
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
