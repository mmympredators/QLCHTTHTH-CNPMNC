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
    public class ThiSinhsController : Controller
    {
        private QLCTTHTHEntities1 db = new QLCTTHTHEntities1();

        // GET: ThiSinhs
        public ActionResult Index()
        {
            return View(db.ThiSinhs.ToList());
        }

        // GET: ThiSinhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThiSinh thiSinh = db.ThiSinhs.Find(id);
            if (thiSinh == null)
            {
                return HttpNotFound();
            }
            return View(thiSinh);
        }

        // GET: ThiSinhs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThiSinhs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTS,HoTenTS,NamSinhTS,GT,DiaChiTS,QueQuanTS,HinhTS,NopPhi")] ThiSinh thiSinh)
        {
            if (ModelState.IsValid)
            {
                db.ThiSinhs.Add(thiSinh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thiSinh);
        }

        // GET: ThiSinhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThiSinh thiSinh = db.ThiSinhs.Find(id);
            if (thiSinh == null)
            {
                return HttpNotFound();
            }
            return View(thiSinh);
        }

        // POST: ThiSinhs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTS,HoTenTS,NamSinhTS,GT,DiaChiTS,QueQuanTS,HinhTS,NopPhi")] ThiSinh thiSinh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thiSinh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thiSinh);
        }

        // GET: ThiSinhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThiSinh thiSinh = db.ThiSinhs.Find(id);
            if (thiSinh == null)
            {
                return HttpNotFound();
            }
            return View(thiSinh);
        }

        // POST: ThiSinhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThiSinh thiSinh = db.ThiSinhs.Find(id);
            db.ThiSinhs.Remove(thiSinh);
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
