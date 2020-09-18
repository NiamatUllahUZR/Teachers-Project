using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Teacher_.Models;

namespace Teacher_.Controllers
{
    public class TeacherModelsController : Controller
    {
        private TeacherDBContext db = new TeacherDBContext();

        // GET: TeacherModels
        public ActionResult Index(string searchString)
        {
            var teachers = from m in db.Teachers
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                teachers = teachers.Where(s => s.Name.Contains(searchString));
            }

            return View(teachers);
        }

        // GET: TeacherModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherModel teacherModel = db.Teachers.Find(id);
            if (teacherModel == null)
            {
                return HttpNotFound();
            }
            return View(teacherModel);
        }

        // GET: TeacherModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,DateOfBirth,Subject,Salary")] TeacherModel teacherModel)
        {
            if (ModelState.IsValid)
            {
                db.Teachers.Add(teacherModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teacherModel);
        }

        // GET: TeacherModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherModel teacherModel = db.Teachers.Find(id);
            if (teacherModel == null)
            {
                return HttpNotFound();
            }
            return View(teacherModel);
        }

        // POST: TeacherModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,DateOfBirth,Subject,Salary")] TeacherModel teacherModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacherModel);
        }

        // GET: TeacherModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherModel teacherModel = db.Teachers.Find(id);
            if (teacherModel == null)
            {
                return HttpNotFound();
            }
            return View(teacherModel);
        }

        // POST: TeacherModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherModel teacherModel = db.Teachers.Find(id);
            db.Teachers.Remove(teacherModel);
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
