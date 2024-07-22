using Microsoft.AspNet.Identity;
using MvcRehber.Models;
using MvcRehber.Models.Context;
using MvcRehber.Models.Entities;
using MvcRehber.Models.KisiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcRehber.Controllers
{

    public class KisiController : Controller
    {
        MvcRehberContext db = new MvcRehberContext();
        // GET: Kisi
        public ActionResult Index()
        {
 
            //var currentUser = db.TBLUserInfoes.Select(x => x.Id).FirstOrDefault();
            var simdikikullanici= Convert.ToInt32(Session["IdSS"]);
            var kisiler = db.Kisiler.ToList();
            var model = new KisiIndexViewModel
            {
                Kisiler = db.Kisiler.Where(x => x.CurrentId  == simdikikullanici).ToList(),
                Sehirler = db.Sehirler.ToList(),
                //Kisiler = db.Kisiler.Where(x => x.CurrentId == currentUser),
            };
            return View(model);
        }


        [HttpGet]
        public ActionResult Ekle()
        {
            var model = new KisiEkleViewModel
            {
                Kisi = new Kisi(),
                Sehirler = db.Sehirler.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Ekle(Kisi kisi)
        {
            try
            {
                if (!(kisi.EmailAdres.Contains("@")))
                {
                    TempData["HataliMesaj"] = "E-postada @ işareti bulunmalıdır! Lütfen tekrar deneyin";
                }
                else
                {
                    //kisi.CurrentId= db.TBLUserInfoes.Select(x => x.Id).FirstOrDefault();
                    kisi.CurrentId= Convert.ToInt32(Session["IdSS"]);
                    db.Kisiler.Add(kisi);//böylece contextteki table oluşturan propertye viewden gelen verileri transfer etmiş oluyoruz
                    db.SaveChanges();// databasedeki değişikliği onaylayıp kaydetmiş oluyoruz.
                    TempData["BasariliMesaj"] = "Kayıt Başarılı";//ekleme başarılı olunca göstereceğimiz mesaj
                }
            }
            catch (Exception)
            {
                TempData["HataliMesaj"] = "Kayıt Başarısız";
            }


            //var orders = db.Orders.Where(i => i.UserName == User.Identity.Name).Select(i => new UserOrderModel()
            //{
            //    Id = i.Id,
            //    OrderNumber = i.OrderNumber,
            //    OrderDate = i.OrderDate,
            //    OrderState = i.OrderState,
            //    Total = i.Total
            //}).OrderByDescending(i => i.OrderDate).ToList();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            //öncelikle güncellenecek olan kayda erişmemiz gerekiyor bunun için index sayfasına yol ekliyoruz.
            var kisi = db.Kisiler.Find(id);
            if (kisi == null)
            {
                TempData["HataliMesaj"] = "Kayıt Bulunamadı";
                return RedirectToAction("Index");
            }
            var model = new KisiGuncelleViewModel
            {
                Kisi = kisi,
                Sehirler = db.Sehirler.ToList()
            };

            ViewBag.Sehirler = new SelectList(db.Sehirler.ToList(), "Id", "SehirAdi");
            return View(model);
        }

        [HttpPost]
        public ActionResult Guncelle(Kisi kisi)
        {
            var eskiKisi = db.Kisiler.Find(kisi.Id);
            if (eskiKisi == null)
            {
                TempData["HataliMesaj"] = "Kayıt Bulunamadı";
                return RedirectToAction("Index");
            }
            eskiKisi.Ad = kisi.Ad;
            eskiKisi.Soyad = kisi.Soyad;
            eskiKisi.EvTelefon = kisi.EvTelefon;
            eskiKisi.CepTelefon = kisi.CepTelefon;
            eskiKisi.IsTelefon = kisi.IsTelefon;
            eskiKisi.EmailAdres = kisi.EmailAdres;
            eskiKisi.Adres = kisi.Adres;
            eskiKisi.SehirId = kisi.SehirId;
            db.SaveChanges();

            TempData["BasariliMesaj"] = "Kayıt Başarılı";

            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var kisi = db.Kisiler.Find(id);
            if (kisi == null)
            {
                TempData["HataliMesaj"] = "Kayıt Bulunamadı";
                return RedirectToAction("Index");
            }
            db.Kisiler.Remove(kisi);
            db.SaveChanges();

            TempData["BasariliMesaj"] = "Kişi silindi. Liste Güncellendi.";

            return RedirectToAction("Index");
        }



    }
}