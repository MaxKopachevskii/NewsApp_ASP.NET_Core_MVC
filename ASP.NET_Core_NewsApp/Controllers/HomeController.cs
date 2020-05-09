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
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_NewsApp.Controllers
{
    public class HomeController : Controller
    {
        NewsAppDbContext db;
        public HomeController(NewsAppDbContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 6;   // количество элементов на странице

            IQueryable<Article> source = db.Articles.Where(item => item.WasCheck == true).OrderByDescending(item => item.Id);
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Articles = items
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Search, int page = 1)
        {
            int pageSize = 6;   // количество элементов на странице

            IQueryable<Article> source = db.Articles.Where(item => item.WasCheck == true && item.Title.Contains(Search)).OrderByDescending(item => item.Id);
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Articles = items
            };
            return View(viewModel);
        }

        public async Task<IActionResult> ArticlesIT(int page = 1)
        {
            int pageSize = 6;   // количество элементов на странице

            IQueryable<Article> source = db.Articles.Where(item => item.CategoryId == 1 && item.WasCheck == true).OrderByDescending(item => item.Id);
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Articles = items
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ArticlesIT(string Search, int page = 1)
        {
            int pageSize = 6;   // количество элементов на странице

            IQueryable<Article> source = db.Articles.Where(item => item.CategoryId == 1 && item.WasCheck == true && item.Title.Contains(Search)).OrderByDescending(item => item.Id);
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Articles = items
            };
            return View(viewModel);
        }

        public async Task<IActionResult> ArticlesPolitics(int page = 1)
        {
            int pageSize = 6;   // количество элементов на странице

            IQueryable<Article> source = db.Articles.Where(item => item.CategoryId == 2 && item.WasCheck == true).OrderByDescending(item => item.Id);
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Articles = items
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ArticlesPolitics(string Search, int page = 1)
        {
            int pageSize = 6;   // количество элементов на странице

            IQueryable<Article> source = db.Articles.Where(item => item.CategoryId == 2 && item.WasCheck == true && item.Title.Contains(Search)).OrderByDescending(item => item.Id);
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Articles = items
            };
            return View(viewModel);
        }

        public async Task<IActionResult> ArticlesCars(int page = 1)
        {
            int pageSize = 6;   // количество элементов на странице

            IQueryable<Article> source = db.Articles.Where(item => item.CategoryId == 3 && item.WasCheck == true).OrderByDescending(item => item.Id);
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Articles = items
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ArticlesCars(string Search, int page = 1)
        {
            int pageSize = 6;   // количество элементов на странице

            IQueryable<Article> source = db.Articles.Where(item => item.CategoryId == 3 && item.WasCheck == true && item.Title.Contains(Search)).OrderByDescending(item => item.Id);
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Articles = items
            };
            return View(viewModel);
        }

        public IActionResult ArticlesNotCheck()
        {
            var artigles = db.Articles.Where(item => item.WasCheck == false).ToList();
            return View(artigles);
        }

        [Authorize(Policy = "RequireAdministratorRole")]
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
                article.UserName = User.Identity.Name;
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

        //public IActionResult Index()
        //{
        //    return View(db.Articles.Where(item => item.WasCheck == true).OrderByDescending(item => item.Id).ToList());
        //}

        //public IActionResult ArticlesIT()
        //{
        //    var articles = db.Articles.Where(item => item.CategoryId == 1).OrderByDescending(item => item.Id).ToList();
        //    return View(articles);
        //}

        //public IActionResult ArticlesPolitics()
        //{
        //    var articles = db.Articles.Where(item => item.CategoryId == 2).OrderByDescending(item => item.Id).ToList();
        //    return View(articles);
        //}

        //public IActionResult ArticlesCars()
        //{
        //    var articles = db.Articles.Where(item => item.CategoryId == 3).OrderByDescending(item => item.Id).ToList();
        //    return View(articles);
        //}
    }
}
