using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models.Sales
{
    public class Product : BaseEntity
    {
        [StringLength(500)]
        [Display(Name = "Item")]
        public string Name { get; set; } = "";
        [Display(Name ="Preço")]
        public decimal OriginalPrice { get; set; } = 0;
        public Promotion? Promotion { get; set; }
        public ICollection<Sale> Sales { get; set; }

        public Product()
        {
            Sales = new HashSet<Sale>();
        }

        public Decimal GetDiscountPrice(int quantity)
        {
            if(Promotion == null)
                return 0;

            return Promotion.CalcDiscount(quantity, OriginalPrice);
        }
    }
}
