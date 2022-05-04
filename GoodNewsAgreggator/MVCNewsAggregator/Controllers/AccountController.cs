using Microsoft.AspNetCore.Mvc;

namespace MVCNewsAggregator.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
