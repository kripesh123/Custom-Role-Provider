﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student.Profile.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}