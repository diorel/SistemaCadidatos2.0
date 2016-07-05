using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CandidatosSistema.Models;
using System.IO;

namespace CandidatosSistema.Controllers
{
    public class CandidatoController : Controller
    {
        private SisCandidatosEntities db = new SisCandidatosEntities();

        // GET: Candidato
        public ActionResult Index()
        {
            var candidato = db.Candidato.Include(c => c.Escolaridad).Include(c => c.Especialidad).Include(c => c.Localidad).Include(c => c.Sueldo);
            ViewBag.CarpetaArchivos = string.Format("../{0}", Properties.Settings.Default.CarpetaArchivos);
            return View(candidato.ToList());
        }

        // GET: Candidato/Details/5
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

        // GET: Candidato/Create
        public ActionResult Create()
        {
            ViewBag.EscolaridadId = new SelectList(db.Escolaridad, "EscolaridadId", "Clave");
            ViewBag.EspecialidadId = new SelectList(db.Especialidad, "EspecialidadId", "Calve");
            ViewBag.LocalidadId = new SelectList(db.Localidad, "LocalidadId", "Clave");
            ViewBag.SueldoId = new SelectList(db.Sueldo, "SueldoId", "Clave");
            return View();
        }

        // POST: Candidato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "CandisatoId,Nombre,Telefono,Correo,LocalidadId,SueldoId,EscolaridadId,EspecialidadId,EstadoCandidato,Capturista,FechaCaptura,Archivo")] Candidato candidato,
            HttpPostedFileBase Archivo)
        {
            if (ModelState.IsValid)
            {
                candidato.Archivo = null;
                if (Archivo != null && Archivo.ContentLength > 0)  //en esta parte validamos que existe un archivo y que su tamaño del archivo tiene que set mayor  a 0
                {
                    var fileName = Guid.NewGuid().ToString();
                    fileName += Path.GetExtension(Archivo.FileName);

                    var route = Server.MapPath(Properties.Settings.Default.CarpetaArchivos);

                    route = Path.Combine(route, fileName);

                    Archivo.SaveAs(route);
                    candidato.Archivo = fileName;
                }

                db.Candidato.Add(candidato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EscolaridadId = new SelectList(db.Escolaridad, "EscolaridadId", "Clave", candidato.EscolaridadId);
            ViewBag.EspecialidadId = new SelectList(db.Especialidad, "EspecialidadId", "Calve", candidato.EspecialidadId);
            ViewBag.LocalidadId = new SelectList(db.Localidad, "LocalidadId", "Clave", candidato.LocalidadId);
            ViewBag.SueldoId = new SelectList(db.Sueldo, "SueldoId", "Clave", candidato.SueldoId);
            return View(candidato);
        }

        // GET: Candidato/Edit/5
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
            ViewBag.EspecialidadId = new SelectList(db.Especialidad, "EspecialidadId", "Calve", candidato.EspecialidadId);
            ViewBag.LocalidadId = new SelectList(db.Localidad, "LocalidadId", "Clave", candidato.LocalidadId);
            ViewBag.SueldoId = new SelectList(db.Sueldo, "SueldoId", "Clave", candidato.SueldoId);
            return View(candidato);
        }

        // POST: Candidato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "CandidatoId,Nombre,Telefono,Correo,LocalidadId,SueldoId,EscolaridadId,EspecialidadId,EstadoCandidato,Capturista,FechaCaptura,Archivo")] Candidato candidato,
            HttpPostedFileBase NuevoArchivo)
        {
            if (ModelState.IsValid)
            {
                if (NuevoArchivo != null && NuevoArchivo.ContentLength > 0)  //en esta parte validamos que existe un archivo y que su tamaño del archivo tiene que set mayor  a 0
                {
                    var fileName = Guid.NewGuid().ToString();
                    fileName += Path.GetExtension(NuevoArchivo.FileName);

                    var route = Server.MapPath(Properties.Settings.Default.CarpetaArchivos);

                    route = Path.Combine(route, fileName);

                    NuevoArchivo.SaveAs(route);
                    candidato.Archivo = fileName;
                }

                db.Candidato.Attach(candidato);
                db.Entry<Candidato>(candidato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EscolaridadId = new SelectList(db.Escolaridad, "EscolaridadId", "Clave", candidato.EscolaridadId);
            ViewBag.EspecialidadId = new SelectList(db.Especialidad, "EspecialidadId", "Calve", candidato.EspecialidadId);
            ViewBag.LocalidadId = new SelectList(db.Localidad, "LocalidadId", "Clave", candidato.LocalidadId);
            ViewBag.SueldoId = new SelectList(db.Sueldo, "SueldoId", "Clave", candidato.SueldoId);
            return View(candidato);
        }

        // GET: Candidato/Delete/5
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

        // POST: Candidato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidato candidato = db.Candidato.Find(id);
            db.Candidato.Remove(candidato);
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
