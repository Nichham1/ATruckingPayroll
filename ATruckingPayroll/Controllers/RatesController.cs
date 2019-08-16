using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ATruckingPayroll.Models;

namespace ATruckingPayroll.Controllers
{
    public class RatesController : Controller
    {
        private AdersonDBEntities db = new AdersonDBEntities();

        // GET: Rates
        public ActionResult Index()
        {
            var rates = db.Rates.Include(r => r.Driver).Include(r => r.Driver1).Include(r => r.StageDesc);
            return View(rates.ToList());
        }

        // GET: Rates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rate rate = db.Rates.Find(id);
            if (rate == null)
            {
                return HttpNotFound();
            }
            return View(rate);
        }

        // GET: Rates/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Drivers, "Id", "Name");
            ViewBag.Id = new SelectList(db.Drivers, "Id", "Name");
            ViewBag.Id = new SelectList(db.StageDescs, "Id", "Name");
            return View();
        }

        // POST: Rates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,StageDesID")] Rate rate)
        {
            if (ModelState.IsValid)
            {
                db.Rates.Add(rate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Drivers, "Id", "Name", rate.Id);
            ViewBag.Id = new SelectList(db.Drivers, "Id", "Name", rate.Id);
            ViewBag.Id = new SelectList(db.StageDescs, "Id", "Name", rate.Id);
            return View(rate);
        }

        // GET: Rates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rate rate = db.Rates.Find(id);
            if (rate == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Drivers, "Id", "Name", rate.Id);
            ViewBag.Id = new SelectList(db.Drivers, "Id", "Name", rate.Id);
            ViewBag.Id = new SelectList(db.StageDescs, "Id", "Name", rate.Id);
            return View(rate);
        }

        // POST: Rates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,StageDesID")] Rate rate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Drivers, "Id", "Name", rate.Id);
            ViewBag.Id = new SelectList(db.Drivers, "Id", "Name", rate.Id);
            ViewBag.Id = new SelectList(db.StageDescs, "Id", "Name", rate.Id);
            return View(rate);
        }

        // GET: Rates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rate rate = db.Rates.Find(id);
            if (rate == null)
            {
                return HttpNotFound();
            }
            return View(rate);
        }

        // POST: Rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rate rate = db.Rates.Find(id);
            db.Rates.Remove(rate);
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
