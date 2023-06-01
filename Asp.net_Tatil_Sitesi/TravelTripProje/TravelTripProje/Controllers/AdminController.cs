using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        //GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = c.Blogs.ToList().ToPagedList(sayfa, 10);
            return View(degerler);
        }
        [Authorize]
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult BlogGetir(int id)
        {
            var b1 = c.Blogs.Find(id);
            return View("BlogGetir", b1);
        }
        [Authorize]
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.Id);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        [Authorize]
        public ActionResult YorumlarListesi(int sayfa = 1)
        {
            var yorumlar = c.Yorumlars.ToList().ToPagedList(sayfa, 10);


            return View(yorumlar);
        }
        [Authorize]
        public ActionResult OnayliYorumlarListesi(int sayfa = 1)
        {
            var yorumlar = c.Yorumlars.ToList();
            List<Yorumlar> list = new List<Yorumlar>();

            foreach (var yorum in yorumlar)
            {
                if (yorum.Onay == true)
                {
                    list.Add(yorum);
                }
            }
            var liste = list.ToPagedList(sayfa, 10);
            return View(liste);
        }
        [Authorize]
        public ActionResult OnayBekleyenYorumlarListesi(int sayfa = 1)
        {
            var yorumlar = c.Yorumlars.ToList();
            List<Yorumlar> list = new List<Yorumlar>();
            foreach (var yorum in yorumlar)
            {
                if (yorum.Onay == false)
                {
                    list.Add(yorum);
                }
            }
            var liste = list.ToPagedList(sayfa, 10);
            return View(liste);
        }
        [Authorize]

        public ActionResult YorumSil(int id)
        {
            var deger = c.Yorumlars.Find(id);
            bool value = deger.Onay;
            c.Yorumlars.Remove(deger);
            c.SaveChanges();
            if (value)
            {
                return RedirectToAction("YorumlarListesi");
            }
            else
            {
                return RedirectToAction("OnayBekleyenYorumlarListesi");
            }


        }
        [Authorize]

        public ActionResult YorumGetir(int id)
        {
            var deger = c.Yorumlars.Find(id);
            return View("YorumGetir", deger);
        }
        [Authorize]
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.Yorumlars.Find(y.Id);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            yrm.Onay = y.Onay;
            c.SaveChanges();
            if (y.Onay == false)
            {
                return RedirectToAction("OnayBekleyenYorumlarListesi");
            }
            else
            {
                return RedirectToAction("OnayliYorumlarListesi");
            }

        }
        [Authorize]
        public PartialViewResult YorumlarNavbar()
        {
            return PartialView();
        }
        [Authorize]
        public ActionResult YorumOnayla(int id)
        {
            var deger = c.Yorumlars.Find(id);
            deger.Onay = true;
            c.SaveChanges();
            return RedirectToAction("OnayBekleyenYorumlarListesi");

        }

        [Authorize]
        public ActionResult Hakkimizda()
        {
            var deger = c.Hakkimidas.Find(1);
            deger.Aciklama = deger.Aciklama.Replace("<br/>", "\r\n");
            c.SaveChanges();
            return View("Hakkimizda", deger);
        }
        [Authorize]
        public ActionResult HakkimizdaGuncelle(Hakkimizda hak)
        {
            var h = c.Hakkimidas.Find(hak.Id);
            h.FotoUrl = hak.FotoUrl;
            h.Aciklama = hak.Aciklama;
            c.SaveChanges();

            return RedirectToAction("Hakkimizda");
        }
        [Authorize]
        public ActionResult IletisimListesi(int sayfa = 1)
        {
            var iletisim = c.Iletisims.ToList().ToPagedList(sayfa, 10);

            return View(iletisim);
        }
        [Authorize]
        public ActionResult IletisimSil(int id)
        {
            var deger = c.Iletisims.Find(id);
            c.Iletisims.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("IletisimListesi");
        }
        [Authorize]
        public ActionResult AdminListesi()
        {
            var deger = c.Admins.Find(1);
            return View(deger);
        }
        [Authorize]
        public ActionResult AdminGuncelle(Admin admin)
        {
            var ad = c.Admins.Find(admin.Id);
            ad.Kullanici = admin.Kullanici;
            ad.Sifre = admin.Sifre;
            c.SaveChanges();
            return RedirectToAction("AdminListesi");
        }



    }
}