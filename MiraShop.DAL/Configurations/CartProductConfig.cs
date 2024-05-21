using MiraShop.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MiraShop.DAL.Configurations
{
    public class CartProductConfig : IEntityTypeConfiguration<CartProduct>
    {
        public void Configure(EntityTypeBuilder<CartProduct> builder)
        {
            builder.HasOne<Cart>(x => x.Cart)
                .WithMany(y => y.CartProducts)
                .HasForeignKey(x => x.CartId);

            builder.HasOne<Product>(x => x.Product)
                .WithMany(y => y.CartProducts)
                .HasForeignKey(x => x.ProductId);

            builder.HasIndex(u => new { u.CartId, u.ProductId }).IsUnique();
        }
    }
}