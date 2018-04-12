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
    public class facturacionsController : Controller
    {
        private ParkingEntities1 db = new ParkingEntities1();

        // GET: facturacions
        public ActionResult Index()
        {
            var facturacion = db.facturacion.Include(f => f.bahias).Include(f => f.vehiculos).Include(f => f.personas);
            return View(facturacion.ToList());
        }

        // GET: facturacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            facturacion facturacion = db.facturacion.Find(id);
            if (facturacion == null)
            {
                return HttpNotFound();
            }
            return View(facturacion);
        }

        // GET: facturacions/Create
        public ActionResult Create()
        {
            ViewData["Fecha_enrtada"] = DateTime.Now.ToString();
            ViewBag.Bahia = new SelectList(db.bahias, "idBahias", "idBahias");
            ViewBag.IdVehiculo = new SelectList(db.vehiculos, "idVehiculos", "Placa");
            ViewBag.IdPersona = new SelectList(db.personas, "idPersonas", "Nombre");
            return View();
        }

        // POST: facturacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NumeroFactura,IdVehiculo,IdPersona,Fecha_enrtada,Fecha_salida,DetalleObservaciones,Bahia,FacturaPermanente")] facturacion facturacion)
        {
            if (ModelState.IsValid)
            {
                db.facturacion.Add(facturacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bahia = new SelectList(db.bahias, "idBahias", "idBahias", facturacion.Bahia);
            ViewBag.IdVehiculo = new SelectList(db.vehiculos, "idVehiculos", "Placa", facturacion.IdVehiculo);
            ViewBag.IdPersona = new SelectList(db.personas, "idPersonas", "Nombre", facturacion.IdPersona);
            return View(facturacion);
        }

        // GET: facturacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            facturacion facturacion = db.facturacion.Find(id);
            if (facturacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bahia = new SelectList(db.bahias, "idBahias", "idBahias", facturacion.Bahia);
            ViewBag.IdVehiculo = new SelectList(db.vehiculos, "idVehiculos", "Placa", facturacion.IdVehiculo);
            ViewBag.IdPersona = new SelectList(db.personas, "idPersonas", "Nombre", facturacion.IdPersona);
            return View(facturacion);
        }

        // POST: facturacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NumeroFactura,IdVehiculo,IdPersona,Fecha_enrtada,Fecha_salida,DetalleObservaciones,Bahia,FacturaPermanente")] facturacion facturacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facturacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bahia = new SelectList(db.bahias, "idBahias", "idBahias", facturacion.Bahia);
            ViewBag.IdVehiculo = new SelectList(db.vehiculos, "idVehiculos", "Placa", facturacion.IdVehiculo);
            ViewBag.IdPersona = new SelectList(db.personas, "idPersonas", "Nombre", facturacion.IdPersona);
            return View(facturacion);
        }

        // GET: facturacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            facturacion facturacion = db.facturacion.Find(id);
            if (facturacion == null)
            {
                return HttpNotFound();
            }
            return View(facturacion);
        }

        // POST: facturacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            facturacion facturacion = db.facturacion.Find(id);
            db.facturacion.Remove(facturacion);
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
