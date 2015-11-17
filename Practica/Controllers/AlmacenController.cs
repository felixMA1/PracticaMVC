using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica.Filtros;
using Practica.Models;

namespace Practica.Controllers
{
    public class AlmacenController : Controller
    {
        Tienda18Entities db = new Tienda18Entities();

        // GET: Almacen
        public ActionResult Index()
        {
            var info = db.Etiqueta;
            ViewBag.etiquetas = info.ToList();

            ViewData["Titulo"] = "Listado de almacenes";

            var data = db.Almacen;

            return View(data.ToList());
        }


        public ActionResult Alta()
        {
            return View(new Almacen());
        }

        [HttpPost]
        public ActionResult Alta(Almacen model)
        {
            if (ModelState.IsValid)//Cumple todos los requisitos de validacion
            {
                db.Almacen.Add(model);
                db.SaveChanges();
                return View(new Almacen());
            }
            //Devuelve el formulario 
            return View(model);
        }

        [FiltroId]
        public ActionResult Modificar(int id)
        {
            var data = db.Almacen.Find(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Modificar(Almacen model)
        {
            if (ModelState.IsValid)//Cumple todos los requisitos de validacion
            {
                //db.Entry(model).State = EntityState.Modified; (otra opcion)

                var data = db.Almacen.FirstOrDefault(o => o.idAlmacen == model.idAlmacen);
                data.ciudad = model.ciudad;
                data.cp = model.cp;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [FiltroId]
        public ActionResult Borrar(int id)
        {
            var data = db.Almacen.Find(id);

            if(data.ProductoAlmacen.Any())
            db.ProductoAlmacen.RemoveRange(data.ProductoAlmacen);

            db.Almacen.Remove(data);

            db.SaveChanges();
            return RedirectToAction("Index");
        }






    }
}