using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BanNuocHoa.Models;

namespace BanNuocHoa.Areas.Admin.Controllers
{
    public class PHANQUYENsController : Controller
    {
        private connect db = new connect();

        // GET: Admin/PHANQUYENs
        public ActionResult Index()
        {
            var pHANQUYENs = db.PHANQUYENs.Include(p => p.NGUOIDUNG);
            return View(pHANQUYENs.ToList());
        }

        // GET: Admin/PHANQUYENs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHANQUYEN pHANQUYEN = db.PHANQUYENs.Find(id);
            if (pHANQUYEN == null)
            {
                return HttpNotFound();
            }
            return View(pHANQUYEN);
        }

        // GET: Admin/PHANQUYENs/Create
        public ActionResult Create()
        {
            ViewBag.Nguoidung_ID = new SelectList(db.NGUOIDUNGs, "Nguoidung_ID", "Nguoidung_user");
            return View();
        }

        // POST: Admin/PHANQUYENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Phanquyen_ID,Nguoidung_ID,Phanquyen_quyensudung")] PHANQUYEN pHANQUYEN)
        {
            if (ModelState.IsValid)
            {
                db.PHANQUYENs.Add(pHANQUYEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Nguoidung_ID = new SelectList(db.NGUOIDUNGs, "Nguoidung_ID", "Nguoidung_user", pHANQUYEN.Nguoidung_ID);
            return View(pHANQUYEN);
        }

        // GET: Admin/PHANQUYENs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHANQUYEN pHANQUYEN = db.PHANQUYENs.Find(id);
            if (pHANQUYEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.Nguoidung_ID = new SelectList(db.NGUOIDUNGs, "Nguoidung_ID", "Nguoidung_user", pHANQUYEN.Nguoidung_ID);
            return View(pHANQUYEN);
        }

        // POST: Admin/PHANQUYENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Phanquyen_ID,Nguoidung_ID,Phanquyen_quyensudung")] PHANQUYEN pHANQUYEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHANQUYEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Nguoidung_ID = new SelectList(db.NGUOIDUNGs, "Nguoidung_ID", "Nguoidung_user", pHANQUYEN.Nguoidung_ID);
            return View(pHANQUYEN);
        }

        // GET: Admin/PHANQUYENs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHANQUYEN pHANQUYEN = db.PHANQUYENs.Find(id);
            if (pHANQUYEN == null)
            {
                return HttpNotFound();
            }
            return View(pHANQUYEN);
        }

        // POST: Admin/PHANQUYENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PHANQUYEN pHANQUYEN = db.PHANQUYENs.Find(id);
            db.PHANQUYENs.Remove(pHANQUYEN);
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
