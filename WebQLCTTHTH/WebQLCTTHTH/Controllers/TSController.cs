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
    public class TSController : Controller
    {
        QLCTTHTHDataContext db = new QLCTTHTHDataContext();
        // GET: TS
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TS()
        {
            return View(db.ThiSinhs.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ThiSinh ts, HttpPostedFileBase fileupload)
        {
           
            if (fileupload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh đại diện";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {

                    var fileName = Path.GetFileName(fileupload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);


                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.Thongbao = "Hình đại diện đã tồn tại";
                    }
                    else
                    {
                        fileupload.SaveAs(path);
                    }
                    ts.HinhTS = fileName;
                    db.ThiSinhs.InsertOnSubmit(ts);
                    db.SubmitChanges();
                }
                return RedirectToAction("TS");
            }
            
        }

        public ActionResult Details(int id)
        {
            ThiSinh ts = db.ThiSinhs.SingleOrDefault(n => n.MaTS == id);
            ViewBag.MaTS = ts.MaTS;
            if (ts == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ts);
        }

        public ActionResult Delete(int id)
        {
            ThiSinh ts = db.ThiSinhs.SingleOrDefault(n => n.MaTS == id);
            ViewBag.MaTS = ts.MaTS;
            if (ts == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ts);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            ThiSinh ts = db.ThiSinhs.SingleOrDefault(n => n.MaTS == id);
            ViewBag.MaTS = ts.MaTS;
            if (ts == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.ThiSinhs.DeleteOnSubmit(ts);
            db.SubmitChanges();
            return RedirectToAction("TS");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ThiSinh ts = db.ThiSinhs.SingleOrDefault(n => n.MaTS == id);

            if (ts == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ts);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ThiSinh ts, HttpPostedFileBase fileupload)
        {
            
            var t = db.ThiSinhs.SingleOrDefault(n => n.MaTS == ts.MaTS);
            
            if (ModelState.IsValid)
            {
                
                t.HoTenTS = ts.HoTenTS;
                t.NamSinhTS = ts.NamSinhTS;
                t.GT = ts.GT;
                t.DiaChiTS = ts.DiaChiTS;
                t.QueQuanTS = ts.QueQuanTS;
                t.HinhTS = ts.HinhTS;
                t.NopPhi = ts.NopPhi;
                db.SubmitChanges();
            }
            return RedirectToAction("TS");
        }
    }
}