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
    public class ArgomentiController : Controller
    {
        private frameQuestContext db = new frameQuestContext();

        // GET: Argomenti
        public ActionResult Index()
        {
            return View(db.Argomenti.ToList());
        }

        // GET: Argomenti/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Argomento argomento = db.Argomenti.Find(id);
            if (argomento == null)
            {
                return HttpNotFound();
            }
            return View(argomento);
        }

        // GET: Argomenti/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Argomenti/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdArgomento,Nome")] Argomento argomento)
        {
            if (ModelState.IsValid)
            {
                db.Argomenti.Add(argomento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(argomento);
        }

        // GET: Argomenti/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Argomento argomento = db.Argomenti.Find(id);
            if (argomento == null)
            {
                return HttpNotFound();
            }
            return View(argomento);
        }

        // POST: Argomenti/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdArgomento,Nome")] Argomento argomento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(argomento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(argomento);
        }

        // GET: Argomenti/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Argomento argomento = db.Argomenti.Find(id);
            if (argomento == null)
            {
                return HttpNotFound();
            }
            return View(argomento);
        }

        // POST: Argomenti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Argomento argomento = db.Argomenti.Find(id);
            db.Argomenti.Remove(argomento);
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
