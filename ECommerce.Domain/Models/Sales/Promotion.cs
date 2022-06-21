using ECommerce.Domain.Models.Sales.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models.Sales
{
    public abstract class Promotion : BaseEntity
    {
        [StringLength(500)]
        [Display(Name = "Descrição")]
        public string? Description { get; set; }

        [Display(Name = "Quantidade de items no conjunto")]
        [Range(1, Int32.MaxValue, ErrorMessage = "A quantidade de items no conjunto da promoção deve ser no mínimo 1")]
        public int TargetQuantityOfItems { get; set; }
        [Display(Name = "Tipo")]
        public PromotionType Type { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        protected Promotion()
        {
            Product = new();
        }

        public abstract decimal CalcDiscount(int quantity, decimal UnitPrice);

        public static Promotion? CreateByType(PromotionType? PromoType)
        {
            switch (PromoType)
            {
                case PromotionType.PercentageValuePromotion:
                    return new PercentageValuePromotion();

                case PromotionType.FixedValuePromotion:
                    return new FixedValuePromotion();

                case PromotionType.FreeItemPromotion:
                    return new FreeItemPromotion();

                default:
                    return null;
            }
        }
    }
}
