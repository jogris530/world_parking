using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorldParkingVol1.Models;

namespace WorldParkingVol1.Controllers
{
    public class vehiculosController : Controller
    {
        private ParkingEntities1 db = new ParkingEntities1();

        // GET: vehiculos
        public async Task<ActionResult> Index()
        {
            var vehiculos = db.vehiculos.Include(v => v.colorvehiculo).Include(v => v.marcasvehiculo).Include(v => v.tipovehiculo1);
            return View(await vehiculos.ToListAsync());
        }

        // GET: vehiculos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehiculos vehiculos = await db.vehiculos.FindAsync(id);
            if (vehiculos == null)
            {
                return HttpNotFound();
            }
            return View(vehiculos);
        }

        // GET: vehiculos/Create
        public ActionResult Create()
        {
            ViewBag.Color = new SelectList(db.colorvehiculo, "idColorVehiculo", "ColorVehiculo1");
            ViewBag.Marca = new SelectList(db.marcasvehiculo, "idMarcasVehiculo", "MarcasVehiculo1");
            ViewBag.TipoVehiculo = new SelectList(db.tipovehiculo, "idTipoVehiculo", "Descripcion");
            return View();
        }

        // POST: vehiculos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idVehiculos,Placa,Color,Modelo,Marca,TipoVehiculo")] vehiculos vehiculos)
        {
            if (ModelState.IsValid)
            {
                db.vehiculos.Add(vehiculos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Color = new SelectList(db.colorvehiculo, "idColorVehiculo", "ColorVehiculo1", vehiculos.Color);
            ViewBag.Marca = new SelectList(db.marcasvehiculo, "idMarcasVehiculo", "MarcasVehiculo1", vehiculos.Marca);
            ViewBag.TipoVehiculo = new SelectList(db.tipovehiculo, "idTipoVehiculo", "Descripcion", vehiculos.TipoVehiculo);
            return View(vehiculos);
        }

        // GET: vehiculos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehiculos vehiculos = await db.vehiculos.FindAsync(id);
            if (vehiculos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Color = new SelectList(db.colorvehiculo, "idColorVehiculo", "ColorVehiculo1", vehiculos.Color);
            ViewBag.Marca = new SelectList(db.marcasvehiculo, "idMarcasVehiculo", "MarcasVehiculo1", vehiculos.Marca);
            ViewBag.TipoVehiculo = new SelectList(db.tipovehiculo, "idTipoVehiculo", "Descripcion", vehiculos.TipoVehiculo);
            return View(vehiculos);
        }

        // POST: vehiculos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idVehiculos,Placa,Color,Modelo,Marca,TipoVehiculo")] vehiculos vehiculos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Color = new SelectList(db.colorvehiculo, "idColorVehiculo", "ColorVehiculo1", vehiculos.Color);
            ViewBag.Marca = new SelectList(db.marcasvehiculo, "idMarcasVehiculo", "MarcasVehiculo1", vehiculos.Marca);
            ViewBag.TipoVehiculo = new SelectList(db.tipovehiculo, "idTipoVehiculo", "Descripcion", vehiculos.TipoVehiculo);
            return View(vehiculos);
        }

        // GET: vehiculos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehiculos vehiculos = await db.vehiculos.FindAsync(id);
            if (vehiculos == null)
            {
                return HttpNotFound();
            }
            return View(vehiculos);
        }

        // POST: vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            vehiculos vehiculos = await db.vehiculos.FindAsync(id);
            db.vehiculos.Remove(vehiculos);
            await db.SaveChangesAsync();
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
