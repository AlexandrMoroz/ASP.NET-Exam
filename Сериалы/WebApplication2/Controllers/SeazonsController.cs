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
    public class SeazonsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Seazons
        public ActionResult Index()
        {
            return View(db.Seazons.ToList());
        }

        // GET: Seazons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seazon seazon = db.Seazons.Find(id);
            if (seazon == null)
            {
                return HttpNotFound();
            }
            return View(seazon);
        }

        // GET: Seazons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seazons/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SeazonId,Number")] Seazon seazon)
        {
            if (ModelState.IsValid)
            {
                db.Seazons.Add(seazon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seazon);
        }

        // GET: Seazons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seazon seazon = db.Seazons.Find(id);
            if (seazon == null)
            {
                return HttpNotFound();
            }
            return View(seazon);
        }

        // POST: Seazons/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SeazonId,Number")] Seazon seazon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seazon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seazon);
        }

        // GET: Seazons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seazon seazon = db.Seazons.Find(id);
            if (seazon == null)
            {
                return HttpNotFound();
            }
            return View(seazon);
        }

        // POST: Seazons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seazon seazon = db.Seazons.Find(id);
            db.Seazons.Remove(seazon);
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
