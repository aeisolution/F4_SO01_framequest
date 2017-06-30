using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using frameQuest.Models;

namespace frameQuest.Controllers
{
    public class SessioniController : Controller
    {
        private frameQuestContext db = new frameQuestContext();

        // GET: Sessioni
        public ActionResult Index()
        {
            var sessioni = db.Sessioni.Include(s => s.Test);
            return View(sessioni.ToList());
        }

        // GET: Sessioni/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sessione sessione = db.Sessioni.Find(id);
            if (sessione == null)
            {
                return HttpNotFound();
            }
            return View(sessione);
        }

        // GET: Sessioni/Create
        public ActionResult Create()
        {
            ViewBag.IdTest = new SelectList(db.Tests, "IdTest", "Nome");
            return View();
        }

        // POST: Sessioni/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSessione,Nominativo,Punteggio,IdTest")] Sessione sessione)
        {
            if (ModelState.IsValid)
            {
                db.Sessioni.Add(sessione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTest = new SelectList(db.Tests, "IdTest", "Nome", sessione.IdTest);
            return View(sessione);
        }

        // GET: Sessioni/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sessione sessione = db.Sessioni.Find(id);
            if (sessione == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTest = new SelectList(db.Tests, "IdTest", "Nome", sessione.IdTest);
            return View(sessione);
        }

        // POST: Sessioni/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSessione,Nominativo,Punteggio,IdTest")] Sessione sessione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sessione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTest = new SelectList(db.Tests, "IdTest", "Nome", sessione.IdTest);
            return View(sessione);
        }

        // GET: Sessioni/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sessione sessione = db.Sessioni.Find(id);
            if (sessione == null)
            {
                return HttpNotFound();
            }
            return View(sessione);
        }

        // POST: Sessioni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sessione sessione = db.Sessioni.Find(id);
            db.Sessioni.Remove(sessione);
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
