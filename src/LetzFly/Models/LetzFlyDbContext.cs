﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetzFly.Models
{
    public class LetzFlyDbContext : IdentityDbContext<User, UserRole, string>
    {
        public LetzFlyDbContext(DbContextOptions options) :base(options)
        {
            //leave this open 
        }
        //next setup database in appsettings.json, next configure the application to use Identity w/Entity Framework & MVC in Startup.cs
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
    }
}
