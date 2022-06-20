using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models.Sales
{
    public class FreeItemPromotion : Promotion
    {
        public FreeItemPromotion()
        {
            Type = Enums.PromotionType.FreeItemPromotion;
        }

        public int QuantityOfFreeItems { get; set; }

        public override decimal CalcDiscount(int quantity, decimal UnitPrice)
        {
            if (quantity % TargetQuantityOfItems != 0)
                return 0;
            
            var quantityOfPromotionUses = quantity / TargetQuantityOfItems;

            return UnitPrice * QuantityOfFreeItems * quantityOfPromotionUses;
        }
    }
}
