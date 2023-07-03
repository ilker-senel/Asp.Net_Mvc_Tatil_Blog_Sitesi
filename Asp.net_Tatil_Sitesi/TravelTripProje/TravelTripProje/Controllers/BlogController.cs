using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;
using PagedList;
using PagedList.Mvc;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index(int sayfa = 1)
        {
            by.Deger1 = c.Blogs.ToList().ToPagedList(sayfa, 4);
            // var bloglar = c.Blogs.ToList();
            by.Deger3 = c.Blogs.OrderByDescending(x => x.Id).Take(2).ToList();
            //by.Deger2 = c.Yorumlars.OrderByDescending(x => x.Id).Take(2).ToList();
            by.Deger2 = (from yorum in c.Yorumlars
                         where yorum.Onay == true
                         orderby yorum.Id descending
                         select yorum).Take(2).ToList();


            return View(by);//bloglar
        }


        public ActionResult BlogDetay(int id)
        {
            //var blogBul = c.Blogs.Where(x => x.Id == id).ToList();
            by.Deger1 = c.Blogs.Where(x => x.Id == id).ToList();
            by.Deger2 = c.Yorumlars.Where(x => x.BlogId == id).ToList();
            return View(by);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            ViewBag.deger = y.BlogId;
            y.Onay = false;
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }
    }
}