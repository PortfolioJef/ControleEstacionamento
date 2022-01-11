using System.Net;
using System.Web.Mvc;
using StaparParking.Models;
using StaparParking.Repository;

namespace StaparParking.Controllers
{
    public class ValetController : Controller
    {
        public ActionResult Index()
        {
            ValetRepository valetRepository = new ValetRepository();
            return View(valetRepository.GetAllValet());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,NumberId,BirthDate")] Models.Valet valetModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ValetRepository valetRepository = new ValetRepository();
                    valetRepository.AddValet(valetModel);
                    ViewBag.Message = "<div class='col-md-offset-2 col-md-10' style='color:green'>Adicionado </div>";
                return RedirectToAction("index");
            }

                return View();
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
                ViewBag.Message ="<div class='col-md-offset-2 col-md-10' style='color:red'>Ocorreu um erro, por favor procure o suporte.</div>";
                return View();
            }

            ValetRepository valetRepository = new ValetRepository();
            Models.Valet valet = valetRepository.GetValetById(id.Value);

            return View(valet);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,NumberId,BirthDate")] Models.Valet valetModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ValetRepository valetRepository = new ValetRepository();
                    valetRepository.UpdateValet(valetModel);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message ="Ocorreu um erro, por favor procure o suporte.";
                return View(valetModel);
            }
        }

        // GET: Valet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValetRepository valetModel = new ValetRepository();
        var valet =     valetModel.GetValetById(id.Value);
            if (valetModel == null)
            {
                return HttpNotFound();
            }
            return View(valet);
        }

        // POST: Valet/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ValetRepository valetRepository = new ValetRepository();
                if (valetRepository.DeleteValet(id))
                {
                    ViewBag.AlertMsg = "deletado!";

                }
                return RedirectToAction("index");
            }
            catch
            {
                return RedirectToAction("index");
            }

        }
    }
}
