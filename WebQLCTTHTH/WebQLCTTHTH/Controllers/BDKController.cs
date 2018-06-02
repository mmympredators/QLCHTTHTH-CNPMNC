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
    public class BDKController : Controller
    {
        QLCTTHTHDataContext db = new QLCTTHTHDataContext();
        // GET: BDK
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult DT()
        {
            return View(db.DotThis.ToList());
        }

        [HttpGet]
        public ActionResult DTCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DTCreate(DotThi dt)
        {

                if (ModelState.IsValid)
                {
                    db.DotThis.InsertOnSubmit(dt);
                    db.SubmitChanges();
                }
            
            return RedirectToAction("DT");
        }
        public ActionResult DTDetails(int id)
        {
            DotThi dt = db.DotThis.SingleOrDefault(n => n.LanThi == id);
            ViewBag.LanThi = dt.LanThi;
            if (dt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dt);
        }

        public ActionResult DTDelete(int id)
        {
            DotThi dt = db.DotThis.SingleOrDefault(n => n.LanThi == id);
            ViewBag.LanThi = dt.LanThi;
            if (dt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dt);
        }

        [HttpPost, ActionName("DTDelete")]
        public ActionResult DTDeleteConfirm(int id)
        {
            DotThi dt = db.DotThis.SingleOrDefault(n => n.LanThi == id);
            ViewBag.LanThi = dt.LanThi;
            if (dt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.DotThis.DeleteOnSubmit(dt);
            db.SubmitChanges();
            return RedirectToAction("DT");
        }

        [HttpGet]
        public ActionResult DTEdit(int id)
        {
            DotThi dt = db.DotThis.SingleOrDefault(n => n.LanThi == id);
            ViewBag.LanThi = dt.LanThi;
            if (dt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dt);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DTEdit(DotThi dt)
        {

            var d = db.DotThis.SingleOrDefault(n => n.LanThi == dt.LanThi);

            if (ModelState.IsValid)
            {
               
                d.NamThi = dt.NamThi;
                d.NoiDung = dt.NoiDung;
                db.SubmitChanges();
            }
            return RedirectToAction("DT");
        }
        //// GET: Default/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Default/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Default/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Default/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Default/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Default/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        /*==================Giaithuong=====================*/

        public ActionResult GT()
        {
            

            return View(db.GiaiThuongs.ToList());
        }

        [HttpGet]
        public ActionResult GTCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult GTCreate(GiaiThuong gt)
        {

            if (ModelState.IsValid)
            {
                db.GiaiThuongs.InsertOnSubmit(gt);
                db.SubmitChanges();
            }

            return RedirectToAction("GT");
        }
        public ActionResult GTDetails(int id)
        {
            GiaiThuong gt = db.GiaiThuongs.SingleOrDefault(n => n.MaGT == id);
            ViewBag.MaGT = gt.MaGT;
            if (gt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(gt);
        }

        public ActionResult GTDelete(int id)
        {
            GiaiThuong gt = db.GiaiThuongs.SingleOrDefault(n => n.MaGT == id);
            ViewBag.MaGT = gt.MaGT;
            if (gt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(gt);
        }

        [HttpPost, ActionName("GTDelete")]
        public ActionResult GTDeleteConfirm(int id)
        {
            GiaiThuong gt = db.GiaiThuongs.SingleOrDefault(n => n.MaGT == id);
            ViewBag.MaGT = gt.MaGT;
            if (gt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.GiaiThuongs.DeleteOnSubmit(gt);
            db.SubmitChanges();
            return RedirectToAction("GT");
        }

        [HttpGet]
        public ActionResult GTEdit(int id)
        {
            GiaiThuong gt = db.GiaiThuongs.SingleOrDefault(n => n.MaGT == id);
            ViewBag.MaGT = gt.MaGT;
            if (gt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(gt);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult GTEdit(GiaiThuong gt)
        {

            var g = db.GiaiThuongs.SingleOrDefault(n => n.MaGT == gt.MaGT);

            if (ModelState.IsValid)
            {
                
                g.TenGiaiThuong = gt.TenGiaiThuong;
                g.SoTienThuong = gt.SoTienThuong;
                db.SubmitChanges();
            }
            return RedirectToAction("GT");
        }

        /*==================VongThi=====================*/

        public ActionResult VT()
        {
            return View(db.VongThis.ToList());
        }

        [HttpGet]
        public ActionResult VTCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult VTCreate(VongThi vt)
        {

            if (ModelState.IsValid)
            {
                db.VongThis.InsertOnSubmit(vt);
                db.SubmitChanges();
            }

            return RedirectToAction("VT");
        }

        public ActionResult VTDetails(int id)
        {
            VongThi vt = db.VongThis.SingleOrDefault(n => n.MaVT == id);
            ViewBag.MaVT = vt.MaVT;
            if (vt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(vt);
        }

        public ActionResult VTDelete(int id)
        {
            VongThi vt = db.VongThis.SingleOrDefault(n => n.MaVT == id);
            ViewBag.MaVT = vt.MaVT;
            if (vt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(vt);
        }

        [HttpPost, ActionName("VTDelete")]
        public ActionResult VTDeleteConfirm(int id)
        {
            VongThi vt = db.VongThis.SingleOrDefault(n => n.MaVT == id);
            ViewBag.MaVT = vt.MaVT;
            if (vt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.VongThis.DeleteOnSubmit(vt);
            db.SubmitChanges();
            return RedirectToAction("VT");
        }

        [HttpGet]
        public ActionResult VTEdit(int id)
        {
            VongThi vt = db.VongThis.SingleOrDefault(n => n.MaVT == id);
            ViewBag.MaVT = vt.MaVT;
            if (vt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(vt);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult VTEdit(VongThi vt)
        {

            var v = db.VongThis.SingleOrDefault(n => n.MaVT == vt.MaVT);

            if (ModelState.IsValid)
            {
                
                v.TenVT = vt.TenVT;
                
                db.SubmitChanges();
            }
            return RedirectToAction("VT");
        }

        /*==================Quản lý vòng thi đợt thi=====================*/

        public ActionResult CTVT_DT()
        {
            
            return View(db.CTVT_DTs.ToList());
        }

        [HttpGet]
        public ActionResult CTVT_DTCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CTVT_DTCreate(CTVT_DT vtdt)
        {

            if (ModelState.IsValid)
            {
                db.CTVT_DTs.InsertOnSubmit(vtdt);
                db.SubmitChanges();
            }

            return RedirectToAction("CTVT_DT");
        }

        public ActionResult CTVT_DTDetails(int id)
        {
            CTVT_DT vtdt = db.CTVT_DTs.SingleOrDefault(n => n.MaCTVT_DT == id);
            ViewBag.MaCTVT_DT = vtdt.MaCTVT_DT;
            if (vtdt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(vtdt);
        }

        public ActionResult CTVT_DTDelete(int id)
        {
            CTVT_DT vtdt = db.CTVT_DTs.SingleOrDefault(n => n.MaCTVT_DT == id);
            ViewBag.MaCTVT_DT = vtdt.MaCTVT_DT;
            if (vtdt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(vtdt);
        }

        [HttpPost, ActionName("CTVT_DTDelete")]
        public ActionResult CTVT_DTDeleteConfirm(int id)
        {
            CTVT_DT vtdt = db.CTVT_DTs.SingleOrDefault(n => n.MaCTVT_DT == id);
            ViewBag.MaCTVT_DT = vtdt.MaCTVT_DT;
            if (vtdt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.CTVT_DTs.DeleteOnSubmit(vtdt);
            db.SubmitChanges();
            return RedirectToAction("CTVT_DT");
        }

        [HttpGet]
        public ActionResult CTVT_DTEdit(int id)
        {
            CTVT_DT vtdt = db.CTVT_DTs.SingleOrDefault(n => n.MaCTVT_DT == id);
            ViewBag.MaCTVT_DT = vtdt.MaCTVT_DT;
            if (vtdt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(vtdt);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CTVT_DTEdit(CTVT_DT vtdt)
        {

            var v = db.CTVT_DTs.SingleOrDefault(n => n.MaCTVT_DT == vtdt.MaCTVT_DT);

            if (ModelState.IsValid)
            {
                
                v.Ma_VT = vtdt.Ma_VT;
                v.LT = vtdt.LT;
                v.DiaDiemThi = vtdt.DiaDiemThi;
                v.ThoiGianThi = vtdt.ThoiGianThi;
                v.DiaDiemTap = vtdt.DiaDiemTap;
                v.ThoiGianTap = vtdt.ThoiGianTap;
                v.Ma_VT = vtdt.Ma_VT;

                db.SubmitChanges();
            }
            return RedirectToAction("CTVT_DT");
        }
    }
}