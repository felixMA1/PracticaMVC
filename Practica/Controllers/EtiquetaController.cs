using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica.Filtros;
using Practica.Models;

namespace Practica.Controllers
{
    public class EtiquetaController : Controller
    {
        Tienda18Entities db = new Tienda18Entities();

        // GET: Etiqueta
        [FiltroHora]
        public ActionResult Index()
        {
            ViewData["TituloEtiqueta"] = "Lista de etiquetas";
            ViewData["TituloAlmacen"] = "Lista de almacenes";
            ViewBag.almacenes = db.Almacen.ToList();
            var data = db.Etiqueta;
            return View(data.ToList());
        }
    }
}