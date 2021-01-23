using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable disable

namespace COMP2001_ASP.NET_Coursework_Application.Models
{
    public partial class User
    {
        [JsonIgnore]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
