﻿using System;
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
    public class DoctoresController : Controller
    {
        private HospitalEntities1 db = new HospitalEntities1();

        // GET: Doctores
        public ActionResult Index()
        {
            var doctores = db.Doctores.Include(d => d.Especialidades);
            return View(doctores.ToList());
        }

        // GET: Doctores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctores doctores = db.Doctores.Find(id);
            if (doctores == null)
            {
                return HttpNotFound();
            }
            return View(doctores);
        }

        // GET: Doctores/Create
        public ActionResult Create()
        {
            ViewBag.especialidad_ID = new SelectList(db.Especialidades, "ID_especialidad", "nombre");
            return View();
        }

        // POST: Doctores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_doctor,nombre,telefono,especialidad_ID")] Doctores doctores)
        {
            if (ModelState.IsValid)
            {
                db.Doctores.Add(doctores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.especialidad_ID = new SelectList(db.Especialidades, "ID_especialidad", "nombre", doctores.especialidad_ID);
            return View(doctores);
        }

        // GET: Doctores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctores doctores = db.Doctores.Find(id);
            if (doctores == null)
            {
                return HttpNotFound();
            }
            ViewBag.especialidad_ID = new SelectList(db.Especialidades, "ID_especialidad", "nombre", doctores.especialidad_ID);
            return View(doctores);
        }

        // POST: Doctores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_doctor,nombre,telefono,especialidad_ID")] Doctores doctores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.especialidad_ID = new SelectList(db.Especialidades, "ID_especialidad", "nombre", doctores.especialidad_ID);
            return View(doctores);
        }

        // GET: Doctores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctores doctores = db.Doctores.Find(id);
            if (doctores == null)
            {
                return HttpNotFound();
            }
            return View(doctores);
        }

        // POST: Doctores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctores doctores = db.Doctores.Find(id);
            db.Doctores.Remove(doctores);
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
