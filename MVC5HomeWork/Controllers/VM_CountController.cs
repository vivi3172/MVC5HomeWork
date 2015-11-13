using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5HomeWork.Models;

namespace MVC5HomeWork.Controllers
{
    public class VM_CountController : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: VM_Count
        public ActionResult Index()
        {
            return View(db.VM_Count.ToList());
        }

        // GET: VM_Count/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VM_Count vM_Count = db.VM_Count.Find(id);
            if (vM_Count == null)
            {
                return HttpNotFound();
            }
            return View(vM_Count);
        }

        // GET: VM_Count/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VM_Count/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,客戶名稱,聯絡人數量,銀行帳戶數量")] VM_Count vM_Count)
        {
            if (ModelState.IsValid)
            {
                db.VM_Count.Add(vM_Count);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vM_Count);
        }

        // GET: VM_Count/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VM_Count vM_Count = db.VM_Count.Find(id);
            if (vM_Count == null)
            {
                return HttpNotFound();
            }
            return View(vM_Count);
        }

        // POST: VM_Count/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,客戶名稱,聯絡人數量,銀行帳戶數量")] VM_Count vM_Count)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vM_Count).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vM_Count);
        }

        // GET: VM_Count/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VM_Count vM_Count = db.VM_Count.Find(id);
            if (vM_Count == null)
            {
                return HttpNotFound();
            }
            return View(vM_Count);
        }

        // POST: VM_Count/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VM_Count vM_Count = db.VM_Count.Find(id);
            db.VM_Count.Remove(vM_Count);
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
