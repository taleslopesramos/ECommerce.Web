using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models.Sales
{
    public class ShopCart : BaseEntity
    {
        public ICollection<Sale> Sales;
        public decimal OriginalTotalPrice { get; set; } = 0;
        public decimal TotalDiscount { get; set; } = 0;
        public decimal TotalPrice { get; set; } = 0;
        public DateTime CreationDate { get; set; }
        public DateTime FinishedDate { get; set; }

        public ShopCart()
        {
            Sales = new HashSet<Sale>();
        }

        public void SetTotalPrice()
        {
            foreach(var sale in Sales)
            {
                OriginalTotalPrice += sale.Product.OriginalPrice;
                TotalDiscount += sale.GetSaleDiscountPrice();
            }

            TotalPrice = OriginalTotalPrice - TotalDiscount;
        }
    }
}
