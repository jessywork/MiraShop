using MiraShop.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MiraShop.DAL.Configurations
{
    public class OrderProductConfig : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasOne<Order>(x => x.Order)
                .WithMany(y => y.OrderProducts)
                .HasForeignKey(x => x.OrderId);

            builder.HasOne<Product>(x => x.Product)
                .WithMany(y => y.OrderProducts)
                .HasForeignKey(x => x.ProductId);

            builder.HasIndex(u => new { u.OrderId, u.ProductId }).IsUnique();
        }
    }
}