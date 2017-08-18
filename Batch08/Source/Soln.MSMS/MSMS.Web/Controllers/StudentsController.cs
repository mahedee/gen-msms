using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using MSMS.Web.Models;

namespace MSMS.Web.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();        

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Student.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.ClassInfo, "Id", "ClassName");

            List<Lookup> GrpLookup = new List<Lookup>();
            GrpLookup = db.Lookup.Where(p => p.ParentId == 1).ToList();
            ViewBag.GroupId = new SelectList(GrpLookup, "Id", "Name");

            List<Lookup> SecLookup = new List<Lookup>();
            SecLookup = db.Lookup.Where(p => p.ParentId == 7).ToList();
            ViewBag.SectionId = new SelectList(SecLookup, "Id", "Name");

            List<Lookup> ShiftLookup = new List<Lookup>();
            ShiftLookup = db.Lookup.Where(p => p.ParentId == 3).ToList();
            ViewBag.ShiftId = new SelectList(ShiftLookup, "Id", "Name");

            List<Lookup> GenderLookup = new List<Lookup>();
            GenderLookup = db.Lookup.Where(p => p.ParentId == 4).ToList();
            ViewBag.GenderLookup = new SelectList(GenderLookup, "Id", "Name");

            List<Lookup> AdmRefLookup = new List<Lookup>();
            AdmRefLookup = db.Lookup.Where(p => p.ParentId == 13).ToList();
            ViewBag.AdmissionReferanceId = new SelectList(AdmRefLookup, "Id", "Name");

            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClassId,Batch,StudentId,StudentName,ClassRoll,GroupId,SectionId,ShiftId,CellNumber,Email,PEC,JSC,SSC,GenderId,AdmissionReferanceId,ReferanceName,Discount")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Student.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.ClassInfo, "Id", "ClassName",student.ClassId);

            List<Lookup> GrpLookup = new List<Lookup>();
            GrpLookup = db.Lookup.Where(p => p.ParentId == 1).ToList();
            ViewBag.GroupId = new SelectList(GrpLookup, "Id", "Name");

            List<Lookup> SecLookup = new List<Lookup>();
            SecLookup = db.Lookup.Where(p => p.ParentId == 7).ToList();
            ViewBag.SectionId = new SelectList(SecLookup, "Id", "Name");

            List<Lookup> ShiftLookup = new List<Lookup>();
            ShiftLookup = db.Lookup.Where(p => p.ParentId == 3).ToList();
            ViewBag.ShiftId = new SelectList(ShiftLookup, "Id", "Name");

            List<Lookup> AdmRefLookup = new List<Lookup>();
            AdmRefLookup = db.Lookup.Where(p => p.ParentId == 13).ToList();
            ViewBag.AdmissionReferanceId = new SelectList(AdmRefLookup, "Id", "Name");

            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClassId,Batch,StudentId,StudentName,ClassRoll,GroupId,SectionId,ShiftId,CellNumber,Email,PEC,JSC,SSC,GenderId,AdmissionReferanceId,ReferanceName,Discount")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Student.Find(id);
            db.Student.Remove(student);
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
