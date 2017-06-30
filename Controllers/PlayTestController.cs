using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using frameQuest.Models;
using frameQuest.ViewModels;
using System.Net;

namespace frameQuest.Controllers
{
    public class PlayTestController : Controller
    {
        private frameQuestContext db = new frameQuestContext();

        // GET: PlayTest
        public ActionResult Index()
        {
            return View(db.Tests.ToList());
        }

        public ActionResult Play(int? id)
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

        public ActionResult Elabora()
        {
            ViewBag.elabora = Request.QueryString;

            string chiave, valore;

            ICollection<ElaboraViewModel> elaboraVM = new List<ElaboraViewModel>();
            foreach(var key in Request.QueryString)
            {
                chiave = key.ToString();
                valore = Request.QueryString[key.ToString()];

                elaboraVM.Add(
                    new ElaboraViewModel
                    {
                        chiave = chiave,
                        valore = valore,
                        IdRisposta = int.Parse(valore),
                        IdDomanda = int.Parse(chiave.Substring(7))
                    }
                    );
            }


            return View(elaboraVM);
        }
    }
}