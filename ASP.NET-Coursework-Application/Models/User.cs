using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace COMP2001___RESTful_API.Models
{
    public partial class User
    {
        [JsonIgnore]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
