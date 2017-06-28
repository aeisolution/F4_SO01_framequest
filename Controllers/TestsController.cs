using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using frameQuest.Models;
using frameQuest.ViewModels;

namespace frameQuest.Controllers
{
    public class TestsController : Controller
    {
        private frameQuestContext db = new frameQuestContext();

        // GET: Tests
        public ActionResult Index()
        {
            var tests = db.Tests.Include(t => t.Argomento).Include(t => t.Docente).Include(t => t.Fase);
            return View(tests.ToList());
        }

        // GET: Tests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: Tests/Create
        public ActionResult Create()
        {
            ViewBag.IdArgomento = new SelectList(db.Argomenti, "IdArgomento", "Nome");
            ViewBag.IdDocente = new SelectList(db.Docenti, "IdDocente", "Nome");
            ViewBag.IdFase = new SelectList(db.Fasi, "IdFase", "Nome");
            return View();
        }

        // POST: Tests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTest,Nome,Descrizione,IdArgomento,IdFase,IdDocente")] Test test)
        {
            if (ModelState.IsValid)
            {
                db.Tests.Add(test);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdArgomento = new SelectList(db.Argomenti, "IdArgomento", "Nome", test.IdArgomento);
            ViewBag.IdDocente = new SelectList(db.Docenti, "IdDocente", "Nome", test.IdDocente);
            ViewBag.IdFase = new SelectList(db.Fasi, "IdFase", "Nome", test.IdFase);
            return View(test);
        }

        // GET: Tests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdArgomento = new SelectList(db.Argomenti, "IdArgomento", "Nome", test.IdArgomento);
            ViewBag.IdDocente = new SelectList(db.Docenti, "IdDocente", "Nome", test.IdDocente);
            ViewBag.IdFase = new SelectList(db.Fasi, "IdFase", "Nome", test.IdFase);
            return View(test);
        }

        // POST: Tests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTest,Nome,Descrizione,IdArgomento,IdFase,IdDocente")] Test test)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdArgomento = new SelectList(db.Argomenti, "IdArgomento", "Nome", test.IdArgomento);
            ViewBag.IdDocente = new SelectList(db.Docenti, "IdDocente", "Nome", test.IdDocente);
            ViewBag.IdFase = new SelectList(db.Fasi, "IdFase", "Nome", test.IdFase);
            return View(test);
        }

        // GET: Tests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: Tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test test = db.Tests.Find(id);
            db.Tests.Remove(test);
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

        // ---------------------------------
        // Gestione Domande
        public ActionResult DomandaCreate(DomandaDto domanda)
        {
            var test = db.Tests.Find(domanda.IdTest);
            var dom = new Domanda
            {
                Testo = domanda.Testo,
                Punti = domanda.Punti,
                IdTest = domanda.IdTest,
                Test = test,
                Risposte = new List<Risposta>()
            };

            if (!String.IsNullOrEmpty(domanda.Ris1_Testo))
            {
                dom.Risposte.Add(new Risposta {
                                        Testo = domanda.Ris1_Testo,
                                        Esatta = domanda.Ris1_Esatta
                                 });
            }

            if (!String.IsNullOrEmpty(domanda.Ris2_Testo))
            {
                dom.Risposte.Add(new Risposta
                {
                    Testo = domanda.Ris2_Testo,
                    Esatta = domanda.Ris2_Esatta
                });
            }

            if (!String.IsNullOrEmpty(domanda.Ris3_Testo))
            {
                dom.Risposte.Add(new Risposta
                {
                    Testo = domanda.Ris3_Testo,
                    Esatta = domanda.Ris3_Esatta
                });
            }

            if (!String.IsNullOrEmpty(domanda.Ris4_Testo))
            {
                dom.Risposte.Add(new Risposta
                {
                    Testo = domanda.Ris4_Testo,
                    Esatta = domanda.Ris4_Esatta
                });
            }

            db.Domande.Add(dom);
            db.SaveChanges();
            return RedirectToAction("Details", new { id = domanda.IdTest });
        }
    }
}
