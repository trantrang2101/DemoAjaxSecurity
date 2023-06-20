using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class UserController : Controller
    {
        public UserController()
        {
        }
        public IActionResult List()
        {
            return View();
        }
    }
}
