using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP.NET_Core_NewsApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace ASP.NET_Core_NewsApp.Controllers
{
    public class HomeController : Controller
    {
        NewsAppDbContext db;
        public HomeController(NewsAppDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Articles.Where(item => item.WasCheck == true).OrderByDescending(item => item.Id).ToList());
        }

        public IActionResult ArticlesIT()
        {
            var articles = db.Articles.Where(item => item.CategoryId == 1).OrderByDescending(item => item.Id).ToList();
            return View(articles);
        }

        public IActionResult ArticlesPolitics()
        {
            var articles = db.Articles.Where(item => item.CategoryId == 2).OrderByDescending(item => item.Id).ToList();
            return View(articles);
        }

        public IActionResult ArticlesCars()
        {
            var articles = db.Articles.Where(item => item.CategoryId == 3).OrderByDescending(item => item.Id).ToList();
            return View(articles);
        }

        public IActionResult ArticlesNotCheck()
        {
            var artigles = db.Articles.Where(item => item.WasCheck == false).ToList();
            return View(artigles);
        }

        [Authorize]
        public IActionResult ShowList()
        {
            return View(db.Articles.ToList());
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("ShowList");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var article = db.Articles.Find(id);
            if (article != null)
            {
                return View(article);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Update(article);
                db.SaveChanges();
                return RedirectToAction("ShowList");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var article = db.Articles.Find(id);
            if (article != null)
            {
                db.Articles.Remove(article);
                db.SaveChanges();
                return RedirectToAction("ShowList");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var article = db.Articles.Find(id);
            if (article != null)
            {
                return View(article);
            }
            return NotFound();
        }

        public IActionResult WasChecked(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var article = db.Articles.Find(id);
            if (article != null)
            {
                article.WasCheck = true;
                db.Articles.Update(article);
                db.SaveChanges();
                return RedirectToAction("ArticlesNotCheck");
            }
            return NotFound();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
