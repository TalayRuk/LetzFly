using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LetzFly.Models;
using Microsoft.AspNetCore.Identity;
using LetzFly.ViewModels;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LetzFly.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        private readonly LetzFlyDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<UserRole> _roleManager;

        public AccountController(UserManager<User> userManger, SignInManager<User> signInManager, RoleManager<UserRole> roleManager, LetzFlyDbContext db)
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

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new User
            {
                //UserName = model.UserName,
                FullName = model.FullName,
                Email = model.Email
            };
            
            IdentityResult result = await _userManager.CreateAsync
            (user, model.Password);

            if (result.Succeeded)
            {
                    
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);
                //SigninAsync method to sign a user in w/their credentials. 
                //isPersistent set to true mean if not log out, it'll stay log in even if the browser is closed

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Invalid login!");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            //SignInManager has the asynchronouse method SignOutAsync() 
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
