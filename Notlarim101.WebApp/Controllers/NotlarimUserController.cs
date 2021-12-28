using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Notlarim101.Entity;
using Notlarim101.WebApp.Data;

namespace Notlarim101.WebApp.Controllers
{
    public class NotlarimUserController : Controller
    {
        private Notlarim101WebAppContext db = new Notlarim101WebAppContext();

        // GET: NotlarimUser
        public ActionResult Index()
        {
            return View(db.NotlarimUsers.ToList());
        }

        // GET: NotlarimUser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotlarimUser notlarimUser = db.NotlarimUsers.Find(id);
            if (notlarimUser == null)
            {
                return HttpNotFound();
            }
            return View(notlarimUser);
        }

        // GET: NotlarimUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NotlarimUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Surname,Username,Email,Password,ProfileImageFilename,IsActive,ActivateGuid,IsAdmin,CreatedOn,ModifiedOn,ModifiedUsername")] NotlarimUser notlarimUser)
        {
            if (ModelState.IsValid)
            {
                db.NotlarimUsers.Add(notlarimUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notlarimUser);
        }

        // GET: NotlarimUser/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotlarimUser notlarimUser = db.NotlarimUsers.Find(id);
            if (notlarimUser == null)
            {
                return HttpNotFound();
            }
            return View(notlarimUser);
        }

        // POST: NotlarimUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,Username,Email,Password,ProfileImageFilename,IsActive,ActivateGuid,IsAdmin,CreatedOn,ModifiedOn,ModifiedUsername")] NotlarimUser notlarimUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notlarimUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notlarimUser);
        }

        // GET: NotlarimUser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotlarimUser notlarimUser = db.NotlarimUsers.Find(id);
            if (notlarimUser == null)
            {
                return HttpNotFound();
            }
            return View(notlarimUser);
        }

        // POST: NotlarimUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NotlarimUser notlarimUser = db.NotlarimUsers.Find(id);
            db.NotlarimUsers.Remove(notlarimUser);
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
