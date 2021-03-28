using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TendersTestCase.Models;
using TendersTestCase.Models.Context;

namespace TendersTestCase.Controllers
{
    public class BookletsController : Controller
    {
        private BookletContext db = new BookletContext();

        // GET: Booklets
        public ActionResult Index()
        {
            return View(db.Booklets.ToList());
        }

        // GET: Booklets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booklets booklets = db.Booklets.Find(id);
            if (booklets == null)
            {
                return HttpNotFound();
            }
            return View(booklets);
        }

        // GET: Booklets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Booklets/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Booklets booklets)
        {
            if (ModelState.IsValid)
            {
                db.Booklets.Add(booklets);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(booklets);
        }

        // GET: Booklets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booklets booklets = db.Booklets.Find(id);
            if (booklets == null)
            {
                return HttpNotFound();
            }
            return View(booklets);
        }

        // POST: Booklets/Edit/5
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Booklets booklets)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booklets).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booklets);
        }

        // GET: Booklets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booklets booklets = db.Booklets.Find(id);
            if (booklets == null)
            {
                return HttpNotFound();
            }
            return View(booklets);
        }

        // POST: Booklets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booklets booklets = db.Booklets.Find(id);
            db.Booklets.Remove(booklets);
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
