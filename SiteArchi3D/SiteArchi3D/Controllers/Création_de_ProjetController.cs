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
    public class Création_de_ProjetController : Controller
    {
        private ProjetSiteArchi3DEntities db = new ProjetSiteArchi3DEntities();

        // GET: Création_de_Projet
        public ActionResult Index()
        {
            var création_de_Projet = db.Création_de_Projet.Include(c => c.Liste_de_Prestataires).Include(c => c.Projet).Include(c => c.Promoteur);
            return View(création_de_Projet.ToList());
        }

        // GET: Création_de_Projet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Création_de_Projet création_de_Projet = db.Création_de_Projet.Find(id);
            if (création_de_Projet == null)
            {
                return HttpNotFound();
            }
            return View(création_de_Projet);
        }

        // GET: Création_de_Projet/Create
        public ActionResult Create()
        {
            ViewBag.Prestataires = new SelectList(db.Liste_de_Prestataires, "id", "Prestataires");
            ViewBag.xidProjet = new SelectList(db.Projet, "idProjet", "Promoteur");
            ViewBag.xidPromoteur = new SelectList(db.Promoteur, "idPromoteur", "idPromoteur");
            return View();
        }

        // POST: Création_de_Projet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,xidProjet,xidPromoteur,Prestataires,Questionnaire,uploadfichiers")] Création_de_Projet création_de_Projet)
        {
            if (ModelState.IsValid)
            {
                db.Création_de_Projet.Add(création_de_Projet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Prestataires = new SelectList(db.Liste_de_Prestataires, "id", "Prestataires", création_de_Projet.Prestataires);
            ViewBag.xidProjet = new SelectList(db.Projet, "idProjet", "Promoteur", création_de_Projet.xidProjet);
            ViewBag.xidPromoteur = new SelectList(db.Promoteur, "idPromoteur", "idPromoteur", création_de_Projet.xidPromoteur);
            return View(création_de_Projet);
        }

        // GET: Création_de_Projet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Création_de_Projet création_de_Projet = db.Création_de_Projet.Find(id);
            if (création_de_Projet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Prestataires = new SelectList(db.Liste_de_Prestataires, "id", "Prestataires", création_de_Projet.Prestataires);
            ViewBag.xidProjet = new SelectList(db.Projet, "idProjet", "Promoteur", création_de_Projet.xidProjet);
            ViewBag.xidPromoteur = new SelectList(db.Promoteur, "idPromoteur", "idPromoteur", création_de_Projet.xidPromoteur);
            return View(création_de_Projet);
        }

        // POST: Création_de_Projet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,xidProjet,xidPromoteur,Prestataires,Questionnaire,uploadfichiers")] Création_de_Projet création_de_Projet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(création_de_Projet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Prestataires = new SelectList(db.Liste_de_Prestataires, "id", "Prestataires", création_de_Projet.Prestataires);
            ViewBag.xidProjet = new SelectList(db.Projet, "idProjet", "Promoteur", création_de_Projet.xidProjet);
            ViewBag.xidPromoteur = new SelectList(db.Promoteur, "idPromoteur", "idPromoteur", création_de_Projet.xidPromoteur);
            return View(création_de_Projet);
        }

        // GET: Création_de_Projet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Création_de_Projet création_de_Projet = db.Création_de_Projet.Find(id);
            if (création_de_Projet == null)
            {
                return HttpNotFound();
            }
            return View(création_de_Projet);
        }

        // POST: Création_de_Projet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Création_de_Projet création_de_Projet = db.Création_de_Projet.Find(id);
            db.Création_de_Projet.Remove(création_de_Projet);
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
