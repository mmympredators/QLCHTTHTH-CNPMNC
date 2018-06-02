using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLCTTHTH.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace WebQLCTTHTH.Controllers
{

    public class BVDController : Controller
    {
        QLCTTHTHDataContext db = new QLCTTHTHDataContext();
        // GET: BVD
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NTT()
        {
            

            return View(db.NhaTaiTros.ToList());
        }

        [HttpGet]
        public ActionResult NTTCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NTTCreate(NhaTaiTro ntt)
        {

            if (ModelState.IsValid)
            {
                db.NhaTaiTros.InsertOnSubmit(ntt);
                db.SubmitChanges();
            }

            return RedirectToAction("NTT");
        }

        public ActionResult NTTDetails(int id)
        {
            NhaTaiTro ntt = db.NhaTaiTros.SingleOrDefault(n => n.MaNTT == id);
            ViewBag.MaNTT = ntt.MaNTT;
            if (ntt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ntt);
        }

        public ActionResult NTTDelete(int id)
        {
            NhaTaiTro ntt = db.NhaTaiTros.SingleOrDefault(n => n.MaNTT == id);
            ViewBag.MaNTT = ntt.MaNTT;
            if (ntt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ntt);
        }

        [HttpPost, ActionName("NTTDelete")]
        public ActionResult NTTDeleteConfirm(int id)
        {
            NhaTaiTro ntt = db.NhaTaiTros.SingleOrDefault(n => n.MaNTT == id);
            ViewBag.MaNTT = ntt.MaNTT;
            if (ntt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.NhaTaiTros.DeleteOnSubmit(ntt);
            db.SubmitChanges();
            return RedirectToAction("NTT");
        }

        [HttpGet]
        public ActionResult NTTEdit(int id)
        {
            NhaTaiTro ntt = db.NhaTaiTros.SingleOrDefault(n => n.MaNTT == id);
            ViewBag.MaNTT = ntt.MaNTT;
            if (ntt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ntt);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NTTEdit(NhaTaiTro ntt)
        {

            var t = db.NhaTaiTros.SingleOrDefault(n => n.MaNTT == ntt.MaNTT);

            if (ModelState.IsValid)
            {
                
                t.TenNTT = ntt.TenNTT;
                t.DiaChiNTT = ntt.DiaChiNTT;
                t.EmailNTT = ntt.EmailNTT;
                db.SubmitChanges();
            }
            return RedirectToAction("NTT");
        }

        /*===========Chi Tiet Tai Tro Dot Thi=============*/


        public ActionResult CTTTDT()
        {


            return View(db.CTTTDTs.ToList());
        }

        [HttpGet]
        public ActionResult CTTTDTCreate()
        {
            ViewBag.Ma_NTT = new SelectList(db.NhaTaiTros.ToList().OrderBy(n => n.TenNTT), "MaNTT", "TenNTT");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CTTTDTCreate(CTTTDT ttdt)
        {

            if (ModelState.IsValid)
            {
                db.CTTTDTs.InsertOnSubmit(ttdt);
                db.SubmitChanges();
            }

            return RedirectToAction("CTTTDT");
        }

        public ActionResult CTTTDTDetails(int id)
        {
            CTTTDT ttdt = db.CTTTDTs.SingleOrDefault(n => n.MaCTTTDT == id);
            
            ViewBag.MaCTTTDT = ttdt.MaCTTTDT;
            if (ttdt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ttdt);
        }

        public ActionResult CTTTDTDelete(int id)
        {
            CTTTDT ttdt = db.CTTTDTs.SingleOrDefault(n => n.MaCTTTDT == id);
            ViewBag.MaNTT = ttdt.MaCTTTDT;
            if (ttdt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View("CTTTDT");
        }

        [HttpPost, ActionName("CTTTDTDelete")]
        public ActionResult CTTTDTDeleteConfirm(int id)
        {
            CTTTDT ttdt = db.CTTTDTs.SingleOrDefault(n => n.MaCTTTDT == id);
            ViewBag.MaNTT = ttdt.MaCTTTDT;
            if (ttdt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.CTTTDTs.DeleteOnSubmit(ttdt);
            db.SubmitChanges();
            return RedirectToAction("CTTTDT");
        }

        [HttpGet]
        public ActionResult CTTTDTEdit(int id)
        {
            CTTTDT ttdt = db.CTTTDTs.SingleOrDefault(n => n.MaCTTTDT == id);
            ViewBag.Ma_NTT = new SelectList(db.NhaTaiTros.ToList().OrderBy(n => n.TenNTT), "MaNTT", "TenNTT");
            ViewBag.MaNTT = ttdt.MaCTTTDT;
            if (ttdt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ttdt);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CTTTDTEdit(CTTTDT ttdt)
        {

            var t = db.CTTTDTs.SingleOrDefault(n => n.MaCTTTDT == ttdt.MaCTTTDT);

            if (ModelState.IsValid)
            {
                
                t.LT = ttdt.LT;
                t.Ma_NTT = ttdt.Ma_NTT;
                t.SoTienTaiTro = ttdt.SoTienTaiTro;
                t.HinhThuQuangCao = ttdt.HinhThuQuangCao;
                t.LoaiQuangCao = ttdt.LoaiQuangCao;
                db.SubmitChanges();
            }
            return RedirectToAction("CTTTDT");
        }
    }
}