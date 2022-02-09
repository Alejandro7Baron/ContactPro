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
    public class ElementoDeCotizacionsController : Controller
    {
        private ContactProEntities db = new ContactProEntities();

        // GET: ElementoDeCotizacions
        public ActionResult Index()
        {
            var elementoDeCotizacion = db.ElementoDeCotizacion.Include(e => e.Cotizacion).Include(e => e.Producto);
            return View(elementoDeCotizacion.ToList());
        }

        // GET: ElementoDeCotizacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElementoDeCotizacion elementoDeCotizacion = db.ElementoDeCotizacion.Find(id);
            if (elementoDeCotizacion == null)
            {
                return HttpNotFound();
            }
            return View(elementoDeCotizacion);
        }

        // GET: ElementoDeCotizacions/Create
        public ActionResult Create()
        {
            ViewBag.CotizacionId = new SelectList(db.Cotizacion, "CotizacionId", "Nombre");
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "Nombre");
            return View();
        }

        // POST: ElementoDeCotizacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ElementoDeCotizacionId,ProductoId,Cantidad,PrecioDeVenta,Subtotal,PrecioTotal,CotizacionId")] ElementoDeCotizacion elementoDeCotizacion)
        {
            if (ModelState.IsValid)
            {
                db.ElementoDeCotizacion.Add(elementoDeCotizacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CotizacionId = new SelectList(db.Cotizacion, "CotizacionId", "Nombre", elementoDeCotizacion.CotizacionId);
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "Nombre", elementoDeCotizacion.ProductoId);
            return View(elementoDeCotizacion);
        }

        // GET: ElementoDeCotizacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElementoDeCotizacion elementoDeCotizacion = db.ElementoDeCotizacion.Find(id);
            if (elementoDeCotizacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CotizacionId = new SelectList(db.Cotizacion, "CotizacionId", "Nombre", elementoDeCotizacion.CotizacionId);
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "Nombre", elementoDeCotizacion.ProductoId);
            return View(elementoDeCotizacion);
        }

        // POST: ElementoDeCotizacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ElementoDeCotizacionId,ProductoId,Cantidad,PrecioDeVenta,Subtotal,PrecioTotal,CotizacionId")] ElementoDeCotizacion elementoDeCotizacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(elementoDeCotizacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CotizacionId = new SelectList(db.Cotizacion, "CotizacionId", "Nombre", elementoDeCotizacion.CotizacionId);
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "Nombre", elementoDeCotizacion.ProductoId);
            return View(elementoDeCotizacion);
        }

        // GET: ElementoDeCotizacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElementoDeCotizacion elementoDeCotizacion = db.ElementoDeCotizacion.Find(id);
            if (elementoDeCotizacion == null)
            {
                return HttpNotFound();
            }
            return View(elementoDeCotizacion);
        }

        // POST: ElementoDeCotizacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ElementoDeCotizacion elementoDeCotizacion = db.ElementoDeCotizacion.Find(id);
            db.ElementoDeCotizacion.Remove(elementoDeCotizacion);
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
