using System;
using System.Collections.Generic;

#nullable disable

namespace COMP2001_ASP.NET_Coursework_Application.Models
{
    public partial class Session
    {
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public DateTime DatePasswordIssued { get; set; }

        public virtual User User { get; set; }
    }
}
