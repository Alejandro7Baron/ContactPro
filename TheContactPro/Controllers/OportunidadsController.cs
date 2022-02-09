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
    public class OportunidadsController : Controller
    {
        private ContactProEntities db = new ContactProEntities();

        // GET: Oportunidads
        public ActionResult Index()
        {
            var oportunidad = db.Oportunidad.Include(o => o.Cuenta);
            return View(oportunidad.ToList());
        }

        // GET: Oportunidads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oportunidad oportunidad = db.Oportunidad.Find(id);
            if (oportunidad == null)
            {
                return HttpNotFound();
            }
            return View(oportunidad);
        }

        // GET: Oportunidads/Create
        public ActionResult Create()
        {
            ViewBag.CuentaId = new SelectList(db.Cuenta, "CuentaId", "Nombre");
            return View();
        }

        // POST: Oportunidads/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OportunidadId,CuentaId,Nombre,Descripcion")] Oportunidad oportunidad)
        {
            if (ModelState.IsValid)
            {
                db.Oportunidad.Add(oportunidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CuentaId = new SelectList(db.Cuenta, "CuentaId", "Nombre", oportunidad.CuentaId);
            return View(oportunidad);
        }

        // GET: Oportunidads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oportunidad oportunidad = db.Oportunidad.Find(id);
            if (oportunidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.CuentaId = new SelectList(db.Cuenta, "CuentaId", "Nombre", oportunidad.CuentaId);
            return View(oportunidad);
        }

        // POST: Oportunidads/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OportunidadId,CuentaId,Nombre,Descripcion")] Oportunidad oportunidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oportunidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CuentaId = new SelectList(db.Cuenta, "CuentaId", "Nombre", oportunidad.CuentaId);
            return View(oportunidad);
        }

        // GET: Oportunidads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oportunidad oportunidad = db.Oportunidad.Find(id);
            if (oportunidad == null)
            {
                return HttpNotFound();
            }
            return View(oportunidad);
        }

        // POST: Oportunidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oportunidad oportunidad = db.Oportunidad.Find(id);
            db.Oportunidad.Remove(oportunidad);
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
