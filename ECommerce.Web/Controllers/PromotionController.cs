using ECommerce.Domain.Models.Sales;
using ECommerce.Domain.Models.Sales.Enums;
using ECommerce.Infra.Context;
using ECommerce.Web.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Web.Controllers
{
    public class PromotionController : Controller
    {
        private SalesDbContext _salesDbContext { get; set; }
        public PromotionController(SalesDbContext salesDbContext)
        {
            _salesDbContext = salesDbContext;
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            return View(id);
        }
        [HttpPost]
        public IActionResult Create(int ProductId, PromotionType PromoType)
        {
            var product = _salesDbContext.Products.Find(ProductId);
            if (product == null)
                return NotFound();

            var promotion = Promotion.CreateByType(PromoType);
            if (promotion == null)
                return BadRequest();

            promotion.Product = product;
            promotion.ProductId = ProductId;

            _salesDbContext.Promotions.Add(promotion);
            _salesDbContext.SaveChanges();
            return RedirectToAction(PromotionUtils.PromoEditRedirectName(PromoType), promotion);
        }
        [HttpGet]
        public IActionResult DeleteConfirmation(int id)
        {
            var promotion = _salesDbContext.Promotions
                .Include(p => p.Product)
                .FirstOrDefault(p => p.Id == id);
            
            if (promotion == null) return NotFound();

            return View(promotion);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var promoEntity = _salesDbContext.Promotions
                .FirstOrDefault(p => p.Id == id);

            if (promoEntity == null)
                return NotFound();
            

            _salesDbContext.Promotions.Remove(promoEntity);
            _salesDbContext.SaveChanges();

            return RedirectToAction("Index", "Product");
        }
        public IActionResult EditFixedValuePromo(int id)
        {
            var fixedValuePromo = _salesDbContext
                .Promotions
                .Include(p => p.Product)
                .FirstOrDefault(p => p.Id == id);

            if (fixedValuePromo == null)
            {
                return NotFound();
            }

            fixedValuePromo.Description =
                fixedValuePromo.Description == null ? "" : fixedValuePromo.Description;

            return View(fixedValuePromo);
        }

        [HttpPost]
        public IActionResult EditFixedValuePromo(FixedValuePromotion promo)
        {
            _salesDbContext.Entry(promo).State = EntityState.Modified;
            _salesDbContext.SaveChanges();

            return RedirectToAction("Index", "Product");
        }

        public IActionResult EditPercentageValuePromo(int id)
        {
            var percentageValuePromo = _salesDbContext
                .Promotions
                .Include(p => p.Product)
                .FirstOrDefault(p => p.Id == id);

            if (percentageValuePromo == null)
            {
                return NotFound();
            }

            percentageValuePromo.Description =
                percentageValuePromo.Description == null ? "" : percentageValuePromo.Description;

            return View(percentageValuePromo);
        }

        public IActionResult EditFreeItemPromo(int id)
        {
            var percentageValuePromo = _salesDbContext
                .Promotions
                .Include(p => p.Product)
                .FirstOrDefault(p => p.Id == id);

            if (percentageValuePromo == null)
            {
                return NotFound();
            }

            percentageValuePromo.Description =
                percentageValuePromo.Description == null ? "" : percentageValuePromo.Description;

            return View(percentageValuePromo);
        }

        [HttpPost]
        public IActionResult EditFreeItemPromo(FreeItemPromotion promo)
        {
            _salesDbContext.Entry(promo).State = EntityState.Modified;
            _salesDbContext.SaveChanges();

            return RedirectToAction("Index", "Product");
        }
    }
}
