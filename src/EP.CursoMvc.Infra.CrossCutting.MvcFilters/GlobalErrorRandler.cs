using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EP.CursoMvc.Infra.CrossCutting.MvcFilters
{
    public class GlobalErrorRandler : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                filterContext.Controller.TempData["ErrorCode"] = "0005";
            }
            base.OnActionExecuted(filterContext);
        }
    }
}
