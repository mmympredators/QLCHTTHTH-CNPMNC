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
    public class BGKController : Controller
    {
        QLCTTHTHDataContext db = new QLCTTHTHDataContext();
        // GET: TS
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChuDe()
        {
            return View(db.ChuDes.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ChuDe cd)
        {

            if (ModelState.IsValid)
            {
                db.ChuDes.InsertOnSubmit(cd);
                db.SubmitChanges();
            }

            return RedirectToAction("ChuDe");
        }

        public ActionResult Details(int id)
        {
            ChuDe cd = db.ChuDes.SingleOrDefault(n => n.MaCD == id);
            ViewBag.MaCD = cd.MaCD;
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(cd);
        }

        public ActionResult Delete(int id)
        {
            ChuDe cd = db.ChuDes.SingleOrDefault(n => n.MaCD == id);
            ViewBag.MaCD = cd.MaCD;
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(cd);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            ChuDe cd = db.ChuDes.SingleOrDefault(n => n.MaCD == id);
            ViewBag.MaTS = cd.MaCD;
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.ChuDes.DeleteOnSubmit(cd);
            db.SubmitChanges();
            return RedirectToAction("ChuDe");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ChuDe cd = db.ChuDes.SingleOrDefault(n => n.MaCD == id);
            ViewBag.MaCD = cd.MaCD;
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(cd);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ChuDe cd)
        {

            var c = db.ChuDes.SingleOrDefault(n => n.MaCD == cd.MaCD);

            if (ModelState.IsValid)
            {
                
                c.TenCD = cd.TenCD;
                
                db.SubmitChanges();
            }
            return RedirectToAction("ChuDe");
        }

        /*==================BaiHat=======================*/

        public ActionResult BaiHat()
        {
            return View(db.BaiHats.ToList());
        }
        [HttpGet]
        public ActionResult CreateBH()
        {
            ViewBag.Ma_CD = new SelectList(db.ChuDes.ToList().OrderBy(n => n.TenCD), "MaCD", "TenCD");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateBH(BaiHat bh)
        {

            if (ModelState.IsValid)
            {
                db.BaiHats.InsertOnSubmit(bh);
                db.SubmitChanges();
            }

            return RedirectToAction("BaiHat");
        }
        public ActionResult DetailsBH(int id)
        {
            BaiHat bh = db.BaiHats.SingleOrDefault(n => n.MaBH == id);
            ViewBag.MaBH = bh.MaBH;
            if (bh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(bh);
        }

        public ActionResult DeleteBH(int id)
        {
            BaiHat bh = db.BaiHats.SingleOrDefault(n => n.MaBH == id);
            ViewBag.MaBH = bh.MaBH;
            if (bh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(bh);
        }

        [HttpPost, ActionName("DeleteBH")]
        public ActionResult DeleteBHConfirm(int id)
        {
            BaiHat bh = db.BaiHats.SingleOrDefault(n => n.MaBH == id);
            ViewBag.MaBH = bh.MaBH;
            if (bh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.BaiHats.DeleteOnSubmit(bh);
            db.SubmitChanges();
            return RedirectToAction("BaiHat");
        }

        [HttpGet]
        public ActionResult EditBH(int id)
        {
            BaiHat bh = db.BaiHats.SingleOrDefault(n => n.MaBH == id);
            ViewBag.Ma_CD = new SelectList(db.ChuDes.ToList().OrderBy(n => n.TenCD), "MaCD", "TenCD");
            ViewBag.MaBH = bh.MaBH;
            if (bh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(bh);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditBH(BaiHat bh)
        {

            var b = db.BaiHats.SingleOrDefault(n => n.MaBH == bh.MaBH);

            if (ModelState.IsValid)
            {
                
                b.TenBH = bh.TenBH;
                b.Nhac = bh.Nhac;
                b.Loi = bh.Loi;
                b.Ma_CD = bh.Ma_CD;

                db.SubmitChanges();
            }
            return RedirectToAction("BaiHat");
        }

        /*==================Chi tiết vòng thi thí sinh=======================*/

        public ActionResult CTVT_TS()
        {
            

            
            return View(db.CTVT_TS.ToList());
        }
        [HttpGet]
        public ActionResult CTVT_TSCreate()
        {
            ViewBag.Ma_VT = new SelectList(db.VongThis.ToList().OrderBy(n => n.TenVT), "MaVT", "TenVT");
            ViewBag.SBD = new SelectList(db.ThiSinhs.ToList().OrderBy(n => n.HoTenTS), "MaTS", "HoTenTS");
            ViewBag.BaiHatBB = new SelectList(db.BaiHats.ToList().OrderBy(n => n.TenBH), "MaBH", "TenBH");
            ViewBag.BaiHatTC = new SelectList(db.BaiHats.ToList().OrderBy(n => n.TenBH), "MaBH", "TenBH");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CTVT_TSCreate(CTVT_TS vtts)
        {
            
            if (ModelState.IsValid)
            {
                db.CTVT_TS.InsertOnSubmit(vtts);
                db.SubmitChanges();
            }

            return RedirectToAction("CTVT_TS");
        }
        public ActionResult CTVT_TSDetails(int id)
        {
            CTVT_TS vtts = db.CTVT_TS.SingleOrDefault(n => n.MaCTVT_TS == id);
            ViewBag.MaCTVT_TS = vtts.MaCTVT_TS;
            if (vtts == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(vtts);
        }

        public ActionResult CTVT_TSDelete(int id)
        {
            CTVT_TS vtts = db.CTVT_TS.SingleOrDefault(n => n.MaCTVT_TS == id);
            ViewBag.MaCTVT_TS = vtts.MaCTVT_TS;
            if (vtts == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(vtts);
        }

        [HttpPost, ActionName("CTVT_TSDelete")]
        public ActionResult CTVT_TSDeleteConfirm(int id)
        {
            CTVT_TS vtts = db.CTVT_TS.SingleOrDefault(n => n.MaCTVT_TS == id);
            ViewBag.MaCTVT_TS = vtts.MaCTVT_TS;
            if (vtts == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.CTVT_TS.DeleteOnSubmit(vtts);
            db.SubmitChanges();
            return RedirectToAction("CTVT_TS");
        }

        [HttpGet]
        public ActionResult CTVT_TSEdit(int id)
        {
            CTVT_TS vtts = db.CTVT_TS.SingleOrDefault(n => n.MaCTVT_TS == id);
            ViewBag.MaCTVT_TS = vtts.MaCTVT_TS;
            if (vtts == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(vtts);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CTVT_TSEdit(CTVT_TS ctvt)
        {

            var b = db.CTVT_TS.SingleOrDefault(n => n.MaCTVT_TS == ctvt.MaCTVT_TS);

            if (ModelState.IsValid)
            {
                
                b.Ma_VT = ctvt.Ma_VT;
                b.SBD = ctvt.SBD;
                b.BaiHatBB = ctvt.BaiHatBB;
                b.DiemBHBB = ctvt.DiemBHBB;
                b.BaiHatTC = ctvt.BaiHatTC;
                b.DiemBHTC = ctvt.DiemBHTC;

                db.SubmitChanges();
            }
            return RedirectToAction("CTVT_TS");
        }
    }
}