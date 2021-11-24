using Booking_Tour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using PagedList;

namespace Booking_Tour.Controllers
{
    public class HomeController : Controller
    {
        private ConnectDB_BookingTour db = new ConnectDB_BookingTour();
        public ActionResult Index()
        {
            ViewBag.ActiveHome = null;
            if (Request.CurrentExecutionFilePath == "/" || Request.CurrentExecutionFilePath == "/Home/Index")
            {
                ViewBag.ActiveHome = "active";
            }
            var tours = (from t in db.Tours select t).Take(6);
            var recommendedTours = (from ot in db.Tours 
                                    where ot.Provinces.name == "Hà Nội"
                                    select ot).Take(4);
            ViewBag.Tours = tours;
            ViewBag.RecommendedTours = recommendedTours;
            ViewBag.Provinces = (from p in db.Provinces select p).Take(3);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.ActiveAbout = null;
            if (Request.CurrentExecutionFilePath == "/Home/About")
            {
                ViewBag.ActiveAbout = "active";
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.ActiveContact = null;
            if (Request.CurrentExecutionFilePath == "/Home/Contact")
            {
                ViewBag.ActiveContact = "active";
            }
            return View();
        }

        public ActionResult Tours(int? page)
        {
            ViewBag.ActiveTours = null;
            if (Request.CurrentExecutionFilePath == "/Home/Tours")
            {
                ViewBag.ActiveTours = "active";
            }
            ViewBag.Provinces = (from p in db.Provinces select p).ToList();
            var pagesize = 10;
            var tours = db.Tours.Include(t => t.Provinces).ToList();
            int pageNumber = page ?? 1;

            return View(tours.ToPagedList(pageNumber, pagesize));
        }

        public ActionResult ShowTour(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tours tour = db.Tours.Find(id);
            if(tour == null)
            {
                return HttpNotFound();
            }

            var DescriptionTour = db.DescriptionTours.Where(m => m.tour_id == id);
            ViewBag.DescriptionTour = DescriptionTour.ToList();
            ViewBag.tour = tour;
            return View();
        }
        /*Start Login */
        
        
    }
}
