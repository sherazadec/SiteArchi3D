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
    public class PersonnesController : Controller
    {
        private ProjetSiteArchi3DEntities db = new ProjetSiteArchi3DEntities();

        // GET: Personnes
        public ActionResult Index()
        {
            var personnes = db.Personnes.Include(p => p.Qualité1);
            return View(personnes.ToList());
        }

        // GET: Personnes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personnes personnes = db.Personnes.Find(id);
            if (personnes == null)
            {
                return HttpNotFound();
            }
            return View(personnes);
        }

        // GET: Personnes/Create
        public ActionResult Create()
        {
            ViewBag.Qualité = new SelectList(db.Qualité, "id", "Qualité1");
            return View();
        }

        // POST: Personnes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nom,Prénom,Login,Qualité")] Personnes personnes)
        {
            if (ModelState.IsValid)
            {
                db.Personnes.Add(personnes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Qualité = new SelectList(db.Qualité, "id", "Qualité1", personnes.Qualité);
            return View(personnes);
        }

        // GET: Personnes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personnes personnes = db.Personnes.Find(id);
            if (personnes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Qualité = new SelectList(db.Qualité, "id", "Qualité1", personnes.Qualité);
            return View(personnes);
        }

        // POST: Personnes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nom,Prénom,Login,Qualité")] Personnes personnes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personnes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Qualité = new SelectList(db.Qualité, "id", "Qualité1", personnes.Qualité);
            return View(personnes);
        }

        // GET: Personnes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personnes personnes = db.Personnes.Find(id);
            if (personnes == null)
            {
                return HttpNotFound();
            }
            return View(personnes);
        }

        // POST: Personnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personnes personnes = db.Personnes.Find(id);
            db.Personnes.Remove(personnes);
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
