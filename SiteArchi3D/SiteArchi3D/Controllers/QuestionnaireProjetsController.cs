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
    public class QuestionnaireProjetsController : Controller
    {
        private ProjetSiteArchi3DEntities db = new ProjetSiteArchi3DEntities();

        // GET: QuestionnaireProjets
        public ActionResult Index()
        {
            var questionnaireProjet = db.QuestionnaireProjet.Include(q => q.Création_de_Projet);
            return View(questionnaireProjet.ToList());
        }

        // GET: QuestionnaireProjets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionnaireProjet questionnaireProjet = db.QuestionnaireProjet.Find(id);
            if (questionnaireProjet == null)
            {
                return HttpNotFound();
            }
            return View(questionnaireProjet);
        }

        // GET: QuestionnaireProjets/Create
        public ActionResult Create()
        {
            ViewBag.xidCréaProjet = new SelectList(db.Création_de_Projet, "idProjet", "Questionnaire");
            return View();
        }

        // POST: QuestionnaireProjets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idQuestionnaire,Question1,Question2,Question3,Question4,Question5,Question6,Question7,Question8,Question9,Question10")] QuestionnaireProjet questionnaireProjet)
        {
            if (ModelState.IsValid)
            {
                db.QuestionnaireProjet.Add(questionnaireProjet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.xidCréaProjet = new SelectList(db.Création_de_Projet, "idProjet", "Questionnaire", questionnaireProjet.xidCréaProjet);
            return View(questionnaireProjet);
        }

        // GET: QuestionnaireProjets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionnaireProjet questionnaireProjet = db.QuestionnaireProjet.Find(id);
            if (questionnaireProjet == null)
            {
                return HttpNotFound();
            }
            ViewBag.xidCréaProjet = new SelectList(db.Création_de_Projet, "idProjet", "Questionnaire", questionnaireProjet.xidCréaProjet);
            return View(questionnaireProjet);
        }

        // POST: QuestionnaireProjets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idQuestionnaire,xidCréaProjet,Question1,Question2,Question3,Question4,Question5,Question6,Question7,Question8,Question9,Question10")] QuestionnaireProjet questionnaireProjet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionnaireProjet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.xidCréaProjet = new SelectList(db.Création_de_Projet, "idProjet", "Questionnaire", questionnaireProjet.xidCréaProjet);
            return View(questionnaireProjet);
        }

        // GET: QuestionnaireProjets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionnaireProjet questionnaireProjet = db.QuestionnaireProjet.Find(id);
            if (questionnaireProjet == null)
            {
                return HttpNotFound();
            }
            return View(questionnaireProjet);
        }

        // POST: QuestionnaireProjets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionnaireProjet questionnaireProjet = db.QuestionnaireProjet.Find(id);
            db.QuestionnaireProjet.Remove(questionnaireProjet);
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
