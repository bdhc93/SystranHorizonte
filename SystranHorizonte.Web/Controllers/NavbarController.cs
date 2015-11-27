using System.Linq;
using System.Web.Mvc;
using SystranHorizonte.Web.Domain;

namespace SystranHorizonte.Web.Controllers
{
    public class NavbarController : Controller
    {
        public ActionResult Index()
        {
            var data = new Data();
            if (User.IsInRole("SuperAdmin"))
            {
                return PartialView("_Navbar", data.navbarItems().ToList());
            }
            else if (User.IsInRole("Admin"))
            {
                return PartialView("_Navbar", data.navbarItems().ToList());
            }
            else if (User.IsInRole("Vendedor"))
            {
                return PartialView("_Navbar", data.navbarItems().ToList());
            }
            else
            {
                return PartialView("_Navbar", data.navbarItemspublic().ToList());
            }
        }
    }
}