using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetzFly.Models
{
    public class UserRole : IdentityRole
    {
        //UserRole class inherits from IdentityRole base class and provide UserRole w/ RoleName and add extra property as Description.
        public string Description { get; set; }
    }
}
