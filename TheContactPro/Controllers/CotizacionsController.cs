using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheContactPro;

namespace TheContactPro.Controllers
{
    public class CotizacionsController : Controller
    {
        private ContactProEntities db = new ContactProEntities();

        // GET: Cotizacions
        public ActionResult Index()
        {
            var cotizacion = db.Cotizacion.Include(c => c.Cuenta).Include(c => c.Oportunidad);
            return View(cotizacion.ToList());
        }

        // GET: Cotizacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizacion cotizacion = db.Cotizacion.Find(id);
            if (cotizacion == null)
            {
                return HttpNotFound();
            }
            return View(cotizacion);
        }

        // GET: Cotizacions/Create
        public ActionResult Create()
        {
            ViewBag.CuentaId = new SelectList(db.Cuenta, "CuentaId", "Nombre");
            ViewBag.OportunidadId = new SelectList(db.Oportunidad, "OportunidadId", "Nombre");
            return View();
        }

        // POST: Cotizacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CotizacionId,Nombre,CuentaId,Descripcion,Total,OportunidadId")] Cotizacion cotizacion)
        {
            if (ModelState.IsValid)
            {
                db.Cotizacion.Add(cotizacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CuentaId = new SelectList(db.Cuenta, "CuentaId", "Nombre", cotizacion.CuentaId);
            ViewBag.OportunidadId = new SelectList(db.Oportunidad, "OportunidadId", "Nombre", cotizacion.OportunidadId);
            return View(cotizacion);
        }

        // GET: Cotizacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizacion cotizacion = db.Cotizacion.Find(id);
            if (cotizacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CuentaId = new SelectList(db.Cuenta, "CuentaId", "Nombre", cotizacion.CuentaId);
            ViewBag.OportunidadId = new SelectList(db.Oportunidad, "OportunidadId", "Nombre", cotizacion.OportunidadId);
            return View(cotizacion);
        }

        // POST: Cotizacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CotizacionId,Nombre,CuentaId,Descripcion,Total,OportunidadId")] Cotizacion cotizacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotizacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CuentaId = new SelectList(db.Cuenta, "CuentaId", "Nombre", cotizacion.CuentaId);
            ViewBag.OportunidadId = new SelectList(db.Oportunidad, "OportunidadId", "Nombre", cotizacion.OportunidadId);
            return View(cotizacion);
        }

        // GET: Cotizacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizacion cotizacion = db.Cotizacion.Find(id);
            if (cotizacion == null)
            {
                return HttpNotFound();
            }
            return View(cotizacion);
        }

        // POST: Cotizacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cotizacion cotizacion = db.Cotizacion.Find(id);
            db.Cotizacion.Remove(cotizacion);
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
