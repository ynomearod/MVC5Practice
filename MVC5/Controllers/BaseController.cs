using MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Controllers
{
    public abstract class BaseController : Controller
    {
        protected FabricsEntities db = new FabricsEntities(); 
        protected ClientRepository reposClient = RepositoryHelper.GetClientRepository();
        protected ClientRepository reposOccupation = RepositoryHelper.GetClientRepository();

#if DEBUG
        public ActionResult Debug()
        {
            return View();
        }
#endif

    }
}