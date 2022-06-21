using ECommerce.Infra.Context;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class SaleController : Controller
    {
        private SalesDbContext _salesDbContext { get; set; }
        public SaleController(SalesDbContext salesDbContext)
        {
            _salesDbContext = salesDbContext;
        }
        public IActionResult UpdateQuantity(int id, int quantity)
        {
            var sale = _salesDbContext.Sales.Find(id);
            if(sale == null)
                return NotFound();

            sale.ProductQuantity = quantity;
            _salesDbContext.SaveChanges();
            return RedirectToAction("Index", "ShopCart");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
