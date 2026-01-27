using Microsoft.AspNetCore.Mvc;

namespace Shop_pv412.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
