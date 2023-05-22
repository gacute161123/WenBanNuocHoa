using BanNuocHoa.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BanNuocHoa.Controllers
{
    public class LOGINsController : Controller
    {
        // GET: LOGINs
        protected connect db = new connect();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(NGUOIDUNG entity)
        {
            string tdn = entity.Nguoidung_user;
            string mk = entity.Nguoidung_pass;
            var md5mk = GetMD5(mk);

            var model = db.NGUOIDUNGs.Where(x => x.Nguoidung_user == tdn && x.Nguoidung_pass == md5mk).FirstOrDefault();
            Session["user_id"] = model.Nguoidung_ID;

            if (Session["user_id"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // POST: Admin/NGUOIDUNGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(NGUOIDUNG _user)
        {
            if (ModelState.IsValid)
            {
                var check = db.NGUOIDUNGs.FirstOrDefault(s => s.Nguoidung_email == _user.Nguoidung_email || s.Nguoidung_user == _user.Nguoidung_user);
                if (check == null)
                {
                    _user.Nguoidung_pass = GetMD5(_user.Nguoidung_pass);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.NGUOIDUNGs.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.error = " Email hoặc Tên Đăng Nhập đã tồn tại";
                 
                    return View();
                }


            }
            return View();


        }

        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
        public ActionResult Logout(){
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}