using System;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;
using System.Web.Mvc;
using WebMatrix.WebData;
using SystranHorizonte.Web.Models;
using System.Web.Security;

namespace SystranHorizonte.Web.Controllers
{
    public class CuentasController : Controller
    {
        public IMovCuentaService movCuentaService { get; set; }

        public CuentasController(IMovCuentaService movCuentaService)
        {
            this.movCuentaService = movCuentaService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login logindata, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                if (WebSecurity.Login(logindata.Usuario, logindata.Contrasenia))
                {
                    if (ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    var res = "Usuario o contraseña incorrectos";
                    return RedirectToAction("Index", "Home", new { error = res });
                }


            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Register(RegistroUsuarios registrardata, string role)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(registrardata.Usuario, registrardata.Contrasenia);
                    Roles.AddUserToRole(registrardata.Usuario, role);

                    RegUsuarios movimiento = new RegUsuarios
                    {
                        Usuario = User.Identity.Name,
                        Modulo = "Usuario",
                        Cambio = "Nuevo Usuario",
                        IdModulo = registrardata.Usuario,
                        Fecha = DateTime.Now
                    };

                    movCuentaService.GuardarMovimiento(movimiento);

                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", "Error Usuario Registrado");
                    return View(registrardata);
                }
            }
            ModelState.AddModelError("", "No se puede registrar el usuario");
            return View(registrardata);
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult CambiarContrasenia(String oldpass, String newpass)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var u = Membership.GetUser(User.Identity.Name);
                    var a = WebSecurity.ChangePassword(User.Identity.Name, oldpass, newpass);
                    if (a)
                    {
                        var res = "Contraseña cambiada correctamente";
                        
                        RegUsuarios movimiento = new RegUsuarios
                        {
                            Usuario = User.Identity.Name,
                            Modulo = "Usuario",
                            Cambio = "CambioContraseña",
                            IdModulo = User.Identity.Name,
                            Fecha = DateTime.Now
                        };

                        movCuentaService.GuardarMovimiento(movimiento);

                        return RedirectToAction("Index", "Home", new { error = res });
                    }
                    else
                    {
                        var res = "Contraseña erronea";
                        return RedirectToAction("Index", "Home", new { error = res });
                        //return PartialView();
                    }
                }
                catch (Exception e)
                {
                    var res = "Error: " + e.Message +"";
                    return RedirectToAction("Index", "Home", new { error = res });
                }
            }
            return RedirectToAction("Index", "Home");
        }
        
    }
}