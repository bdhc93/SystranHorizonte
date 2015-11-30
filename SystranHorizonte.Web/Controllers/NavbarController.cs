using System.Linq;
using System.Web.Mvc;
using SystranHorizonte.Web.Domain;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;

namespace SystranHorizonte.Web.Controllers
{
    public class NavbarController : Controller
    {
        public IMovCuentaService movCuentaService { get; set; }

        public NavbarController(IMovCuentaService movCuentaService)
        {
            this.movCuentaService = movCuentaService;
        }

        public ActionResult Index()
        {
            ViewBag.Movimientos = movCuentaService.ObtenerMovimientosPorUsuario(User.Identity.Name);

            var data = new Data();
            if (User.IsInRole("SuperAdmin"))
            {
                return PartialView("_Navbar", data.navbarItems().ToList());
            }
            else if (User.IsInRole("Admin"))
            {
                return PartialView("_Navbar", data.navbarItemsadmin().ToList());
            }
            else if (User.IsInRole("Vendedor"))
            {
                return PartialView("_Navbar", data.navbarItemsvendedor().ToList());
            }
            else
            {
                return PartialView("_Navbar", data.navbarItemspublic().ToList());
            }
        }
    }
}