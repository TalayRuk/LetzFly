using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LetzFly.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LetzFly.Controllers
{
    public class BlogController : Controller
    {
        // GET: /<controller>/
        private LetzFlyDbContext _db;

        public BlogController(LetzFlyDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Blogs.Include(b => b.Category).ToList());
           
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var thisBlog = _db.Blogs.FirstOrDefault(b => b.BlogId == id);
            return View(thisBlog);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            _db.Blogs.Add(blog);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var thisBlog = _db.Blogs.FirstOrDefault(b => b.BlogId == id);
            return View(thisBlog);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            _db.Entry(blog).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var thisBlog = _db.Blogs.FirstOrDefault(b => b.BlogId == id);
            return View(thisBlog);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisBlog = _db.Blogs.FirstOrDefault(b => b.BlogId == id);
            _db.Blogs.Remove(thisBlog);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult MailingList()
        {
            return View(_db.Subscribers.ToList());
        }
    }
}

