﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudyDatabase.Models;

namespace StudyDatabase.Controllers
{
    public class StudyFileController : Controller
    {
        private StudyDatabaseContext db = new StudyDatabaseContext();

        // GET: /StudyFile/
        public ActionResult Index()
        {
            return View(db.StudyFiles.ToList());
        }

        // GET: /StudyFile/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyFile studyfile = db.StudyFiles.Find(id);
            if (studyfile == null)
            {
                return HttpNotFound();
            }
            return View(studyfile);
        }

        // GET: /StudyFile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /StudyFile/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file){
            var studyfile = new StudyFile(){
                Filename = file.FileName,
                Keywords = new List<Keyword>(){},
                UpdateAt = DateTime.Now
            };
            return View(studyfile);
        }

        // GET: /StudyFile/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyFile studyfile = db.StudyFiles.Find(id);
            if (studyfile == null)
            {
                return HttpNotFound();
            }
            return View(studyfile);
        }

        // POST: /StudyFile/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Filename,UpdateAt")] StudyFile studyfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studyfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studyfile);
        }

        // GET: /StudyFile/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyFile studyfile = db.StudyFiles.Find(id);
            if (studyfile == null)
            {
                return HttpNotFound();
            }
            return View(studyfile);
        }

        // POST: /StudyFile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudyFile studyfile = db.StudyFiles.Find(id);
            db.StudyFiles.Remove(studyfile);
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
