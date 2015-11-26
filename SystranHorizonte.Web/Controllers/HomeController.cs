using System.Web.Mvc;

namespace SystranHorizonte.Web.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return Redirect(@Url.Action("Login", "Account"));
        }
    }
}