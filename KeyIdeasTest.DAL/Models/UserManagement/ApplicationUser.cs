using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeyIdeasTest.DAL.Models.UserManagement
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Name => $"{FirstName} {(string.IsNullOrEmpty(LastName) ? "" : " " + LastName)}";
    }
}
