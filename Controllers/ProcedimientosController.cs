using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalMVC.Models;
using static HospitalMVC.Models.Enum;

namespace HospitalMVC.Controllers
{
    public class ProcedimientosController : Controller
    {
        private HospitalEntities1 db = new HospitalEntities1();

        // GET: Procedimientos
        public ActionResult Index()
        {
            return View(db.Procedimientos.ToList());
        }

        // GET: Procedimientos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedimientos procedimientos = db.Procedimientos.Find(id);
            if (procedimientos == null)
            {
                return HttpNotFound();
            }
            return View(procedimientos);
        }

        // GET: Procedimientos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Procedimientos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_procedimiento,nombre,descripcion,costo")] Procedimientos procedimientos)
        {
            if (ModelState.IsValid)
            {
                db.Procedimientos.Add(procedimientos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(procedimientos);
        }

        // GET: Procedimientos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedimientos procedimientos = db.Procedimientos.Find(id);
            if (procedimientos == null)
            {
                return HttpNotFound();
            }
            return View(procedimientos);
        }

        // POST: Procedimientos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_procedimiento,nombre,descripcion,costo")] Procedimientos procedimientos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(procedimientos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(procedimientos);
        }

        // GET: Procedimientos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedimientos procedimientos = db.Procedimientos.Find(id);
            if (procedimientos == null)
            {
                return HttpNotFound();
            }
            return View(procedimientos);
        }

        // POST: Procedimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Procedimientos procedimientos = db.Procedimientos.Find(id);
            db.Procedimientos.Remove(procedimientos);
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
