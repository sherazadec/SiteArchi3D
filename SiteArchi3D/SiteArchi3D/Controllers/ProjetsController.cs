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
    public class ProjetsController : Controller
    {
        private ProjetSiteArchi3DEntities db = new ProjetSiteArchi3DEntities();

        // GET: Projets
        public ActionResult Index()
        {
            var projet = db.Projet.Include(p => p.Commentaires).Include(p => p.Liste_de_Prestataires);
            return View(projet.ToList());
        }

        // GET: Projets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet projet = db.Projet.Find(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            return View(projet);
        }

        // GET: Projets/Create
        public ActionResult Create()
        {
            ViewBag.xidCommentaires = new SelectList(db.Commentaires, "id", "Commentaires1");
            ViewBag.Liste_prestataires = new SelectList(db.Liste_de_Prestataires, "id", "Prestataires");
            return View();
        }

        // POST: Projets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProjet,Promoteur,Date_début,Date_fin,Avancement,Liste_prestataires,xidCommentaires")] Projet projet)
        {
            if (ModelState.IsValid)
            {
                db.Projet.Add(projet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.xidCommentaires = new SelectList(db.Commentaires, "id", "Commentaires1", projet.xidCommentaires);
            ViewBag.Liste_prestataires = new SelectList(db.Liste_de_Prestataires, "id", "Prestataires", projet.Liste_prestataires);
            return View(projet);
        }

        // GET: Projets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet projet = db.Projet.Find(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            ViewBag.xidCommentaires = new SelectList(db.Commentaires, "id", "Commentaires1", projet.xidCommentaires);
            ViewBag.Liste_prestataires = new SelectList(db.Liste_de_Prestataires, "id", "Prestataires", projet.Liste_prestataires);
            return View(projet);
        }

        // POST: Projets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProjet,Promoteur,Date_début,Date_fin,Avancement,Liste_prestataires,xidCommentaires")] Projet projet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.xidCommentaires = new SelectList(db.Commentaires, "id", "Commentaires1", projet.xidCommentaires);
            ViewBag.Liste_prestataires = new SelectList(db.Liste_de_Prestataires, "id", "Prestataires", projet.Liste_prestataires);
            return View(projet);
        }

        // GET: Projets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet projet = db.Projet.Find(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            return View(projet);
        }

        // POST: Projets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projet projet = db.Projet.Find(id);
            db.Projet.Remove(projet);
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
