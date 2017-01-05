using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetzFly.Models
{
    public class User : IdentityUser
    {
        //User class inherits from IdentityUser base class (Microsoft.AspNetCore.Identity.EntityFrameworkCore namespace). The IdentityUser base class contains basic user details such as UserName, Password and Email. 
        //To capture FullName of a user, Add it as additional properties to AspNetUsers
        public string FullName { get; set; }
    }
}
