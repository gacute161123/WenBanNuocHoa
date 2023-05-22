using BanNuocHoa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using PagedList;
using System.Data.SqlClient;
using System.Web.UI;
using PagedList.Mvc;
namespace BanNuocHoa.Controllers
{
    public class HomeController : Controller
    {
        protected connect db = new connect();
        [ChildActionOnly]
        public ActionResult RenderMenu() {
            return PartialView("_NavMenu", db.THELOAIs.ToList());
        }
        public ActionResult Index(int? page)
        {
            var sANPHAMs = db.SANPHAMs.OrderByDescending(p => p.Sanpham_ID).Take(15).ToList();
            ViewBag.Page = page;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(sANPHAMs.ToPagedList(pageNumber, pageSize));
            /*      var sANPHAMs = db.SANPHAMs.Include(s => s.THELOAI);
          return View(sANPHAMs.ToList());*/
        }
        public ActionResult Allsanpham(int?page)
        {
            var sANPHAMs = db.SANPHAMs.ToList();
            ViewBag.Page = page;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return View(sANPHAMs.ToPagedList(pageNumber, pageSize));

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}