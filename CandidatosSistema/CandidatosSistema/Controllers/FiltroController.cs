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
    public class FiltroController : Controller
    {
        private SisCandidatosEntities db = new SisCandidatosEntities();

        // GET: Filtro
        public ActionResult Index()
        {
            var candidato = db.Candidato.Include(c => c.Escolaridad).Include(c => c.Localidad).Include(c => c.Sueldo).Include(c => c.Especialidad);
            ViewBag.CarpetaArchivos = string.Format("../{0}", Properties.Settings.Default.CarpetaArchivos);
            return View(candidato.ToList());
        }

        // GET: Filtro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidato candidato = db.Candidato.Find(id);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarpetaArchivos = string.Format("../{0}", Properties.Settings.Default.CarpetaArchivos);
            return View(candidato);
        }

        // GET: Filtro/Create
        public ActionResult Create()
        {
            ViewBag.EscolaridadId = new SelectList(db.Escolaridad, "EscolaridadId", "Clave");
            ViewBag.LocalidadId = new SelectList(db.Localidad, "LocalidadId", "Clave");
            ViewBag.SueldoId = new SelectList(db.Sueldo, "SueldoId", "Clave");
            ViewBag.EspecialidadId = new SelectList(db.Especialidad, "EspecialidadId", "Calve");
            return View();
        }

        // POST: Filtro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CandidatoId,Nombre,Telefono,Correo,LocalidadId,SueldoId,EscolaridadId,EspecialidadId,EstadoCandidato,Capturista,FechaCaptura,Archivo")] Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                db.Candidato.Add(candidato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EscolaridadId = new SelectList(db.Escolaridad, "EscolaridadId", "Clave", candidato.EscolaridadId);
            ViewBag.LocalidadId = new SelectList(db.Localidad, "LocalidadId", "Clave", candidato.LocalidadId);
            ViewBag.SueldoId = new SelectList(db.Sueldo, "SueldoId", "Clave", candidato.SueldoId);
            ViewBag.EspecialidadId = new SelectList(db.Especialidad, "EspecialidadId", "Calve", candidato.EspecialidadId);
            return View(candidato);
        }

        // GET: Filtro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidato candidato = db.Candidato.Find(id);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            ViewBag.EscolaridadId = new SelectList(db.Escolaridad, "EscolaridadId", "Clave", candidato.EscolaridadId);
            ViewBag.LocalidadId = new SelectList(db.Localidad, "LocalidadId", "Clave", candidato.LocalidadId);
            ViewBag.SueldoId = new SelectList(db.Sueldo, "SueldoId", "Clave", candidato.SueldoId);
            ViewBag.EspecialidadId = new SelectList(db.Especialidad, "EspecialidadId", "Calve", candidato.EspecialidadId);
            return View(candidato);
        }

        // POST: Filtro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CandidatoId,Nombre,Telefono,Correo,LocalidadId,SueldoId,EscolaridadId,EspecialidadId,EstadoCandidato,Capturista,FechaCaptura,Archivo")] Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EscolaridadId = new SelectList(db.Escolaridad, "EscolaridadId", "Clave", candidato.EscolaridadId);
            ViewBag.LocalidadId = new SelectList(db.Localidad, "LocalidadId", "Clave", candidato.LocalidadId);
            ViewBag.SueldoId = new SelectList(db.Sueldo, "SueldoId", "Clave", candidato.SueldoId);
            ViewBag.EspecialidadId = new SelectList(db.Especialidad, "EspecialidadId", "Calve", candidato.EspecialidadId);
            return View(candidato);
        }

        // GET: Filtro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidato candidato = db.Candidato.Find(id);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            return View(candidato);
        }

        // POST: Filtro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidato candidato = db.Candidato.Find(id);
            db.Candidato.Remove(candidato);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Este es el metodo para la consulta

        public ActionResult Busquedafilter(string Nombre)
        {
            var Candidato = from s in db.Candidato select s;

            if (!string.IsNullOrEmpty(Nombre))
            {
                Candidato = Candidato.Where(x => x.Nombre.Contains(Nombre));
            }
            ViewBag.CarpetaArchivos = string.Format("../{0}", Properties.Settings.Default.CarpetaArchivos);
            return View(Candidato);

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
