using Microsoft.AspNetCore.Mvc;
using Shop_pv412.Services;

namespace Shop_pv412.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IServiceProduct _serviceProduct;

        public ProductsController(IServiceProduct serviceProduct)
        {
            _serviceProduct = serviceProduct;
        }
        //http://localhost:[port]/products/readproducts
        //HTTP GET
        [HttpGet]
        public async Task<IActionResult> ReadProducts()
        {
            var products = await _serviceProduct.GetAllAsync();
            return View(products);
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(
            [Bind("Name,Price,Description")] Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                await _serviceProduct.CreateAsync(product);
                return RedirectToAction("ReadProducts", "Products");
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await _serviceProduct.GetByIdAsync(id);
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(
            int id,
            [Bind("Id,Name,Price,Description")] Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                product.Id = id;
                await _serviceProduct.UpdateAsync(product);
                return RedirectToAction("ReadProducts", "Products");
            }
        }
        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _serviceProduct.GetByIdAsync(id);
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProductConfirmed(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            else
            {
                await _serviceProduct.DeleteAsync(id);
                return RedirectToAction("ReadProducts", "Products");
            }
        }
    }
}
