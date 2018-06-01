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
    public class Liste_de_PrestatairesController : Controller
    {
        private ProjetSiteArchi3DEntities db = new ProjetSiteArchi3DEntities();

        // GET: Liste_de_Prestataires
        public ActionResult Index()
        {
            var liste_de_Prestataires = db.Liste_de_Prestataires.Include(l => l.Architecte).Include(l => l.Modélisateurs);
            return View(liste_de_Prestataires.ToList());
        }

        // GET: Liste_de_Prestataires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Liste_de_Prestataires liste_de_Prestataires = db.Liste_de_Prestataires.Find(id);
            if (liste_de_Prestataires == null)
            {
                return HttpNotFound();
            }
            return View(liste_de_Prestataires);
        }

        // GET: Liste_de_Prestataires/Create
        public ActionResult Create()
        {
            ViewBag.xidPrestas = new SelectList(db.Architecte, "idArchitecte", "idArchitecte");
            ViewBag.xidPrestas = new SelectList(db.Modélisateurs, "idModélisateur", "idModélisateur");
            return View();
        }

        // POST: Liste_de_Prestataires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Prestataires,xidPrestas")] Liste_de_Prestataires liste_de_Prestataires)
        {
            if (ModelState.IsValid)
            {
                db.Liste_de_Prestataires.Add(liste_de_Prestataires);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.xidPrestas = new SelectList(db.Architecte, "idArchitecte", "idArchitecte", liste_de_Prestataires.xidPrestas);
            ViewBag.xidPrestas = new SelectList(db.Modélisateurs, "idModélisateur", "idModélisateur", liste_de_Prestataires.xidPrestas);
            return View(liste_de_Prestataires);
        }

        // GET: Liste_de_Prestataires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Liste_de_Prestataires liste_de_Prestataires = db.Liste_de_Prestataires.Find(id);
            if (liste_de_Prestataires == null)
            {
                return HttpNotFound();
            }
            ViewBag.xidPrestas = new SelectList(db.Architecte, "idArchitecte", "idArchitecte", liste_de_Prestataires.xidPrestas);
            ViewBag.xidPrestas = new SelectList(db.Modélisateurs, "idModélisateur", "idModélisateur", liste_de_Prestataires.xidPrestas);
            return View(liste_de_Prestataires);
        }

        // POST: Liste_de_Prestataires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Prestataires,xidPrestas")] Liste_de_Prestataires liste_de_Prestataires)
        {
            if (ModelState.IsValid)
            {
                db.Entry(liste_de_Prestataires).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.xidPrestas = new SelectList(db.Architecte, "idArchitecte", "idArchitecte", liste_de_Prestataires.xidPrestas);
            ViewBag.xidPrestas = new SelectList(db.Modélisateurs, "idModélisateur", "idModélisateur", liste_de_Prestataires.xidPrestas);
            return View(liste_de_Prestataires);
        }

        // GET: Liste_de_Prestataires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Liste_de_Prestataires liste_de_Prestataires = db.Liste_de_Prestataires.Find(id);
            if (liste_de_Prestataires == null)
            {
                return HttpNotFound();
            }
            return View(liste_de_Prestataires);
        }

        // POST: Liste_de_Prestataires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Liste_de_Prestataires liste_de_Prestataires = db.Liste_de_Prestataires.Find(id);
            db.Liste_de_Prestataires.Remove(liste_de_Prestataires);
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
