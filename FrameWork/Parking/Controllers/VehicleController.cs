using System.Web.Mvc;
using StaparParking.Models;
using StaparParking.Repository;

namespace StaparParking.Controllers
{
    public class VehicleController : Controller
    {

        //Detalhes do Veiculo existente
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                ViewBag.Message ="<div class='col-md-offset-2 col-md-10' style='color:red'>Ocorreu um erro, por favor procure o suporte.</div>";
                return View();
            }

            VehicleRepository VehicleRepository = new VehicleRepository();
            Vehicle Vehicle = VehicleRepository.GetVehicleById(id.Value);

            return View(Vehicle);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,NumberId,BirthDate")] Vehicle vehicle)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    VehicleRepository VehicleRepository = new VehicleRepository();
                    VehicleRepository.AddVehicle(vehicle);
                    ViewBag.Message = "<div class='col-md-offset-2 col-md-10' style='color:green'>Adicionado </div>";
                }

                return View();
            }
            catch
            {
                ViewBag.Message ="<div class='col-md-offset-2 col-md-10' style='color:red'>Ocorreu um erro, por favor procure o suporte.</div>";
                return View();
            }
        }


    }
}
