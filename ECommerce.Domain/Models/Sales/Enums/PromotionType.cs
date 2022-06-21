using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models.Sales.Enums
{
    public enum PromotionType
    {
        [Display(Name ="Valor fixo")]
        FixedValuePromotion,
        [Display(Name = "Porcentagem")]
        PercentageValuePromotion,
        [Display(Name = "Leve X pague Y")]
        FreeItemPromotion
    }
}
