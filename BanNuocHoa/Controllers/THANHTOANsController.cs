using BanNuocHoa.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanNuocHoa.Controllers
{
    public class THANHTOANsController : Controller
    {
        // GET: THANHTOANs
        protected connect db= new connect();
        public ActionResult Index()
        {
            if (Session["user_id"] == null)
            {

                return RedirectToAction("Login", "LOGINs");
            }
            else
            {
                var lstcart = (List<GIOHANG>)Session["cart"];
               
                DONHANG dONHANG = new DONHANG();
                dONHANG.Donhang_ten = "DonHang-" + DateTime.Now.ToString("yyyyMMddHmmss");
                dONHANG.Nguoidung_ID = int.Parse(Session["user_id"].ToString());
                dONHANG.Donhang_ngaydat = DateTime.Now;
                
                db.DONHANGs.Add(dONHANG);
                db.SaveChanges();
                int intdonhangid = dONHANG.Donhang_ID;
                List<CHITIETDONHANG> lstchitietdonhang= new List<CHITIETDONHANG>();
                foreach (var item in lstcart) {
                    CHITIETDONHANG obj = new CHITIETDONHANG();
                    obj.CT_soluong = item.soluong;
                    obj.Donhang_ID = intdonhangid;
                    obj.Sanpham_ID = item.SANPHAM.Sanpham_ID;
                    
                    lstchitietdonhang.Add(obj);
                }
                db.CHITIETDONHANGs.AddRange(lstchitietdonhang);
                db.SaveChanges();
            }
            return View();
        }
    }
}