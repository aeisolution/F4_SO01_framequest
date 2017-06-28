﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using frameQuest.Models;
using frameQuest.ViewModels;

namespace frameQuest.Controllers
{
    public class DomandeController : Controller
    {
        private frameQuestContext db = new frameQuestContext();

        // ---------------------------------
        // Gestione Domande
        public ActionResult Create(DomandaDto domanda)
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
                dom.Risposte.Add(new Risposta
                {
                    Testo = domanda.Ris1_Testo,
                    Esatta = domanda.Ris1_Esatta == "on" ? true : false
                });
            }

            if (!String.IsNullOrEmpty(domanda.Ris2_Testo))
            {
                dom.Risposte.Add(new Risposta
                {
                    Testo = domanda.Ris2_Testo,
                    Esatta = domanda.Ris2_Esatta == "on" ? true : false
                });
            }

            if (!String.IsNullOrEmpty(domanda.Ris3_Testo))
            {
                dom.Risposte.Add(new Risposta
                {
                    Testo = domanda.Ris3_Testo,
                    Esatta = domanda.Ris3_Esatta == "on" ? true : false
                });
            }

            if (!String.IsNullOrEmpty(domanda.Ris4_Testo))
            {
                dom.Risposte.Add(new Risposta
                {
                    Testo = domanda.Ris4_Testo,
                    Esatta = domanda.Ris4_Esatta == "on" ? true : false
                });
            }

            db.Domande.Add(dom);
            db.SaveChanges();
            return RedirectToAction("Details", "Tests", new { id = domanda.IdTest });
        }

        public ActionResult Details(int? id)
        {
            var domanda = db.Domande.Find(id);

            if(domanda == null)
            {
                return HttpNotFound();
            }

            return View(domanda);
        }

        public ActionResult Delete(int id)
        {
            Domanda domanda = db.Domande.Find(id);

            ICollection<Risposta> Risps = new List<Risposta>();
            foreach (var risp in domanda.Risposte)
            {
                Risps.Add(risp);
            }

            //Cancellazione Risposte
            foreach (var risp in Risps)
            {
                db.Risposte.Remove(risp);
            }
            db.Domande.Remove(domanda);

            db.SaveChanges();
            return RedirectToAction("Details","Tests",new { id = domanda.IdTest });
        }
    }
}