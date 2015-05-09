using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.App_ActionFilter
{
    public class ViewBagFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.Message = "!!!Your application description page.";
            base.OnActionExecuted(filterContext);
        }
    }
}