using ECommerce.Domain.Models.Sales.Enums;

namespace ECommerce.Web.Utils
{
    public class PromotionUtils
    {
        public static string PromoEditRedirectName(PromotionType type)
        {
            switch (type)
            {
                case PromotionType.PercentageValuePromotion:
                    return "EditPercentageValuePromo";
                case PromotionType.FixedValuePromotion:
                    return "EditFixedValuePromo";
                case PromotionType.FreeItemPromotion:
                    return "EditFreeItemPromo";
                default:
                    return "";
            }
        }
    }
}
