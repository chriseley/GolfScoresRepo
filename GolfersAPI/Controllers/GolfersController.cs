using Microsoft.AspNetCore.Mvc;

namespace GolfersAPI.Controllers
{
    public class GolfersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
