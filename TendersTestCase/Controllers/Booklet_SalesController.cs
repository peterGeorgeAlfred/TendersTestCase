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
    public class Booklet_SalesController : Controller
    {
        private BookletContext db = new BookletContext();

        // GET: Booklet_Sales
        public ActionResult Index()
        {
            var booklet_Sales = db.Booklet_Sales.Include(b => b.Booklets);
            return View(booklet_Sales.ToList());
        }

        // GET: Booklet_Sales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booklet_Sales booklet_Sales = db.Booklet_Sales.Find(id);
            if (booklet_Sales == null)
            {
                return HttpNotFound();
            }
            return View(booklet_Sales);
        }

        // GET: Booklet_Sales/Create
        public ActionResult Create()
        {
            ViewBag.BookletID = new SelectList(db.Booklets.Where(i=>i.Status == Status.Available), "BookletID", "BookletID");
            return View();
        }

        // POST: Booklet_Sales/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Booklet_Sales booklet_Sales)
        {
            if (ModelState.IsValid && booklet_Sales.Date > DateTime.Now)
            {
                db.Booklet_Sales.Add(booklet_Sales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookletID = new SelectList(db.Booklets, "BookletID", "BookletID", booklet_Sales.BookletID);
            return View(booklet_Sales);
        }

        // GET: Booklet_Sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booklet_Sales booklet_Sales = db.Booklet_Sales.Find(id);
            if (booklet_Sales == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookletID = new SelectList(db.Booklets, "BookletID", "BookletID", booklet_Sales.BookletID);
            return View(booklet_Sales);
        }

        // POST: Booklet_Sales/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Serial,Date,BookletID,CustomerID,CustomerName")] Booklet_Sales booklet_Sales)
        {
            if (ModelState.IsValid && booklet_Sales.Date > DateTime.Now)
            {
                db.Entry(booklet_Sales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookletID = new SelectList(db.Booklets, "BookletID", "BookletID", booklet_Sales.BookletID);
            return View(booklet_Sales);
        }

        // GET: Booklet_Sales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booklet_Sales booklet_Sales = db.Booklet_Sales.Find(id);
            if (booklet_Sales == null)
            {
                return HttpNotFound();
            }
            return View(booklet_Sales);
        }

        // POST: Booklet_Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booklet_Sales booklet_Sales = db.Booklet_Sales.Find(id);
            db.Booklet_Sales.Remove(booklet_Sales);
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
