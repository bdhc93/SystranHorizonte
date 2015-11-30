using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SystranHorizonte.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            var res = "Para acceder a esta página se necesita tener los respectivos permisos.";
            return RedirectToAction("Index", "Home", new { error = res });
        }
    }
}