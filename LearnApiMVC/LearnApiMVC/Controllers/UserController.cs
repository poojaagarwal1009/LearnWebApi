using LearnApiMVC.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace LearnApiMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.IsValid(user.EmailId, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.EmailId, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }
    }
}