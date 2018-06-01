using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SiteArchi3D;

namespace SiteArchi3D.Controllers
{
    public class ArchitectesController : Controller
    {
        private ProjetSiteArchi3DEntities db = new ProjetSiteArchi3DEntities();

        // GET: Architectes
        public ActionResult Index()
        {
            var architecte = db.Architecte.Include(a => a.Personnes);
            return View(architecte.ToList());
        }

        // GET: Architectes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Architecte architecte = db.Architecte.Find(id);
            if (architecte == null)
            {
                return HttpNotFound();
            }
            return View(architecte);
        }

        // GET: Architectes/Create
        public ActionResult Create()
        {
            ViewBag.xid = new SelectList(db.Personnes, "id", "Nom");
            return View();
        }

        // POST: Architectes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idArchitecte,Numéro_Architecte,xid")] Architecte architecte)
        {
            if (ModelState.IsValid)
            {
                db.Architecte.Add(architecte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.xid = new SelectList(db.Personnes, "id", "Nom", architecte.xid);
            return View(architecte);
        }

        // GET: Architectes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Architecte architecte = db.Architecte.Find(id);
            if (architecte == null)
            {
                return HttpNotFound();
            }
            ViewBag.xid = new SelectList(db.Personnes, "id", "Nom", architecte.xid);
            return View(architecte);
        }

        // POST: Architectes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idArchitecte,Numéro_Architecte,xid")] Architecte architecte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(architecte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.xid = new SelectList(db.Personnes, "id", "Nom", architecte.xid);
            return View(architecte);
        }

        // GET: Architectes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Architecte architecte = db.Architecte.Find(id);
            if (architecte == null)
            {
                return HttpNotFound();
            }
            return View(architecte);
        }

        // POST: Architectes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Architecte architecte = db.Architecte.Find(id);
            db.Architecte.Remove(architecte);
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
