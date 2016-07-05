using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CandidatosSistema.Models;

namespace CandidatosSistema.Controllers
{
    public class SueldoController : Controller
    {
        private SisCandidatosEntities db = new SisCandidatosEntities();

        // GET: Sueldo
        public ActionResult Index()
        {
            return View(db.Sueldo.ToList());
        }

        // GET: Sueldo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sueldo sueldo = db.Sueldo.Find(id);
            if (sueldo == null)
            {
                return HttpNotFound();
            }
            return View(sueldo);
        }

        // GET: Sueldo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sueldo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SueldoId,Clave,Descripcion,Estado,FechaCaptura")] Sueldo sueldo)
        {
            if (ModelState.IsValid)
            {
                db.Sueldo.Add(sueldo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sueldo);
        }

        // GET: Sueldo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sueldo sueldo = db.Sueldo.Find(id);
            if (sueldo == null)
            {
                return HttpNotFound();
            }
            return View(sueldo);
        }

        // POST: Sueldo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SueldoId,Clave,Descripcion,Estado,FechaCaptura")] Sueldo sueldo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sueldo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sueldo);
        }

        // GET: Sueldo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sueldo sueldo = db.Sueldo.Find(id);
            if (sueldo == null)
            {
                return HttpNotFound();
            }
            return View(sueldo);
        }

        // POST: Sueldo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sueldo sueldo = db.Sueldo.Find(id);
            db.Sueldo.Remove(sueldo);
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
