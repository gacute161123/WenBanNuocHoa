using BanNuocHoa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BanNuocHoa.Controllers
{
    public class GIOHANGsController : Controller
    {
        // GET: GIOHANGs
        protected connect db= new connect();
        public ActionResult Index()
        {
            
            return View((List<GIOHANG>)Session["cart"]);
        }
        public ActionResult AddToCart(int id, int soluong) {
            if (Session["cart"] == null)
            {
                List<GIOHANG> cart = new List<GIOHANG>();
                cart.Add(new GIOHANG { SANPHAM = db.SANPHAMs.Find(id), soluong = soluong });
                Session["cart"] = cart;
                Session["count"] = 1;
            }
            else
            {
                List<GIOHANG> cart = (List<GIOHANG>)Session["cart"];
                //kiểm tra sản phẩm có tồn tại trong giỏ hàng chưa???
                int index = isExist(id);
                if (index != -1)
                {
                    //nếu sp tồn tại trong giỏ hàng thì cộng thêm số lượng
                    cart[index].soluong += soluong;
                }
                else
                {
                    //nếu không tồn tại thì thêm sản phẩm vào giỏ hàng
                    cart.Add(new GIOHANG { SANPHAM = db.SANPHAMs.Find(id), soluong = soluong });
                    //Tính lại số sản phẩm trong giỏ hàng
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                }
                Session["cart"] = cart;
            }
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }

        private int isExist(int id)
        {
            List<GIOHANG> cart = (List<GIOHANG>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].SANPHAM.Sanpham_ID.Equals(id))
                    return i;
            return -1;
        }
        public ActionResult Remove(int Id)
        {
            List<GIOHANG> li = (List<GIOHANG>)Session["cart"];
            li.RemoveAll(x => x.SANPHAM.Sanpham_ID == Id);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }

    }

}
