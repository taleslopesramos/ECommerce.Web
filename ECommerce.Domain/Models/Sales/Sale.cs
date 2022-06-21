using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain.Models.Sales
{
    public class Sale : BaseEntity
    {
        public int ShopCartId { get; set; }
        public ShopCart ShopCart { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProductQuantity { get; set; } = 1;
        public Sale()
        {
            Product = new();
            ShopCart = new();
        }
        
        public decimal GetSaleDiscountPrice()
        {
            return Product.GetDiscountPrice(ProductQuantity);
        }
        public decimal GetSalePrice()
        {
            return Product.OriginalPrice * ProductQuantity;
        }
    }
}