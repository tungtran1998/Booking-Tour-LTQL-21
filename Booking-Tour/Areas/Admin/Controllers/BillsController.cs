using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Booking_Tour.Models;

namespace Booking_Tour.Areas.Admin.Controllers
{
    public class BillsController : Controller
    {
        private ConnectDB_BookingTour db = new ConnectDB_BookingTour();

        // GET: Admin/Bills
        [HttpGet]
        public ActionResult Index(int? month, int? year)
        {

            int currentMouth = month ??  DateTime.Now.Month;
            int currentYear = year ?? DateTime.Now.Year;

            ViewBag.Month = currentMouth;
            ViewBag.Year = currentYear;

            var bills = db.Bills.Include(b => b.Tours).Include(b => b.Users).Where(b => b.created_at.Month.Equals(currentMouth) && b.created_at.Year.Equals(currentYear));
            if (bills.Count() != 0)
            {
                double total = 0;
                double discount = 0;
                foreach (var item in bills.ToList())
                {
                    discount += item.discount;

                    total += item.payments;
                }
                ViewBag.Total = total;
                ViewBag.Discount = discount;
            }
            else
            {
                ViewBag.Total = 0;

            }
            return View(bills.ToList());
        }

        // GET: Admin/Bills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bills bills = db.Bills.Find(id);
            if (bills == null)
            {
                return HttpNotFound();
            }
            return View(bills);
        }

        // GET: Admin/Bills/Create
        public ActionResult Create()
        {
            ViewBag.tour_id = new SelectList(db.Tours, "id", "name");
            ViewBag.user_id = new SelectList(db.Users, "id", "name");
            return View();
        }

        // POST: Admin/Bills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,payments,discount,discount_percent,total_price,person,status,created_at,user_id,tour_id")] Bills bills)
        {
            if (ModelState.IsValid)
            {
                db.Bills.Add(bills);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tour_id = new SelectList(db.Tours, "id", "name", bills.tour_id);
            ViewBag.user_id = new SelectList(db.Users, "id", "name", bills.user_id);
            return View(bills);
        }

        // GET: Admin/Bills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bills bills = db.Bills.Find(id);
            if (bills == null)
            {
                return HttpNotFound();
            }
            ViewBag.tour_id = new SelectList(db.Tours, "id", "name", bills.tour_id);
            ViewBag.user_id = new SelectList(db.Users, "id", "name", bills.user_id);
            return View(bills);
        }

        // POST: Admin/Bills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,payments,discount,discount_percent,total_price,person,status,created_at,user_id,tour_id")] Bills bills)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bills).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tour_id = new SelectList(db.Tours, "id", "name", bills.tour_id);
            ViewBag.user_id = new SelectList(db.Users, "id", "name", bills.user_id);
            return View(bills);
        }

        // GET: Admin/Bills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bills bills = db.Bills.Find(id);
            if (bills == null)
            {
                return HttpNotFound();
            }
            return View(bills);
        }

        // POST: Admin/Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bills bills = db.Bills.Find(id);
            db.Bills.Remove(bills);
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
