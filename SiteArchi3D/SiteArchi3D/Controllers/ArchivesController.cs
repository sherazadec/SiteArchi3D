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
    public class ArchivesController : Controller
    {
        private ProjetSiteArchi3DEntities db = new ProjetSiteArchi3DEntities();

        // GET: Archives
        public ActionResult Index()
        {
            var archives = db.Archives.Include(a => a.Projet);
            return View(archives.ToList());
        }

        // GET: Archives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Archives archives = db.Archives.Find(id);
            if (archives == null)
            {
                return HttpNotFound();
            }
            return View(archives);
        }

        // GET: Archives/Create
        public ActionResult Create()
        {
            ViewBag.xidProjetFini = new SelectList(db.Projet, "id", "Promoteur");
            return View();
        }

        // POST: Archives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,xidProjetFini,Fichiers,Images,ListePrestatairesProjet")] Archives archives)
        {
            if (ModelState.IsValid)
            {
                db.Archives.Add(archives);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.xidProjetFini = new SelectList(db.Projet, "id", "Promoteur", archives.xidProjetFini);
            return View(archives);
        }

        // GET: Archives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Archives archives = db.Archives.Find(id);
            if (archives == null)
            {
                return HttpNotFound();
            }
            ViewBag.xidProjetFini = new SelectList(db.Projet, "id", "Promoteur", archives.xidProjetFini);
            return View(archives);
        }

        // POST: Archives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,xidProjetFini,Fichiers,Images,ListePrestatairesProjet")] Archives archives)
        {
            if (ModelState.IsValid)
            {
                db.Entry(archives).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.xidProjetFini = new SelectList(db.Projet, "id", "Promoteur", archives.xidProjetFini);
            return View(archives);
        }

        // GET: Archives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Archives archives = db.Archives.Find(id);
            if (archives == null)
            {
                return HttpNotFound();
            }
            return View(archives);
        }

        // POST: Archives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Archives archives = db.Archives.Find(id);
            db.Archives.Remove(archives);
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
