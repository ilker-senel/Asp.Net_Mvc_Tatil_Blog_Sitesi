using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class IletisimController : Controller
    {
        Context c = new Context();
        // GET: Iletisim
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Iletisim i)
        {
            c.Iletisims.Add(i);
            var deger = c.SaveChanges();
            if(deger>0)
            {
                ViewBag.deger = "Mesajınız gönderildi";
            }

            return View();
        }
    }
}