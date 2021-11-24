using Booking_Tour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Booking_Tour.Controllers
{
    public class BookingController : Controller
    {
        ConnectDB_BookingTour db = new ConnectDB_BookingTour();
        // GET: Booking
        public ActionResult Booking(int? id)
        {
            if(Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tours tour = db.Tours.Find(id);
            if(tour == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tour = tour;
            return View();
        }

        [HttpPost]
        public ActionResult CreateBill()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var unitPrice = int.Parse(Request["unit_price"]);
            var userId = int.Parse(Request["user_id"]);
            var tourId = int.Parse(Request["tour_id"]);
            var numberPerson = int.Parse(Request["person"]);
            double discountPercent = int.Parse(Request["discount"]);

            int totalPrice = unitPrice * numberPerson;
            double discount = totalPrice * (discountPercent / 100);
            var payments = totalPrice - discount;
            Bills bills = new Bills();
            bills.payments = payments;
            bills.user_id = userId;
            bills.tour_id = tourId;
            bills.discount = discount;
            bills.total_price = totalPrice;
            bills.person = numberPerson;
            bills.discount_percent = discountPercent;
            bills.created_at = DateTime.Now;
            db.Bills.Add(bills);
            db.SaveChanges();

            var detailBill = db.Bills.Where(b => b.user_id.Equals(userId)).ToList().LastOrDefault().id;
            return RedirectToAction("ShowBill", new { id = detailBill });
        }

        public ActionResult ShowBill(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bills bill = db.Bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        public ActionResult ListBill()
        {
            var bills = db.Bills.ToList();
            return View(bills);
        }
        public ActionResult SearchTour(Provinces provinces)
        {
            //List<Regions> regions = db.Regions.ToList();
            /*Regions regions = new Regions();
            ViewBag.provinces = new SelectList(db.Provinces, "id", "name", regions.id);*/
            ViewBag.region_id = new SelectList(db.Regions, "id", "name", provinces.region_id);
            /*Regions regions = new Regions();
            ViewBag.regions = regions;*/
            return View();
        }
    }
}