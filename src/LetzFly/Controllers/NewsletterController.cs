using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LetzFly.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LetzFly.Controllers
{
    public class NewsletterController : Controller
    {
        // GET: /<controller>/
        {
        private LetzFlyDbContext _db;

        public NewsletterController(LetzFlyDbContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_db.Newsletters.ToList());
        }
    }
}
}
