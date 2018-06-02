using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLCTTHTH.Models;

namespace WebQLCTTHTH.Controllers
{
    public class QLCTTHTHController : Controller
    {
        QLCTTHTHDataContext db = new QLCTTHTHDataContext();
        // GET: QLCTTHTH
        private List<ThiSinh> ThiSinh(int count)
        {
            return db.ThiSinhs.OrderByDescending(a => a.NamSinhTS).Take(count).ToList();
        }

        public ActionResult Index()
        {
            var thisinh = ThiSinh(4);
            return View(thisinh);
        }
        public ActionResult TheLeThi()
        {
            return View();
        }
        public ActionResult DanhSachThiSinh()
        {
            var thisinh = ThiSinh(10);
            return View(thisinh);
        }
        public ActionResult ChiTietThiSinh(int id)
        {
            var ts = from s in db.ThiSinhs
                     where s.MaTS == id
                     select s;


            return View(ts.Single());
        }
        public ActionResult GiamKhao()
        {
            return View();
        }
        public ActionResult CT_GK()
        {
            return View();
        }
        public ActionResult NhaTaiTro()
        {
            return View();
        }
        public ActionResult CT_NTT()
        {
            return View();
        }
    }
}