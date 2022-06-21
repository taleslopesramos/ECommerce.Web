using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models.Sales
{
    public class ShopCart : BaseEntity
    {
        public ICollection<Sale> Sales;
        [DataType(DataType.Currency)]
        public decimal OriginalTotalPrice { get; set; } = 0;
        [DataType(DataType.Currency)]
        public decimal TotalDiscount { get; set; } = 0;
        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; } = 0;
        public DateTime CreationDate { get; set; }
        public DateTime FinishedDate { get; set; }

        public ShopCart()
        {
            Sales = new HashSet<Sale>();
        }

        public void AddProduct(Product product)
        {
            Sales.Add(new Sale()
            {
                Product = product,
                ProductId = product.Id,
                ProductQuantity = 1
            });
        }

        public void SetTotalPrice()
        {
            foreach(var sale in Sales)
            {
                OriginalTotalPrice += sale.Product.OriginalPrice * sale.ProductQuantity;
                TotalDiscount += sale.GetSaleDiscountPrice();
            }

            TotalPrice = OriginalTotalPrice - TotalDiscount;
        }
    }
}
