using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models.Sales
{
    public class FixedValuePromotion : Promotion
    {
        public FixedValuePromotion()
        {
            Type = Enums.PromotionType.FixedValuePromotion;
        }

        public decimal DiscountValue { get; set; }

        public override decimal CalcDiscount(int quantity, decimal UnitPrice)
        {
            if (quantity % TargetQuantityOfItems != 0)
                return 0;
            
            var quantityOfPromotionUses = quantity / TargetQuantityOfItems;

            return quantityOfPromotionUses * DiscountValue;
        }
    }
}
