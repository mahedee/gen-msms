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
    public class LookupController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lookup
        public ActionResult Index()
        {
            return View(db.Lookup.ToList());
        }

        // GET: Lookup/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    LookupVM lookupVM = db.Lookup.Find(id);
        //    if (lookupVM == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(lookupVM);
        //}

        // GET: Lookup/Create
        public ActionResult Create()
        {
            //ViewBag.ParentId = new SelectList(db.Lookup, "Id", "Name");

            List<Lookup> lstLookup = new List<Lookup>();
            lstLookup = db.Lookup.ToList();

            List<LookupVM> lstLookupVM = new List<LookupVM>();
            foreach (Lookup objLookup in lstLookup)
            {
                LookupVM objLookupVM = new LookupVM();
                objLookupVM.Id = objLookup.Id;
                objLookupVM.Name = objLookup.Name;
                objLookupVM.Description = objLookup.Description;
                lstLookupVM.Add(objLookupVM);
            }

            ViewBag.ParentId = new SelectList(lstLookupVM, "Id", "Name");

            return View();
        }

        // POST: Lookup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,IsParent,Description,ParentId")] LookupVM lookupVM)
        {
            if (ModelState.IsValid)
            {
                Lookup objLookup = new Lookup();
                objLookup.Id = lookupVM.Id;
                objLookup.Name = lookupVM.Name;
                objLookup.Description = lookupVM.Description;

                if (lookupVM.IsParent == true)
                {
                    objLookup.ParentId = lookupVM.ParentId;
                }


                db.Lookup.Add(objLookup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lookupVM);
        }



        // GET: Lookup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Lookup lookup = db.Lookup.Find(id);
            

            LookupVM objLookupVm = new LookupVM();

            //LookupVM lookupVM = db.LookupVMs.Find(id);
            if (lookup == null)
            {
                return HttpNotFound();
            }
            else
            {
                objLookupVm.Id = lookup.Id;
                objLookupVm.Name = lookup.Name;
                objLookupVm.Description = lookup.Description;
                objLookupVm.ParentId = lookup.ParentId;
            }

            ViewBag.ParentId = new SelectList(db.Lookup, "Id", "Name");

            return View(objLookupVm);
        }

        /*

// POST: Lookup/Edit/5
// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Edit([Bind(Include = "Id,Name,IsParent,Description,ParentId")] LookupVM lookupVM)
{
    if (ModelState.IsValid)
    {
        db.Entry(lookupVM).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    return View(lookupVM);
}

// GET: Lookup/Delete/5
public ActionResult Delete(int? id)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    LookupVM lookupVM = db.LookupVMs.Find(id);
    if (lookupVM == null)
    {
        return HttpNotFound();
    }
    return View(lookupVM);
}

// POST: Lookup/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public ActionResult DeleteConfirmed(int id)
{
    LookupVM lookupVM = db.LookupVMs.Find(id);
    db.LookupVMs.Remove(lookupVM);
    db.SaveChanges();
    return RedirectToAction("Index");
}


*/
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
