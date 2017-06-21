using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MSMS.Web.Models;

namespace MSMS.Web.Controllers
{
    public class FeeSettingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FeeSettings
        public ActionResult Index()
        {
            var feesettings = db.Feesettings.Include(f => f.ClassInfo);
            return View(feesettings.ToList());
        }

        // GET: FeeSettings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeeSettings feeSettings = db.Feesettings.Find(id);
            if (feeSettings == null)
            {
                return HttpNotFound();
            }
            return View(feeSettings);
        }

        // GET: FeeSettings/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.ClassInfo, "Id", "ClassName");
            return View();
        }

        // POST: FeeSettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClassId,MonthlyFee,EffectiveDate")] FeeSettings feeSettings)
        {
            if (ModelState.IsValid)
            {
                db.Feesettings.Add(feeSettings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.ClassInfo, "Id", "ClassName", feeSettings.ClassId);
            return View(feeSettings);
        }

        // GET: FeeSettings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeeSettings feeSettings = db.Feesettings.Find(id);
            if (feeSettings == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.ClassInfo, "Id", "ClassName", feeSettings.ClassId);
            return View(feeSettings);
        }

        // POST: FeeSettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClassId,MonthlyFee,EffectiveDate")] FeeSettings feeSettings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feeSettings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.ClassInfo, "Id", "ClassName", feeSettings.ClassId);
            return View(feeSettings);
        }

        // GET: FeeSettings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeeSettings feeSettings = db.Feesettings.Find(id);
            if (feeSettings == null)
            {
                return HttpNotFound();
            }
            return View(feeSettings);
        }

        // POST: FeeSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeeSettings feeSettings = db.Feesettings.Find(id);
            db.Feesettings.Remove(feeSettings);
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
