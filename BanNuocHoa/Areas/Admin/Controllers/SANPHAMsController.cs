using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using BanNuocHoa.Models;
using PagedList;

namespace BanNuocHoa.Areas.Admin.Controllers
{
    public class SANPHAMsController : Controller
    {
        private connect db = new connect();

        // GET: Admin/SANPHAMs
        public ActionResult Index(string SearchStr, string CurentStr, string SortOrder, int? page)
        {
            if (Session["user_id"] != null)
            {
                ViewBag.CurrentSort = SortOrder;
                ViewBag.Sanpham_ten = String.IsNullOrEmpty(SortOrder) ? "ten_desc" : "";
                ViewBag.Sanpham_gia = SortOrder == "gia" ? "gia_desc" : "gia";
                ViewBag.Sanpham_soluong = SortOrder == "soluong" ? "soluong_desc" : "soluong";

                if (SearchStr != null)
                {
                    page = 1;
                }
                else
                {
                    SearchStr = CurentStr;
                }
                var model = from c in db.SANPHAMs.ToList() select c;
                // tim kiem
                if (!String.IsNullOrEmpty(SearchStr))
                {
                    model = model.Where(c => c.Sanpham_ten.Contains(SearchStr));
                }
                // sapxep
                switch (SortOrder)
                {
                    case "ten_desc":
                        model = model.OrderByDescending(s => s.Sanpham_ten);
                        break;
                    case "gia":
                        model = model.OrderBy(s => s.Sanpham_gia);
                        break;
                    case "gia_desc":
                        model = model.OrderByDescending(s => s.Sanpham_gia);
                        break;
                    case "soluong":
                        model = model.OrderBy(s => s.Sanpham_soluong);
                        break;
                    case "soluong_desc":
                        model = model.OrderByDescending(s => s.Sanpham_soluong);
                        break;
                    default:
                        model = model.OrderBy(s => s.Sanpham_ID);
                        break;
                }
                ViewBag.Page = page;
                int pageSize = 8;
                int pageNumber = (page ?? 1);
                return View(model.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return RedirectToAction("Login", "LOGINs", new { area = "" });
            }
           
           
            /*var sANPHAMs = db.SANPHAMs.Include(s => s.THELOAI);
            return View(sANPHAMs.ToList());*/
        }

        // GET: Admin/SANPHAMs/Details/5
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

        // GET: Admin/SANPHAMs/Create
        public ActionResult Create()
        {
            ViewBag.Theloai_ID = new SelectList(db.THELOAIs, "Theloai_ID", "Theloai_ten");
            return View();
        }

        // POST: Admin/SANPHAMs/Create
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

        // GET: Admin/SANPHAMs/Edit/5
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

        // POST: Admin/SANPHAMs/Edit/5
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

        // GET: Admin/SANPHAMs/Delete/5
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

        // POST: Admin/SANPHAMs/Delete/5
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
