using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP.NET_Core_NewsApp.Models;

namespace ASP.NET_Core_NewsApp.Controllers
{
    public class HomeController : Controller
    {
        NewsAppDbContext db;
        public HomeController(NewsAppDbContext context)
        {
            db = context;
            //Category category1 = new Category { Name = "Мир IT" };
            //Category category2 = new Category { Name = "Политика" };
            //Category category3 = new Category { Name = "Про автомобили" };

            //db.Categories.Add(category1);
            //db.Categories.Add(category2);
            //db.Categories.Add(category3);
            //db.SaveChanges();

            //Article article1 = new Article
            //{
            //    Title = "«Через год-два .NET Core потеснит Java на рынке enterprise решений», — Интервью с Jon Skeet, Google",
            //    Img = "https://chrissainty.com/content/images/size/w2000/2017/10/aspnet-core.png",
            //    ShortDesc = "Мне удалось пообщаться с Джоном и взять у него большое интервью по поводу судьбы .NET, .NET Core, нововведений в C# 7 и общем уровне развития среднего разработчика в 2017 году.",
            //    LongDesc = "Я думаю, вопрос затрагивает два разных аспекта. Первый — это направление развития платформы, а второе — процесс поиска этого направления: Microsoft стали гораздо более открытыми во всём, что связано с .NET. сейчас почти все стало open source и это здорово. С другой стороны, это влечёт за собой изменения в ряде вещей: например, в процессе принятия решений. Мы будем наблюдать промежуточные шаги, вроде project.json-проектов и KVM. Во времена «старого» Майкрософт с его традиционным корпоративным путем разработки ПО подобного бы точно не произошло, и, возможно, мы сразу увидели бы инструментарий .NET в его текущем виде. Да, в сообществе была полная неразбериха, и лично мне было многое непонятно, но со временем ситуация прояснялась. На этой неделе я задал вопрос на Stack Overflow о том, что же представляет собой .NET Standard Library, и ситуация становится все лучше.",
            //    Category = category1 
            //};

            //Article article2 = new Article
            //{
            //    Title = "MCLAREN 720S (МАКЛАРЕН 720С)",
            //    Img = "https://aczpix.b-cdn.net/wp-content/uploads/2017/01/foto-720s_02.jpg",
            //    ShortDesc = "McLaren 720S дебютировал на ежегодном международном женевском автосалоне весной 2017 года.",
            //    LongDesc = "McLaren 720S дебютировал на ежегодном международном женевском автосалоне весной 2017 года. Автомобиль пришел на смену устаревшей версии 650S и является полностью новой разработкой, а не измененной версией старой модели. Отличить новинку от предшественника не составит труда, у нее стильные небольшие вытянутые фары головного освещения. Они находятся в специальных каплевидных черных вставках и подчеркнуты гирляндой светодиодных ходовых огней. В нижней части переднего бампера расположился небольшой воздухозаборник, придающий передку агрессивный внешний вид.Примечательно то, что весь силуэт автомобиля соткан из плавных струящихся форм. Здесь нет резких агрессивных рубленных линий и острых углов, свойственных суперкарам. Благодаря такому решению, автомобиль выглядит стремительно, но в то же время элегантно и сдержано.",
            //    Category = category3
            //};

            //Article article3 = new Article
            //{
            //    Title = "Кличко открыл зал бокса в Киеве",
            //    Img = "https://klitschko-brothers.com/images/photos/medium/article7555.jpg",
            //    ShortDesc = "Мэр Киева Виталий Кличко посетил ДЮСШ 'Ринг' на Оболони, где открыл обновленный зал бокса.",
            //    LongDesc = "Мы выделили средства на капитальный ремонт фасада и внутренних помещений ДЮСШ 'Ринг'. И я радуюсь, что у вас теперь такой новый современный светлый просторный зал. Сейчас здесь занимается 200 детей. Надеюсь, здесь каждый сможет с комфортом тренироваться и реализовать свою мечту.Мэр подчеркнул, что такие современные спортивные залы должны быть в каждом районе Киева, поскольку это – альтернатива негативу, который предлагает улица.Мэр призвал детей мечтать и настойчиво работать. 'Главное – не сила мышц,а сила духа.И в спорте,и в жизни.Тогда вы сможете достичь всех целей', – обратился Виталий Кличко к воспитанникам ДЮСШ.",
            //    Category = category2
            //};

            //db.Articles.Add(article1);
            //db.Articles.Add(article2);
            //db.Articles.Add(article3);
            //db.SaveChanges();
        }

        public IActionResult Index()
        {
            return View(db.Articles.Where(item => item.WasCheck == true).ToList());
        }

        public IActionResult ArticlesIT()
        {
            var articles = db.Articles.Where(item => item.CategoryId == 1).ToList();
            return View(articles);
        }

        public IActionResult ArticlesPolitics()
        {
            var articles = db.Articles.Where(item => item.CategoryId == 2).ToList();
            return View(articles);
        }

        public IActionResult ArticlesCars()
        {
            var articles = db.Articles.Where(item => item.CategoryId == 3).ToList();
            return View(articles);
        }

        public IActionResult ArticlesNotCheck()
        {
            var artigles = db.Articles.Where(item => item.WasCheck == false).ToList();
            return View(artigles);
        }

        public IActionResult ShowList()
        {
            return View(db.Articles.ToList());
        }

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
