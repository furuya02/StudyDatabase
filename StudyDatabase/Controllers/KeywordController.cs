using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudyDatabase.Models;

namespace StudyDatabase.Controllers
{
    public class KeywordController : Controller
    {
        private StudyDatabaseContext db = new StudyDatabaseContext();

        // GET: /Keyword/
        public ActionResult Index()
        {
            return View(db.Keywords.ToList());
        }

        // GET: /Keyword/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Keyword keyword = db.Keywords.Find(id);
            if (keyword == null)
            {
                return HttpNotFound();
            }
            return View(keyword);
        }

        // GET: /Keyword/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Keyword/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name")] Keyword keyword)
        {
            if (ModelState.IsValid)
            {
                db.Keywords.Add(keyword);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(keyword);
        }

        // GET: /Keyword/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Keyword keyword = db.Keywords.Find(id);
            if (keyword == null)
            {
                return HttpNotFound();
            }
            return View(keyword);
        }

        // POST: /Keyword/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name")] Keyword keyword)
        {
            if (ModelState.IsValid)
            {
                db.Entry(keyword).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(keyword);
        }

        // GET: /Keyword/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Keyword keyword = db.Keywords.Find(id);
            if (keyword == null)
            {
                return HttpNotFound();
            }
            return View(keyword);
        }

        // POST: /Keyword/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Keyword keyword = db.Keywords.Find(id);
            db.Keywords.Remove(keyword);
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
