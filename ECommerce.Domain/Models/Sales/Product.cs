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
        [Required(ErrorMessage= "Este campo é obrigatório")]
        [MinLength(2, ErrorMessage = "Este campo deve ter no mínimo 2 caracteres")]
        [MaxLength(500, ErrorMessage = "Este campo deve ter no máximo 500 caracteres")]
        [Display(Name = "Nome")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DataType(DataType.Currency)]
        [Range(0.0, 1000000, ErrorMessage = "Este campo deve ser maior que {1}")]
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
