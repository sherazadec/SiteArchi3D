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
    public class ModélisateursController : Controller
    {
        private ProjetSiteArchi3DEntities db = new ProjetSiteArchi3DEntities();

        // GET: Modélisateurs
        public ActionResult Index()
        {
            var modélisateurs = db.Modélisateurs.Include(m => m.Account);
            return View(modélisateurs.ToList());
        }

        // GET: Modélisateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modélisateurs modélisateurs = db.Modélisateurs.Find(id);
            if (modélisateurs == null)
            {
                return HttpNotFound();
            }
            return View(modélisateurs);
        }

        // GET: Modélisateurs/Create
        public ActionResult Create()
        {
            ViewBag.xid = new SelectList(db.Account, "id", "Nom");
            return View();
        }

        // POST: Modélisateurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idModélisateur,xid")] Modélisateurs modélisateurs)
        {
            if (ModelState.IsValid)
            {
                db.Modélisateurs.Add(modélisateurs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.xid = new SelectList(db.Account, "id", "Nom", modélisateurs.xid);
            return View(modélisateurs);
        }

        // GET: Modélisateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modélisateurs modélisateurs = db.Modélisateurs.Find(id);
            if (modélisateurs == null)
            {
                return HttpNotFound();
            }
            ViewBag.xid = new SelectList(db.Account, "id", "Nom", modélisateurs.xid);
            return View(modélisateurs);
        }

        // POST: Modélisateurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idModélisateur,xid")] Modélisateurs modélisateurs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modélisateurs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.xid = new SelectList(db.Account, "id", "Nom", modélisateurs.xid);
            return View(modélisateurs);
        }

        // GET: Modélisateurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modélisateurs modélisateurs = db.Modélisateurs.Find(id);
            if (modélisateurs == null)
            {
                return HttpNotFound();
            }
            return View(modélisateurs);
        }

        // POST: Modélisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modélisateurs modélisateurs = db.Modélisateurs.Find(id);
            db.Modélisateurs.Remove(modélisateurs);
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
