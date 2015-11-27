using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystranHorizonte.Models;

namespace SystranHorizonte.Web.Controllers
{
    public class CuentaController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Account cuenta)
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Registrar(Account cuenta)
        {
            return View();
        }
    }
}