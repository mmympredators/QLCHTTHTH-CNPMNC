using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLCTTHTH.Models;

namespace WebQLCTTHTH.Controllers
{
    
    public class AdminController : Controller
    {
        QLCTTHTHDataContext db = new QLCTTHTHDataContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection colection)
        {
            var tendn = colection["username"];
            var mk = colection["password"];
            if (String.IsNullOrEmpty(tendn) && String.IsNullOrEmpty(mk))
            {
                ViewData["Loi1"] = "Phải nhập username";
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập username";
            }
            else if (String.IsNullOrEmpty(mk))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                Admin ad = db.Admins.SingleOrDefault(n => n.User == tendn && n.Password == mk);
                if (ad != null)
                {
                    //ViewBag.ThongBao = "Chúc mừng đăng nhập thành công";
                    Session["Taikhoanadmin"] = ad;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                }
            }



            return View();
        }
    }
}