using ECommerce.Infra.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Web.Controllers
{
    public class ShopCartController : Controller
    {
        private SalesDbContext _salesDbContext { get; set; }
        public ShopCartController(SalesDbContext salesDbContext)
        {
            _salesDbContext = salesDbContext;
        }
        public IActionResult Add(int id)
        {
            var shopCart = _salesDbContext
                .ShopCarts
                .FirstOrDefault(sc => sc.Id == 1);
            
            var product = _salesDbContext.Products.Find(id);
            if (product == null || shopCart == null)
                return NotFound();

            shopCart.AddProduct(product);
            _salesDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var shopCart = _salesDbContext
                .ShopCarts
                .Include(sc => sc.Sales)
                .ThenInclude(s => s.Product)
                .ThenInclude(p => p.Promotion)
                .FirstOrDefault(sc => sc.Id == 1);
            
            if (shopCart == null)
                return NotFound();

            shopCart.SetTotalPrice();
            
            return View(shopCart);
        }
    }
}
