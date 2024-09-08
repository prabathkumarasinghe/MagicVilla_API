using Microsoft.AspNetCore.Mvc;

namespace MagicVilla.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
