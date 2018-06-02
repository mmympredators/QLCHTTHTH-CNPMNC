using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLCTTHTH.Models;

namespace WebQLCTTHTH.Controllers
{
    public class NguoidungController : Controller
    {
        QLCTTHTHDataContext db = new QLCTTHTHDataContext();
        // GET: Nguoidung
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var tendn = collection["username"];
            var matkhau = collection["password"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                ThiSinh ts = db.ThiSinhs.SingleOrDefault(n => n.IDLogin == tendn && n.Pass == matkhau);
                if (ts != null)
                {
                    ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                    Session["Taikhoan"] = ts;
                    Session["TenDangNhap"] = tendn;
                    return RedirectToAction("Index", "QLCTTHTH");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();

        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "QLCTTHTH");
        }
        public ActionResult Dangky()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangky(FormCollection collection, ThiSinh ts)
        {
            var hoten = collection["HoTenTS"];
            var idlogin = collection["IDLogin"];
            var matkhau = collection["Pass"];
            string gioitinh = collection["GT"];
            var diachi = collection["DiachiTS"];
            var quequan = collection["QueQuanTS"];
           
           
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["NamSinhTS"]);
            if (String.IsNullOrEmpty(idlogin))
            {
                ViewData["Loi1"] = "Phải nhập ID";
            }
            else if (String.IsNullOrEmpty(gioitinh))
            {
                ViewData["Loi2"] = "Phải nhập giới tính ";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Phải nhập mật khẩu";
            }
           
            else if (String.IsNullOrEmpty(quequan))
            {
                ViewData["Loi4"] = "Phải nhập quê quán";
            }
            else if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi5"] = "Phải nhập tên ";
            }
            else
            {              
                ts.HoTenTS = hoten;              
                ts.GT = gioitinh;
                ts.DiaChiTS = diachi;
                ts.QueQuanTS = quequan;
                //ts.NamSinhTS = DateTime.Parse(ngaysinh);
                ts.IDLogin = idlogin;
                ts.Pass= matkhau;
                db.ThiSinhs.InsertOnSubmit(ts);
                db.SubmitChanges();
                return RedirectToAction("Dangnhap");
            }
            return this.Dangky();
        }
    }
}