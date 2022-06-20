using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models.Sales
{
    public class PercentageValuePromotion : Promotion
    {
        public PercentageValuePromotion()
        {
            Type = Enums.PromotionType.PercentageValuePromotion;
        }
        public Decimal DiscountPercentage { get; set; }

        public override decimal CalcDiscount(int quantity, decimal UnitPrice)
        {
            // By standard Percentage Promotions don't require 
            // a TargetQuantityOfItems to apply
            return UnitPrice * quantity * DiscountPercentage;
        }
    }
}
