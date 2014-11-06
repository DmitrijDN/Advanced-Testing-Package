using System.Web.Mvc;
using AdvancedTestingPackage.Infrastructure;

namespace AdvancedTestingPackage.Controllers
{
    public class AdminControllPanelController : Controller
    {
        //
        // GET: /AdminControllPanel/
        public ActionResult Index()
        {
            if (!Request.IsAuthenticated || UserIdentity.Current.UserCredential.Role != "Admin")
            {
                RedirectToAction("Index", "Home");
            }
            return View();
        }
	}
}