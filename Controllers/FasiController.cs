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
    public class FasiController : Controller
    {
        private frameQuestContext db = new frameQuestContext();

        // GET: Fasi
        public ActionResult Index()
        {
            return View(db.Fasi.ToList());
        }

        // GET: Fasi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fase fase = db.Fasi.Find(id);
            if (fase == null)
            {
                return HttpNotFound();
            }
            return View(fase);
        }

        // GET: Fasi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fasi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFase,Nome")] Fase fase)
        {
            if (ModelState.IsValid)
            {
                db.Fasi.Add(fase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fase);
        }

        // GET: Fasi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fase fase = db.Fasi.Find(id);
            if (fase == null)
            {
                return HttpNotFound();
            }
            return View(fase);
        }

        // POST: Fasi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFase,Nome")] Fase fase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fase);
        }

        // GET: Fasi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fase fase = db.Fasi.Find(id);
            if (fase == null)
            {
                return HttpNotFound();
            }
            return View(fase);
        }

        // POST: Fasi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fase fase = db.Fasi.Find(id);
            db.Fasi.Remove(fase);
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
