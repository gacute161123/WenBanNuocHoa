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
    public class CHITIETDONHANGsController : Controller
    {
        private connect db = new connect();

        // GET: Admin/CHITIETDONHANGs
        public ActionResult Index()
        {
            if (Session["user_id"] != null)
            {
                var cHITIETDONHANGs = db.CHITIETDONHANGs.Include(c => c.DONHANG).Include(c => c.SANPHAM);
                return View(cHITIETDONHANGs.ToList());
            }
            else
            {
                return RedirectToAction("Login", "LOGINs", new { area = "" });
            }

            
        }

        // GET: Admin/CHITIETDONHANGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDONHANG cHITIETDONHANG = db.CHITIETDONHANGs.Find(id);
            if (cHITIETDONHANG == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETDONHANG);
        }

        // GET: Admin/CHITIETDONHANGs/Create
        public ActionResult Create()
        {
            ViewBag.Donhang_ID = new SelectList(db.DONHANGs, "Donhang_ID", "Donhang_ten");
            ViewBag.Sanpham_ID = new SelectList(db.SANPHAMs, "Sanpham_ID", "Sanpham_ten");
            return View();
        }

        // POST: Admin/CHITIETDONHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CT_ID,Donhang_ID,Sanpham_ID,CT_soluong,CT_giaban,CT_giamgia,CT_thanhtien")] CHITIETDONHANG cHITIETDONHANG)
        {
            if (ModelState.IsValid)
            {
                db.CHITIETDONHANGs.Add(cHITIETDONHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Donhang_ID = new SelectList(db.DONHANGs, "Donhang_ID", "Donhang_ten", cHITIETDONHANG.Donhang_ID);
            ViewBag.Sanpham_ID = new SelectList(db.SANPHAMs, "Sanpham_ID", "Sanpham_ten", cHITIETDONHANG.Sanpham_ID);
            return View(cHITIETDONHANG);
        }

        // GET: Admin/CHITIETDONHANGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDONHANG cHITIETDONHANG = db.CHITIETDONHANGs.Find(id);
            if (cHITIETDONHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.Donhang_ID = new SelectList(db.DONHANGs, "Donhang_ID", "Donhang_ten", cHITIETDONHANG.Donhang_ID);
            ViewBag.Sanpham_ID = new SelectList(db.SANPHAMs, "Sanpham_ID", "Sanpham_ten", cHITIETDONHANG.Sanpham_ID);
            return View(cHITIETDONHANG);
        }

        // POST: Admin/CHITIETDONHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CT_ID,Donhang_ID,Sanpham_ID,CT_soluong,CT_giaban,CT_giamgia,CT_thanhtien")] CHITIETDONHANG cHITIETDONHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHITIETDONHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Donhang_ID = new SelectList(db.DONHANGs, "Donhang_ID", "Donhang_ten", cHITIETDONHANG.Donhang_ID);
            ViewBag.Sanpham_ID = new SelectList(db.SANPHAMs, "Sanpham_ID", "Sanpham_ten", cHITIETDONHANG.Sanpham_ID);
            return View(cHITIETDONHANG);
        }

        // GET: Admin/CHITIETDONHANGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDONHANG cHITIETDONHANG = db.CHITIETDONHANGs.Find(id);
            if (cHITIETDONHANG == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETDONHANG);
        }

        // POST: Admin/CHITIETDONHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHITIETDONHANG cHITIETDONHANG = db.CHITIETDONHANGs.Find(id);
            db.CHITIETDONHANGs.Remove(cHITIETDONHANG);
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
