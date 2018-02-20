using Microsoft.AspNet.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{
    public class SerialsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
       
        // GET: SerialsController22
        public ActionResult Index()
        {
            
            try
            {
                HttpContext.Request.Cookies["id"].Expires.AddMonths(1);
                var Cookie = HttpContext.Request.Cookies["id"].Value;
            }
            catch(Exception)  
            {
                Guid g = Guid.NewGuid();
                string CookieId = Convert.ToBase64String(g.ToByteArray()).Replace("=", "").Replace("+", "");
                HttpContext.Response.Cookies["id"].Value = CookieId;
            }
            var temp = db.Serials.ToList();
            return View(temp);
        }

        // GET: SerialsController22/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serial serial = db.Serials.Find(id);
            

            if (serial == null)
            {
                return HttpNotFound();
            }
            return View(serial);
        }

        // GET: SerialsController22/Create
        public ActionResult Create()
        {
            ViewBag.ganers = db.Ganers.ToList();
            ViewBag.seazons = db.Seazons.ToList();
            return View();
        }

        // POST: SerialsController22/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, [Bind(Include = "Name,EnglishName,Coments,YearsOfEdition")] Serial serial, 
        List<string> ganers, List<int?> seazons, string Studio, string Director)
        {
            if (ModelState.IsValid)
            {


                var daseGaners = db.Ganers.Where(d => ganers.Contains(d.Name));
                var daseSeazons = db.Seazons.Where(d => seazons.Contains(d.Number));

                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                          Server.MapPath("~/Content/Images"), pic);
                file.SaveAs(path);
                Serial Tserial = new Serial()
                {
                    Name = serial.Name,
                    EnglishName = serial.EnglishName,
                    Coments = serial.Coments,
                    ImagePath = file.FileName,
                    YearsOfEdition = serial.YearsOfEdition
                };
                //// file is uploaded
                
                List<SerialSeazon> seaz = new List<SerialSeazon>();
                foreach (var item in daseSeazons)
                {
                    seaz.Add(
                        new SerialSeazon()
                        {
                            Serial = Tserial,
                            Seazon = item
                        });
                }
                List<SerialGaner> sg = new List<SerialGaner>();
                foreach (var item in daseGaners)
                {
                    sg.Add(
                        new SerialGaner()
                        {
                            Serial = Tserial,
                            Ganer = item
                        });
                }
                if (Director != "")
                {
                    Director d = new Director() { Name = Director };
                    Tserial.Director = d;
                    db.Directors.Add(d);
                }
                if (Studio != "")
                {
                    Studio s = new Studio() { Name = Studio };
                    Tserial.Studio = s;
                    db.Studios.Add(s);
                }
                db.Serials.Add(serial);
                db.SerialsSeazons.AddRange(seaz);
                db.SerialGaners.AddRange(sg);
                db.SaveChanges();
                ViewBag.Mesage = "Сериал создан";
                return RedirectToAction("Edit","Serials",db.Serials.Where(x => x.Name == serial.Name).FirstOrDefault().SerialId);
            }

            return View(serial);
        }

        // GET: SerialsController22/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serial serial = db.Serials.Find(id);
            if (serial == null)
            {
                return HttpNotFound();
            }
            ViewBag.Seazons = db.Seazons.ToList();
            ViewBag.Ganers = db.Ganers.ToList();

            return View(serial);
        }

        // POST: SerialsController22/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase file, [Bind(Include = "SerialId,Name,EnglishName,Coments,Director,Studio,YearsOfEdition")] Serial serial,
        List<int> ganers, List <int> seazons)
        {
            if (ModelState.IsValid)
            {
                if (serial.Director.Name!="")
                {
                    db.Directors.Add(new Director() { Name = serial.Director.Name });
                    db.SaveChanges();
                }
                if (serial.Studio.Name != "")
                {
                    db.Studios.Add(new Studio() { Name = serial.Studio.Name });
                    db.SaveChanges();
                }
                if (ganers != null)
                {
                    var ser = db.Serials.Find(serial.SerialId);
                    if (ganers.Count == 0)
                    {
                        db.SerialGaners.RemoveRange(ser.SerialGaners);
                    }
                    else
                    {
                        List<Ganer> TGaners;
                        TGaners = ser.SerialGaners.Where(d => ganers.Contains(d.GanerId))
                                                    .Select(d => d.Ganer).ToList();
                        List<SerialGaner> serialganer = new List<SerialGaner>();
                        foreach (var item in TGaners)
                        {
                            serialganer.Add(new SerialGaner() { Serial = ser, Ganer = item });
                        }
                        db.SerialGaners.RemoveRange(ser.SerialGaners);
                        db.SerialGaners.AddRange(serialganer);
                    
                    }
                }

                if (seazons != null)
                {
                    var ser = db.Serials.Find(serial.SerialId);
                    if (seazons.Count == 0)
                    {
                        db.SerialsSeazons.RemoveRange(ser.SerialSeazons);
                    }
                    else
                    {
                        List<Seazon> TSeazons;
                        TSeazons = ser.SerialSeazons.Where(d => seazons.Contains(Convert.ToInt32(d.SeazonId)))
                                                    .Select(d => d.Seazon).ToList();
                        List<SerialSeazon> serialseazon = new List<SerialSeazon>();
                        foreach (var item in TSeazons)
                        {
                            serialseazon.Add(new SerialSeazon() { Serial = ser, Seazon = item });
                        }
                        db.SerialsSeazons.RemoveRange(ser.SerialSeazons);
                        db.SerialsSeazons.AddRange(serialseazon);
                    }
                }
                if (file != null)
                {
                    var ser = db.Serials.Find(serial.SerialId);
                    System.IO.File.Delete("~/Content/Images" + ser.ImagePath);

                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(
                        Server.MapPath("~/Content/Images"), pic);

                    ser.ImagePath = file.FileName;
                    file.SaveAs(path);
                }

            
                db.Entry(serial).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Mesage = "Данные Сохранены";
                return RedirectToAction("Edit/"+serial.SerialId);
            }
            
            return View(serial);
        }

        // GET: SerialsController22/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serial serial = db.Serials.Find(id);
            if (serial == null)
            {
                return HttpNotFound();
            }
            return View(serial);
        }

        // POST: SerialsController22/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Serial serial = db.Serials.Find(id);
            
            var sg = db.SerialGaners.Where(x => x.SerialId == serial.SerialId).ToList();
            foreach (var item in sg)
            {
                db.SerialGaners.Remove(item);
            }
            var ss = db.SerialsSeazons.Where(x => x.SerialId == serial.SerialId).ToList();
            foreach (var item in ss)
            {
                db.SerialsSeazons.Remove(item);
            }
            db.Serials.Remove(serial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public ActionResult Search(string name, int page=1)
        {
            int pageSize = 3;
            var serial = db.Serials.Where(x => x.Name.Contains(name)).OrderBy(x=>x.Name).ToList();
         
                var serialPerPages = serial.Skip((page - 1) * pageSize).Take(pageSize);
                PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = serial.Count };
                SearchViewModel svm = new SearchViewModel { PageInfo = pageInfo, Serials = serialPerPages };
                ViewBag.SearchName = name;
                return View(svm);
            
           
        }

        public ActionResult Like(int id)
        {
            var a = User.Identity.GetUserId();
            string HasCook = HttpContext.Request.Cookies["id"].Value;

            var serial = db.Serials.Find(id);
            if (serial == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //заходил ли пользователь
            var Cook = db.Cookies.Where(x => x.Name == HasCook).FirstOrDefault();
            if (Cook != null)
            {
                //ставил ли лайк этому сериалу
                var flag = db.CookieSerials.Where(x => x.Cookie.Name == Cook.Name && x.SerialId == id).FirstOrDefault();
                //если ставил то возвращаем рейтинг
                if (flag != null)
                {

                    ViewBag.Result = serial.Rate;

                }
                else
                {
                    var cook = new Models.Cookie() { Name = HasCook };
                    db.CookieSerials.Add(new CookieSerial() { Cookie = cook, Serial = serial });
                    //иначе возвращаем рейтинг +1
                    //если рейтинг сериала null
                    serial.Rate += 1;
                    db.SaveChanges();
                    ViewBag.Result = serial.Rate;
                }
            }
            else
            {
                var cook = new Models.Cookie() { Name = HasCook };
                db.Cookies.Add(cook);
                db.CookieSerials.Add(new CookieSerial() { Cookie = cook, Serial = serial });

                serial.Rate += 1;
                db.SaveChanges();
                ViewBag.Result = serial.Rate;
            }
           
            return PartialView();
        }
        public ActionResult Menu()
        {
           var gans = db.Ganers.ToList();
            return PartialView(gans);
        }
        public ActionResult Tag(int id, int page = 1)
        {
            int pageSize = 3;
            var serial = db.SerialGaners.Where(x => x.GanerId == id).Select(x => x.Serial).OrderBy(x => x.Name).ToList();
            var serialPerPages = serial.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = serial.Count };
            SearchViewModel svm = new SearchViewModel { PageInfo = pageInfo, Serials = serialPerPages };
            ViewBag.TagId = id;
            ViewBag.TagName = db.Ganers.Where(x => x.GanerId == id).First().Name;
            return View(svm);
        }
        public ActionResult TopTen()
        {
            var serials = db.Serials.Take(10).OrderByDescending(x => x.Rate);
            return View(serials);
        }
        //public ActionResult NewSerias()
        //{

        //}
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private byte[] imageToByteArray(Image imageIn)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        //    return ms.ToArray();
        //}

        //private Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    MemoryStream ms = new MemoryStream(byteArrayIn);
        //    Image returnImage = Image.FromStream(ms);
        //    return returnImage;
        //}
    }
}
