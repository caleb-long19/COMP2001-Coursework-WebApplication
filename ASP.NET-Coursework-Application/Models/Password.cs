using System;
using System.Collections.Generic;

#nullable disable

namespace COMP2001_ASP.NET_Coursework_Application.Models
{
    public partial class Password
    {
        public int PasswordId { get; set; }
        public int UserId { get; set; }
        public string PreviousPassword { get; set; }
        public DateTime DateOfChange { get; set; }

        public virtual User User { get; set; }
    }
}
