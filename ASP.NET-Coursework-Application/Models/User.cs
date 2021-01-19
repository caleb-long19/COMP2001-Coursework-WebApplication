using System;
using System.Collections.Generic;

#nullable disable

namespace COMP2001_ASP.NET_Coursework_Application.Models
{
    public partial class User
    {
        public User()
        {
            Passwords = new HashSet<Password>();
            Sessions = new HashSet<Session>();
        }

        public string firstname;
        public string lastname;
        public string email;
        public string password;

        public virtual ICollection<Password> Passwords { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
