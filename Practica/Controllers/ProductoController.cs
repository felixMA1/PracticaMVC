using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica.Models;


namespace Practica.Controllers
{
    public class ProductoController : Controller
    {
        Tienda18Entities db = new Tienda18Entities();

        public ActionResult Index()
        {
            var data = db.Producto;
            return View(data);
        }

        public ActionResult Detalle(int id)
        {
            var data = db.Producto.Find(id);
            return View(data);
        }
        // GET: Producto
        public ActionResult Alta()
        {
            return View(new Producto());
        }

        [HttpPost]
        public ActionResult Alta(Producto model)
        {
            if (ModelState.IsValid)//Cumple todos los requisitos de validacion
            {
                db.Producto.Add(model);
                db.SaveChanges();
                return View(new Producto());
            }
            //Devuelve el formulario 
            return View(model);
        }
    }
}