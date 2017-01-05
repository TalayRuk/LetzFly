using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LetzFly.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LetzFly.Controllers
{
    public class BlogController : Controller
    {
        // GET: /<controller>/
        {
        private LetzFlyDbContext _db;

        public BlogController(LetzFlyDbContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_db.Blogs.ToList());
        }

        [Authorize]
        public IActionResult MailingList()
        {
            return View(_db.Subscribers.ToList());
        }
    }
}
}
