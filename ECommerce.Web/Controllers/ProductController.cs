using ECommerce.Domain.Models.Sales;
using ECommerce.Domain.Models.Sales.Enums;
using ECommerce.Infra.Context;
using ECommerce.Web.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var products = _salesDbContext.Products
                .Include(p => p.Promotion)
                .Where(p => id != null? p.Id == id : true)
                .ToList();

            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product, [Bind("PromoType")] PromotionType? PromoType, [Bind("FormatedPrice")] string FormatedPrice)
        {
            product.Promotion = Promotion.CreateByType(PromoType);

            _salesDbContext.Products.Add(product);
            _salesDbContext.SaveChanges();

            if (PromoType == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction(PromotionUtils.PromoEditRedirectName((PromotionType)PromoType),
                                        "Promotion", 
                                        new { id = product.Promotion?.Id });
            }
        }

        public IActionResult Update(int id)
        {
            var product = _salesDbContext
                .Products
                .Include(p => p.Promotion)
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _salesDbContext.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            var productEntity = _salesDbContext.Products.Find(product.Id);
            if(productEntity == null)
            {
                return NotFound();
            }

            _salesDbContext.Products.Remove(productEntity);
            _salesDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
