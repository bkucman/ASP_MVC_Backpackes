using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP_MVC_Backpackes.Models;

namespace ASP_MVC_Backpackes.Controllers
{
    public class BackpacksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Backpacks
        public ActionResult Index()
        {
            var backpacks = db.Backpacks.Include(b => b.Manufacturer);
            return View(backpacks.ToList());
        }

        // GET: Backpacks/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Backpack backpack = db.Backpacks.Find(id);
            if (backpack == null)
            {
                return HttpNotFound();
            }
            return View(backpack);
        }

        // GET: Backpacks/Create
        [Authorize(Roles = "Admin,Producent")]
        public ActionResult Create()
        {
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name");
            return View();
        }

        // POST: Backpacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Producent")]
        public ActionResult Create([Bind(Include = "Id,Name,Capacity,Price,Description,ManufacturerId")] Backpack backpack)
        {
            if (ModelState.IsValid)
            {
                db.Backpacks.Add(backpack);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", backpack.ManufacturerId);
            return View(backpack);
        }

        // GET: Backpacks/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Backpack backpack = db.Backpacks.Find(id);
            if (backpack == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", backpack.ManufacturerId);
            return View(backpack);
        }

        // POST: Backpacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Name,Capacity,Price,Description,ManufacturerId")] Backpack backpack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(backpack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", backpack.ManufacturerId);
            return View(backpack);
        }

        // GET: Backpacks/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Backpack backpack = db.Backpacks.Find(id);
            if (backpack == null)
            {
                return HttpNotFound();
            }
            return View(backpack);
        }

        // POST: Backpacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Backpack backpack = db.Backpacks.Find(id);
            db.Backpacks.Remove(backpack);
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
