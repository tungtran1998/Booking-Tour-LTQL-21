using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Booking_Tour.Models;
using PagedList;

namespace Booking_Tour.Areas.Admin.Controllers
{
    public class ToursController : Controller
    {
        private ConnectDB_BookingTour db = new ConnectDB_BookingTour();

        // GET: Admin/Tours
        public ActionResult Index(int? page)
        {
            var pagesize = 10;
            var tours = db.Tours.Include(t => t.Provinces).ToList();
            int pageNumber = page ?? 1;

            return View(tours.ToPagedList(pageNumber, pagesize));
        }

        // GET: Admin/Tours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tours tours = db.Tours.Find(id);
            if (tours == null)
            {
                return HttpNotFound();
            }
            var DescriptionTour = db.DescriptionTours.Where(m => m.tour_id == id);
            ViewBag.DescriptionTour = DescriptionTour.ToList();

            return View(tours);
        }

        // GET: Admin/Tours/Create
        public ActionResult Create()
        {
            ViewBag.provinces_id = new SelectList(db.Provinces, "id", "name");
            return View();
        }

        // POST: Admin/Tours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,day,description,price,status,avatar,created_at,update_at,provinces_id")] Tours tours, HttpPostedFileBase inputImg)
        {
            if (inputImg != null)
            {

                string extensionName = System.IO.Path.GetExtension(inputImg.FileName);
                string fileName = DateTime.Now.Ticks.ToString();
                string path = "Tour_Images/" + fileName + extensionName;
                string urlImg = System.IO.Path.Combine(Server.MapPath("~/Tour_Images/"), fileName + extensionName);
                inputImg.SaveAs(urlImg);
                tours.avatar = path;

            }

            tours.status = true;
            tours.created_at = DateTime.Now;
            tours.update_at = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Tours.Add(tours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.provinces_id = new SelectList(db.Provinces, "id", "name", tours.provinces_id);
            return View(tours);
        }

        // GET: Admin/Tours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tours tours = db.Tours.Find(id);
            if (tours == null)
            {
                return HttpNotFound();
            }
            ViewBag.provinces_id = new SelectList(db.Provinces, "id", "name", tours.provinces_id);
            return View(tours);
        }

        // POST: Admin/Tours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,day,description,price,status,avatar,created_at,update_at,provinces_id")] Tours tours, HttpPostedFileBase inputImg)
        {
            if (inputImg != null)
            {
                string extensionName = System.IO.Path.GetExtension(inputImg.FileName);
                //string fileName = DateTime.Now.Ticks.ToString();
                string path = "Tour_Images/" + tours.id + extensionName;
                string urlImg = System.IO.Path.Combine(Server.MapPath("~/Tour_Images/"), tours.id + extensionName);
                inputImg.SaveAs(urlImg);
                tours.avatar = path;
            } 
            tours.update_at = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(tours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.provinces_id = new SelectList(db.Provinces, "id", "name", tours.provinces_id);
            return View(tours);
        }

        // GET: Admin/Tours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tours tours = db.Tours.Find(id);
            if (tours == null)
            {
                return HttpNotFound();
            }
            return View(tours);
        }

        // POST: Admin/Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tours tours = db.Tours.Find(id);
            db.Tours.Remove(tours);
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
