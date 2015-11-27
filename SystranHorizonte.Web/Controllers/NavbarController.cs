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
            return PartialView("_Navbar", data.navbarItems().ToList());
        }
    }
}