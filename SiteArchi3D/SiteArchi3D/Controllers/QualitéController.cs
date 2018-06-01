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
    public class QualitéController : Controller
    {
        private ProjetSiteArchi3DEntities db = new ProjetSiteArchi3DEntities();

        // GET: Qualité
        public ActionResult Index()
        {
            return View(db.Qualité.ToList());
        }

        // GET: Qualité/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualité qualité = db.Qualité.Find(id);
            if (qualité == null)
            {
                return HttpNotFound();
            }
            return View(qualité);
        }

        // GET: Qualité/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Qualité/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Qualité1")] Qualité qualité)
        {
            if (ModelState.IsValid)
            {
                db.Qualité.Add(qualité);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qualité);
        }

        // GET: Qualité/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualité qualité = db.Qualité.Find(id);
            if (qualité == null)
            {
                return HttpNotFound();
            }
            return View(qualité);
        }

        // POST: Qualité/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Qualité1")] Qualité qualité)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qualité).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qualité);
        }

        // GET: Qualité/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualité qualité = db.Qualité.Find(id);
            if (qualité == null)
            {
                return HttpNotFound();
            }
            return View(qualité);
        }

        // POST: Qualité/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Qualité qualité = db.Qualité.Find(id);
            db.Qualité.Remove(qualité);
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
