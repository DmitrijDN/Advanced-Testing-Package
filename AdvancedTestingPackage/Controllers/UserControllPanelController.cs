using System.Web.Mvc;
using AdvancedTestingPackage.Infrastructure;

namespace AdvancedTestingPackage.Controllers
{
    public class UserControllPanelController : Controller
    {
        //
        // GET: /UserControllPanel/
        public ActionResult Index()
        {
            if (!Request.IsAuthenticated || UserIdentity.Current.UserCredential.Role != "Teacher")
            {
                RedirectToAction("Index", "Home");
            }
            return View();
        }
	}
}