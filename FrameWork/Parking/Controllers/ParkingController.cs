using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StaparParking.Data;
using StaparParking.Models;
using StaparParking.Repository;

namespace StaparParking.Controllers
{
    public class ParkingController : Controller
    {  
        public ActionResult Index()
        {
            ParkingRepository parkingrepository = new ParkingRepository();
             return View(parkingrepository.GetAllParkings());
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ValetID,CarId,Date")] Parking parking)
        {
            if (ModelState.IsValid)
            {
                ParkingRepository parkingrepository = new ParkingRepository();
                
                return RedirectToAction("Index");
            }           
            return View(parking);
        }

       
    }
}
