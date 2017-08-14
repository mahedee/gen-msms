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
    public class ClassSchedulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClassSchedules
        public ActionResult Index()
        {
            return View(db.ClassSchedules.ToList());
        }

        // GET: ClassSchedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSchedule classSchedule = db.ClassSchedules.Find(id);
            if (classSchedule == null)
            {
                return HttpNotFound();
            }
            return View(classSchedule);
        }

        // GET: ClassSchedules/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.ClassInfo, "Id", "ClassName");            

            List<Lookup> ShiftLookup = new List<Lookup>();
            ShiftLookup = db.Lookup.Where(p => p.ParentId == 3).ToList();
            ViewBag.ShiftId = new SelectList(ShiftLookup, "Id", "Name");

            List<Lookup> SecLookup = new List<Lookup>();
            SecLookup = db.Lookup.Where(p => p.ParentId == 7).ToList();
            ViewBag.SectionId = new SelectList(SecLookup, "Id", "Name");
            
            ViewBag.SubjectId = new SelectList(db.Subject, "Id", "SubjectName");

            List<Lookup> RoomLookup = new List<Lookup>();
            RoomLookup = db.Lookup.Where(p => p.ParentId == 29).ToList();
            ViewBag.RoomLookup = new SelectList(RoomLookup, "Id", "Name");

            List<Lookup> DayLookup = new List<Lookup>();
            DayLookup = db.Lookup.Where(p => p.ParentId == 32).ToList();
            ViewBag.DayLookup = new SelectList(DayLookup, "Id", "Name");

            return View();
        }

        // POST: ClassSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClassId,ShiftId,SectionId,SubjectId,TeacherId,RoomId,DayId,StartTime,EndTime")] ClassSchedule classSchedule)
        {
            if (ModelState.IsValid)
            {
                db.ClassSchedules.Add(classSchedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classSchedule);
        }

        // GET: ClassSchedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSchedule classSchedule = db.ClassSchedules.Find(id);
            if (classSchedule == null)
            {
                return HttpNotFound();
            }
            return View(classSchedule);
        }

        // POST: ClassSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClassId,ShiftId,SectionId,SubjectId,TeacherId,RoomId,DayId,StartTime,EndTime")] ClassSchedule classSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classSchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classSchedule);
        }

        // GET: ClassSchedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSchedule classSchedule = db.ClassSchedules.Find(id);
            if (classSchedule == null)
            {
                return HttpNotFound();
            }
            return View(classSchedule);
        }

        // POST: ClassSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassSchedule classSchedule = db.ClassSchedules.Find(id);
            db.ClassSchedules.Remove(classSchedule);
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
