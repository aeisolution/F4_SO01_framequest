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
    public class AlunniController : Controller
    {
        private frameQuestContext db = new frameQuestContext();

        // GET: Alunni
        public ActionResult Index(string query, string order)
        {
            IQueryable<Alunno> alunni = db.Alunnoes;

            // Filtro di ricerca
            if (!String.IsNullOrEmpty(query))
            {
                alunni = alunni.Where(a => a.Cognome.Contains(query)
                                        || a.Nome.Contains(query)
                                        || a.CodiceFiscale.Contains(query)
                                        || a.Comune.Contains(query));
            }

            // Ordinamento Elenco
            if (!String.IsNullOrEmpty(order))
            {
                if (order == "Cognome")
                    alunni = alunni.OrderBy(a => a.Cognome);
                else if (order == "CodiceFiscale")
                    alunni = alunni.OrderBy(a => a.CodiceFiscale);
                else if (order == "Comune")
                    alunni = alunni.OrderBy(a => a.Comune);
                else if (order == "Nome")
                    alunni = alunni.OrderBy(a => a.Nome);
            }

            ViewBag.query = query;
            ViewBag.order = order;

            return View(alunni.ToList());
        }

        // GET: Search
        public ActionResult Search(string cognome, string nome,
                                   string codiceFiscale, string comune)
        {
            IQueryable<Alunno> alunni = db.Alunnoes;

            /*
            alunni = alunni.Where(a => a.Cognome.Contains(cognome)
                                    && a.Nome.Contains(nome)
                                    && a.CodiceFiscale.Contains(codiceFiscale)
                                    && a.Comune.Contains(comune));
                                    */
            if(!String.IsNullOrEmpty(cognome))
                alunni = alunni.Where(a => a.Cognome.Contains(cognome));

            if (!String.IsNullOrEmpty(nome))
                alunni = alunni.Where(a => a.Nome.Contains(nome));

            if (!String.IsNullOrEmpty(codiceFiscale))
                alunni = alunni.Where(a => a.CodiceFiscale.Contains(codiceFiscale));

            if (!String.IsNullOrEmpty(comune))
                alunni = alunni.Where(a => a.Comune.Contains(comune));

            return View(alunni.ToList());
        }

        // GET: Alunni/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alunno alunno = db.Alunnoes.Find(id);
            if (alunno == null)
            {
                return HttpNotFound();
            }
            return View(alunno);
        }

        // GET: Alunni/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alunni/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Cognome,CodiceFiscale,Indirizzo,Comune,Provincia,Cap,Telefono,Cellulare,Email")] Alunno alunno)
        {
            alunno.DataInserimento = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Alunnoes.Add(alunno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alunno);
        }

        // GET: Alunni/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alunno alunno = db.Alunnoes.Find(id);
            if (alunno == null)
            {
                return HttpNotFound();
            }
            return View(alunno);
        }

        // POST: Alunni/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAlunno,Nome,Cognome,CodiceFiscale,Indirizzo,Comune,Provincia,Cap,Telefono,Cellulare,Email,DataInserimento")] Alunno alunno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alunno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alunno);
        }

        // GET: Alunni/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alunno alunno = db.Alunnoes.Find(id);
            if (alunno == null)
            {
                return HttpNotFound();
            }
            return View(alunno);
        }

        // POST: Alunni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alunno alunno = db.Alunnoes.Find(id);
            db.Alunnoes.Remove(alunno);
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
