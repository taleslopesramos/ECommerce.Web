using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Models.Sales;

namespace ECommerce.Infra.Context
{
    public class SalesDbContext : DbContext
    {
        public DbSet<ShopCart> ShopCarts { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Promotion> Promotions { get; set; }

        public SalesDbContext(IConfiguration config, DbContextOptions<SalesDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FixedValuePromotion>();
            builder.Entity<FreeItemPromotion>();
            builder.Entity<PercentageValuePromotion>();
            builder.Entity<ShopCart>(sc =>
            {
                sc.HasKey(sc => sc.Id);
                
                sc.HasMany(sc => sc.Sales)
                .WithOne(s => s.ShopCart)
                .HasForeignKey(s => s.ShopCartId)
                .HasConstraintName("ShopCartSalesFK")
                .OnDelete(DeleteBehavior.ClientSetNull);

                sc.HasData(new ShopCart { Id = 1, CreationDate = DateTime.Now });
            });

            builder.Entity<Sale>(s =>
            {
                s.HasKey(s => s.Id);

                s.HasOne(s => s.Product)
                .WithMany(p => p.Sales)
                .HasForeignKey(s => s.ProductId)
                .HasConstraintName("ProductSalesFK")
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            builder.Entity<Product>(p =>
            {
                p.HasOne(p => p.Promotion)
                .WithOne(p => p.Product)
                .HasForeignKey<Promotion>(p => p.ProductId)
                .HasConstraintName("ProductPromotionFK")
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
