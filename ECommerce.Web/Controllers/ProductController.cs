using ECommerce.Domain.Models.Sales;
using ECommerce.Infra.Context;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class ProductController : Controller
    {
        private SalesDbContext _salesDbContext { get; set; }
        public ProductController(SalesDbContext salesDbContext)
        {
            _salesDbContext = salesDbContext;
        }

        public IActionResult Index(int? id)
        {
            var products = _salesDbContext.Products.ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {

            _salesDbContext.Products.Add(product);
            _salesDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
