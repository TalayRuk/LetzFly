using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetzFly.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }
}
