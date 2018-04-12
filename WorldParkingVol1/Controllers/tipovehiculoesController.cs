using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorldParkingVol1.Models;

namespace WorldParkingVol1.Controllers
{
    public class tipovehiculoesController : Controller
    {
        private ParkingEntities1 db = new ParkingEntities1();

        // GET: tipovehiculoes
        public ActionResult Index()
        {
            var tipovehiculo = db.tipovehiculo.Include(t => t.taifaperiodica).Include(t => t.tarifasminuto);
            return View(tipovehiculo.ToList());
        }

        // GET: tipovehiculoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipovehiculo tipovehiculo = db.tipovehiculo.Find(id);
            if (tipovehiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipovehiculo);
        }

        // GET: tipovehiculoes/Create
        public ActionResult Create()
        {
            ViewBag.TarifaPeriodica = new SelectList(db.taifaperiodica, "idTaifaPeriodica", "Descripcion");
            ViewBag.Tarifa = new SelectList(db.tarifasminuto, "idTarifasMin", "Descripcion");
            return View();
        }

        // POST: tipovehiculoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoVehiculo,Descripcion,Tarifa,TarifaPeriodica")] tipovehiculo tipovehiculo)
        {
            if (ModelState.IsValid)
            {
                db.tipovehiculo.Add(tipovehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TarifaPeriodica = new SelectList(db.taifaperiodica, "idTaifaPeriodica", "Descripcion", tipovehiculo.TarifaPeriodica);
            ViewBag.Tarifa = new SelectList(db.tarifasminuto, "idTarifasMin", "Descripcion", tipovehiculo.Tarifa);
            return View(tipovehiculo);
        }

        // GET: tipovehiculoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipovehiculo tipovehiculo = db.tipovehiculo.Find(id);
            if (tipovehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.TarifaPeriodica = new SelectList(db.taifaperiodica, "idTaifaPeriodica", "Descripcion", tipovehiculo.TarifaPeriodica);
            ViewBag.Tarifa = new SelectList(db.tarifasminuto, "idTarifasMin", "Descripcion", tipovehiculo.Tarifa);
            return View(tipovehiculo);
        }

        // POST: tipovehiculoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoVehiculo,Descripcion,Tarifa,TarifaPeriodica")] tipovehiculo tipovehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipovehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TarifaPeriodica = new SelectList(db.taifaperiodica, "idTaifaPeriodica", "Descripcion", tipovehiculo.TarifaPeriodica);
            ViewBag.Tarifa = new SelectList(db.tarifasminuto, "idTarifasMin", "Descripcion", tipovehiculo.Tarifa);
            return View(tipovehiculo);
        }

        // GET: tipovehiculoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipovehiculo tipovehiculo = db.tipovehiculo.Find(id);
            if (tipovehiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipovehiculo);
        }

        // POST: tipovehiculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipovehiculo tipovehiculo = db.tipovehiculo.Find(id);
            db.tipovehiculo.Remove(tipovehiculo);
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
