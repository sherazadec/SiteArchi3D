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
    public class CommentairesController : Controller
    {
        private ProjetSiteArchi3DEntities db = new ProjetSiteArchi3DEntities();

        // GET: Commentaires
        public ActionResult Index()
        {
            var commentaires = db.Commentaires.Include(c => c.Account);
            return View(commentaires.ToList());
        }

        // GET: Commentaires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commentaires commentaires = db.Commentaires.Find(id);
            if (commentaires == null)
            {
                return HttpNotFound();
            }
            return View(commentaires);
        }

        // GET: Commentaires/Create
        public ActionResult Create()
        {
            ViewBag.xidPersonnes = new SelectList(db.Account, "id", "Nom");
            return View();
        }

        // POST: Commentaires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,xidPersonnes,Commentaires1")] Commentaires commentaires)
        {
            if (ModelState.IsValid)
            {
                db.Commentaires.Add(commentaires);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.xidPersonnes = new SelectList(db.Account, "id", "Nom", commentaires.xidPersonnes);
            return View(commentaires);
        }

        // GET: Commentaires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commentaires commentaires = db.Commentaires.Find(id);
            if (commentaires == null)
            {
                return HttpNotFound();
            }
            ViewBag.xidPersonnes = new SelectList(db.Account, "id", "Nom", commentaires.xidPersonnes);
            return View(commentaires);
        }

        // POST: Commentaires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,xidPersonnes,Commentaires1")] Commentaires commentaires)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentaires).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.xidPersonnes = new SelectList(db.Account, "id", "Nom", commentaires.xidPersonnes);
            return View(commentaires);
        }

        // GET: Commentaires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commentaires commentaires = db.Commentaires.Find(id);
            if (commentaires == null)
            {
                return HttpNotFound();
            }
            return View(commentaires);
        }

        // POST: Commentaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Commentaires commentaires = db.Commentaires.Find(id);
            db.Commentaires.Remove(commentaires);
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
