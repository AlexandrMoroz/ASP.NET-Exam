using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class SeriasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Serias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seria seria = db.Serias.Find(id);
            if (seria == null)
            {
                return HttpNotFound();
            }
            return View(seria);
        }

        // GET: Serias/Create
        public ActionResult Create(int serialid, int seazonid, string returnUrl)
        {
            var temp = db.SerialsSeazons.Where(s => s.SerialId == serialid && s.SeazonId == seazonid).First();
            if (temp != null)
            {
                ViewBag.SerialId = serialid;
                ViewBag.Seazonid = seazonid;
                ViewBag.returnUrl = returnUrl;
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: Serias/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Date")] Seria seria, int serialid, int seazonid, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.SerialsSeazons.Where(s => s.SerialId == serialid && s.SeazonId == seazonid).First().Serias.Add(seria);
                db.SaveChanges();
                return Redirect(returnUrl);
            }

            return View(seria);
        }

        // GET: Serias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seria seria = db.Serias.Find(id);
            if (seria == null)
            {
                return HttpNotFound();
            }
            return View(seria);
        }

        // POST: Serias/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SeriaId,Name,Date")] Seria seria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seria);
        }

        // GET: Serias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seria seria = db.Serias.Find(id);
            if (seria == null)
            {
                return HttpNotFound();
            }
            return View(seria);
        }

        // POST: Serias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seria seria = db.Serias.Find(id);
            db.Serias.Remove(seria);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
