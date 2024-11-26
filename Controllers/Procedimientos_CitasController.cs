using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalMVC.Models;

namespace HospitalMVC.Controllers
{
    public class Procedimientos_CitasController : Controller
    {
        private HospitalEntities1 db = new HospitalEntities1();

        // GET: Procedimientos_Citas
        public ActionResult Index()
        {
            var procedimientos_Citas = db.Procedimientos_Citas.Include(p => p.Citas).Include(p => p.Procedimientos);
            return View(procedimientos_Citas.ToList());
        }

        // GET: Procedimientos_Citas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedimientos_Citas procedimientos_Citas = db.Procedimientos_Citas.Find(id);
            if (procedimientos_Citas == null)
            {
                return HttpNotFound();
            }
            return View(procedimientos_Citas);
        }

        // GET: Procedimientos_Citas/Create
        public ActionResult Create()
        {
            ViewBag.cita_ID = new SelectList(db.Citas, "ID_cita", "motivo");
            ViewBag.procedimiento_ID = new SelectList(db.Procedimientos, "ID_procedimiento", "nombre");
            return View();
        }

        // POST: Procedimientos_Citas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cita_ID,procedimiento_ID,fecha")] Procedimientos_Citas procedimientos_Citas)
        {
            if (ModelState.IsValid)
            {
                db.Procedimientos_Citas.Add(procedimientos_Citas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cita_ID = new SelectList(db.Citas, "ID_cita", "motivo", procedimientos_Citas.cita_ID);
            ViewBag.procedimiento_ID = new SelectList(db.Procedimientos, "ID_procedimiento", "nombre", procedimientos_Citas.procedimiento_ID);
            return View(procedimientos_Citas);
        }

        // GET: Procedimientos_Citas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedimientos_Citas procedimientos_Citas = db.Procedimientos_Citas.Find(id);
            if (procedimientos_Citas == null)
            {
                return HttpNotFound();
            }
            ViewBag.cita_ID = new SelectList(db.Citas, "ID_cita", "motivo", procedimientos_Citas.cita_ID);
            ViewBag.procedimiento_ID = new SelectList(db.Procedimientos, "ID_procedimiento", "nombre", procedimientos_Citas.procedimiento_ID);
            return View(procedimientos_Citas);
        }

        // POST: Procedimientos_Citas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cita_ID,procedimiento_ID,fecha")] Procedimientos_Citas procedimientos_Citas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(procedimientos_Citas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cita_ID = new SelectList(db.Citas, "ID_cita", "motivo", procedimientos_Citas.cita_ID);
            ViewBag.procedimiento_ID = new SelectList(db.Procedimientos, "ID_procedimiento", "nombre", procedimientos_Citas.procedimiento_ID);
            return View(procedimientos_Citas);
        }

        // GET: Procedimientos_Citas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedimientos_Citas procedimientos_Citas = db.Procedimientos_Citas.Find(id);
            if (procedimientos_Citas == null)
            {
                return HttpNotFound();
            }
            return View(procedimientos_Citas);
        }

        // POST: Procedimientos_Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Procedimientos_Citas procedimientos_Citas = db.Procedimientos_Citas.Find(id);
            db.Procedimientos_Citas.Remove(procedimientos_Citas);
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

        #region Sweet Alert

        private void SweetAlert(string title, string msg, NotificationType type)
        {
            var script = "<script languaje='javascript'> " +
                         "Swal.fire({" +
                         "title: '" + title + "'," +
                         "text: '" + msg + "'," +
                         "icon: '" + type + "'" +
                         "});" +
                         "</script>";

            //TempData funciona como un viewBag, pasando información del controlador a cualquier parte de mi proyecto, siendo este más observable y con un tiempo de vida similar
            TempData["sweetalert"] = script;
        }

        private void SweetAlert_Eliminar(int id)
        {
            var script = "<script languaje='javascript'>" +
                "Swal.fire({" +
                "title: '¿Estás Seguro?'," +
                "text: 'Estás apunto de Eliminar el Camión: " + id.ToString() + "'," +
                "icon: 'info'," +
                "showDenyButton: true," +
                "showCancelButton: true," +
                "confirmButtonText: 'Eliminar'," +
                "denyButtonText: 'Cancelar'" +
                "}).then((result) => {" +
                "if (result.isConfirmed) {  " +
                "window.location.href = '/Camiones/Eliminar_Camion/" + id + "';" +
                "} else if (result.isDenied) {  " +
                "Swal.fire('Se ha cancelado la operación','','info');" +
                "}" +
                "});" +
                "</script>";

            TempData["sweetalert"] = script;
        }
        #endregion
    }
}
