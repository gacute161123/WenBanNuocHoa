using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BanNuocHoa.Models;

namespace BanNuocHoa.Controllers
{
    public class SANPHAMsController : Controller
    {
        private connect db = new connect();

        // GET: SANPHAMs
        public ActionResult Index(int? catid)
        {
            if (catid == null)
            {
                var sANPHAMs = db.SANPHAMs.Include(s => s.THELOAI);
                return View(sANPHAMs.ToList());
            }
            else {
                var sANPHAMs = db.SANPHAMs.Where(s => s.Theloai_ID== catid);
                return View(sANPHAMs.ToList());
            }

        }
        public ActionResult IndexSearch(string searchString)
        {
            var model = from c in db.SANPHAMs.ToList() select c;
            ViewBag.searchString= searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(c => c.Sanpham_ten.Contains(searchString));
            }
            return View(model);
        }

        // GET: SANPHAMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // GET: SANPHAMs/Create
        public ActionResult Create()
        {
            ViewBag.Theloai_ID = new SelectList(db.THELOAIs, "Theloai_ID", "Theloai_ten");
            return View();
        }

        // POST: SANPHAMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sanpham_ID,Sanpham_ten,Sanpham_mota,Sanpham_gia,Sanpham_soluong,Sanpham_anh,Sanpham_giohang,Theloai_ID")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.SANPHAMs.Add(sANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Theloai_ID = new SelectList(db.THELOAIs, "Theloai_ID", "Theloai_ten", sANPHAM.Theloai_ID);
            return View(sANPHAM);
        }

        // GET: SANPHAMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.Theloai_ID = new SelectList(db.THELOAIs, "Theloai_ID", "Theloai_ten", sANPHAM.Theloai_ID);
            return View(sANPHAM);
        }

        // POST: SANPHAMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sanpham_ID,Sanpham_ten,Sanpham_mota,Sanpham_gia,Sanpham_soluong,Sanpham_anh,Sanpham_giohang,Theloai_ID")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Theloai_ID = new SelectList(db.THELOAIs, "Theloai_ID", "Theloai_ten", sANPHAM.Theloai_ID);
            return View(sANPHAM);
        }

        // GET: SANPHAMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // POST: SANPHAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            db.SANPHAMs.Remove(sANPHAM);
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
