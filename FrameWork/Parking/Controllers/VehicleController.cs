using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StaparParking.Models;
using StaparParking.Repository;

namespace StaparParking.Controllers
{
    public class VehicleController : Controller
    {
        public ActionResult Index()
        {
            VehicleRepository vehicleRepository = new VehicleRepository();
            return View(vehicleRepository.GetAllVehicles());
        }

        //Detalhes do Veiculo existente
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                ViewBag.Message ="<div class='col-md-offset-2 col-md-10' style='color:red'>Ocorreu um erro," +
                    " por favor procure o suporte.</div>";
                return View();
            }

            VehicleRepository VehicleRepository = new VehicleRepository();
            Vehicle Vehicle = VehicleRepository.GetVehicleById(id.Value);

            return View(Vehicle);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Brand,Model,Identification")] Vehicle vehicle)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    VehicleRepository VehicleRepository = new VehicleRepository();
                    VehicleRepository.AddVehicle(vehicle);
                    ViewBag.Message = "<div class='col-md-offset-2 col-md-10' style='color:green'>Adicionado </div>";
                }

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message ="<div class='col-md-offset-2 col-md-10' style='color:red'>Ocorreu um erro, por favor procure o suporte.</div>";
                return View();
            }
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            VehicleRepository vehicleRepository = new VehicleRepository();
            Vehicle vehicle = vehicleRepository.GetVehicleById(id.Value);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Brand,Model,Identification")] Vehicle vehicle)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    VehicleRepository vehicleRepository = new VehicleRepository();
                    vehicleRepository.UpdateVehicle(vehicle);
                }
                return RedirectToAction("Index");

            }
            catch
            {
                ViewBag.Message ="Ocorreu um erro, por favor procure o suporte.";
                return View(vehicle);
            }
        }
    }
}
