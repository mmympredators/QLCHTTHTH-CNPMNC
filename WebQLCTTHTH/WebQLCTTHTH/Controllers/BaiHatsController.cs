using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebQLCTTHTH.Models;

namespace WebQLCTTHTH.Controllers
{
    public class BaiHatsController : Controller
    {
        private QLCTTHTHEntities1 db = new QLCTTHTHEntities1();

        // GET: BaiHats
        public ActionResult Index()
        {
            var baiHats = db.BaiHats.Include(b => b.ChuDe);
            return View(baiHats.ToList());
        }

        // GET: BaiHats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiHat baiHat = db.BaiHats.Find(id);
            if (baiHat == null)
            {
                return HttpNotFound();
            }
            return View(baiHat);
        }

        // GET: BaiHats/Create
        public ActionResult Create()
        {
            ViewBag.Ma_CD = new SelectList(db.ChuDes, "MaCD", "TenCD");
            return View();
        }

        // POST: BaiHats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBH,TenBH,Nhac,Loi,Ma_CD")] BaiHat baiHat)
        {
            if (ModelState.IsValid)
            {
                db.BaiHats.Add(baiHat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ma_CD = new SelectList(db.ChuDes, "MaCD", "TenCD", baiHat.Ma_CD);
            return View(baiHat);
        }

        // GET: BaiHats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiHat baiHat = db.BaiHats.Find(id);
            if (baiHat == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ma_CD = new SelectList(db.ChuDes, "MaCD", "TenCD", baiHat.Ma_CD);
            return View(baiHat);
        }

        // POST: BaiHats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBH,TenBH,Nhac,Loi,Ma_CD")] BaiHat baiHat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baiHat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ma_CD = new SelectList(db.ChuDes, "MaCD", "TenCD", baiHat.Ma_CD);
            return View(baiHat);
        }

        // GET: BaiHats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiHat baiHat = db.BaiHats.Find(id);
            if (baiHat == null)
            {
                return HttpNotFound();
            }
            return View(baiHat);
        }

        // POST: BaiHats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaiHat baiHat = db.BaiHats.Find(id);
            db.BaiHats.Remove(baiHat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
