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
    public class PromoteursController : Controller
    {
        private ProjetSiteArchi3DEntities db = new ProjetSiteArchi3DEntities();

        // GET: Promoteurs
        public ActionResult Index()
        {
            var promoteur = db.Promoteur.Include(p => p.Personnes);
            return View(promoteur.ToList());
        }

        // GET: Promoteurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promoteur promoteur = db.Promoteur.Find(id);
            if (promoteur == null)
            {
                return HttpNotFound();
            }
            return View(promoteur);
        }

        // GET: Promoteurs/Create
        public ActionResult Create()
        {
            ViewBag.xid = new SelectList(db.Personnes, "id", "Nom");
            return View();
        }

        // POST: Promoteurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPromoteur,xid,admin")] Promoteur promoteur)
        {
            if (ModelState.IsValid)
            {
                db.Promoteur.Add(promoteur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.xid = new SelectList(db.Personnes, "id", "Nom", promoteur.xid);
            return View(promoteur);
        }

        // GET: Promoteurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promoteur promoteur = db.Promoteur.Find(id);
            if (promoteur == null)
            {
                return HttpNotFound();
            }
            ViewBag.xid = new SelectList(db.Personnes, "id", "Nom", promoteur.xid);
            return View(promoteur);
        }

        // POST: Promoteurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPromoteur,xid,admin")] Promoteur promoteur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promoteur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.xid = new SelectList(db.Personnes, "id", "Nom", promoteur.xid);
            return View(promoteur);
        }

        // GET: Promoteurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promoteur promoteur = db.Promoteur.Find(id);
            if (promoteur == null)
            {
                return HttpNotFound();
            }
            return View(promoteur);
        }

        // POST: Promoteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Promoteur promoteur = db.Promoteur.Find(id);
            db.Promoteur.Remove(promoteur);
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
