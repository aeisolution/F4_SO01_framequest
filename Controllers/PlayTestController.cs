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
    }
}