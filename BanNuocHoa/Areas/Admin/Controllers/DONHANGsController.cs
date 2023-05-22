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
    public class DONHANGsController : Controller
    {
        private connect db = new connect();

        // GET: Admin/DONHANGs
        public ActionResult Index()
        {
            if (Session["user_id"] != null)
            {
                var dONHANGs = db.DONHANGs.Include(d => d.NGUOIDUNG).Include(d => d.SANPHAM);
                return View(dONHANGs.ToList());
            }
            else
            {
                return RedirectToAction("Login", "LOGINs", new { area = "" });
            }

          
        }

        // GET: Admin/DONHANGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANG dONHANG = db.DONHANGs.Find(id);
            if (dONHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONHANG);
        }

        // GET: Admin/DONHANGs/Create
        public ActionResult Create()
        {
            ViewBag.Nguoidung_ID = new SelectList(db.NGUOIDUNGs, "Nguoidung_ID", "Nguoidung_user");
            ViewBag.Sanpham_ID = new SelectList(db.SANPHAMs, "Sanpham_ID", "Sanpham_ten");
            return View();
        }

        // POST: Admin/DONHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Donhang_ID,Nguoidung_ID,Donhang_ngaydat,Donhang_ten,Donhang_diachi,Donhang_sdt,Donhang_ghichu,Donhang_giatien,Sanpham_ID")] DONHANG dONHANG)
        {
            if (ModelState.IsValid)
            {
                db.DONHANGs.Add(dONHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Nguoidung_ID = new SelectList(db.NGUOIDUNGs, "Nguoidung_ID", "Nguoidung_user", dONHANG.Nguoidung_ID);
            ViewBag.Sanpham_ID = new SelectList(db.SANPHAMs, "Sanpham_ID", "Sanpham_ten", dONHANG.Sanpham_ID);
            return View(dONHANG);
        }

        // GET: Admin/DONHANGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANG dONHANG = db.DONHANGs.Find(id);
            if (dONHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.Nguoidung_ID = new SelectList(db.NGUOIDUNGs, "Nguoidung_ID", "Nguoidung_user", dONHANG.Nguoidung_ID);
            ViewBag.Sanpham_ID = new SelectList(db.SANPHAMs, "Sanpham_ID", "Sanpham_ten", dONHANG.Sanpham_ID);
            return View(dONHANG);
        }

        // POST: Admin/DONHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Donhang_ID,Nguoidung_ID,Donhang_ngaydat,Donhang_ten,Donhang_diachi,Donhang_sdt,Donhang_ghichu,Donhang_giatien,Sanpham_ID")] DONHANG dONHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dONHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Nguoidung_ID = new SelectList(db.NGUOIDUNGs, "Nguoidung_ID", "Nguoidung_user", dONHANG.Nguoidung_ID);
            ViewBag.Sanpham_ID = new SelectList(db.SANPHAMs, "Sanpham_ID", "Sanpham_ten", dONHANG.Sanpham_ID);
            return View(dONHANG);
        }

        // GET: Admin/DONHANGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANG dONHANG = db.DONHANGs.Find(id);
            if (dONHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONHANG);
        }

        // POST: Admin/DONHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DONHANG dONHANG = db.DONHANGs.Find(id);
            db.DONHANGs.Remove(dONHANG);
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
