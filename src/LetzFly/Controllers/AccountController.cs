using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LetzFly.Models;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LetzFly.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        private readonly UserDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<UserRole> _roleManager;

        public AccountController(UserManager<User> userManger, SignInManager<User> signInManager, RoleManager<UserRole> roleManager, UserDbContext db)
        {
            _userManager = userManger;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _db = db;

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
