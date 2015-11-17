using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Practica.Filtros
{
    public class FiltroHora:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            DateTime dt = DateTime.Now;
            var m = dt.Minute;

            if(m < 10 || m > 22)
                filterContext.Result = new HttpUnauthorizedResult("Servicio no disponible en este momento");
            
            base.OnActionExecuting(filterContext);
        }
    }
}
