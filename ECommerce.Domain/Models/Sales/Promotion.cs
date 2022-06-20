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
        public string? Description { get; set; }
        public int TargetQuantityOfItems { get; set; }
        public PromotionType Type { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }

        protected Promotion()
        {
            Product = new();
        }

        public abstract Decimal CalcDiscount(int quantity, Decimal UnitPrice);
    }
}
