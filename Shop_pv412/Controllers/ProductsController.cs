using Microsoft.AspNetCore.Mvc;
using Shop_pv412.Services;

namespace Shop_pv412.Controllers
{
    public  class ProductsController : Controller
    {
        private readonly IServiceProduct _serviceProduct;
        public ProductsController(IServiceProduct serviceProduct)
        {
            _serviceProduct = serviceProduct;
        }
        [HttpGet]
        public  async Task<IActionResult> ReadProducts()
        {
            //Get products from database
            return View(/*products*/);
        }
        [HttpGet]
        public IActionResult CreateProduct() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct([Bind("Name,Price,Description")]Product product)
        {
            if (!ModelState.IsValid)
            {
                //add product to database
            }
            else
            {
                //return error 
            }
            return RedirectToAction("ReadProducts","Products");

        }

    }
}
