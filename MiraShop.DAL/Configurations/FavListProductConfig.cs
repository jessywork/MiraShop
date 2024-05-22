using MiraShop.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MiraShop.DAL.Configurations
{
    public class FavListProductConfig : IEntityTypeConfiguration<FavListProduct>
    {
        public void Configure(EntityTypeBuilder<FavListProduct> builder)
        {
            builder.HasOne<FavList>(x => x.FavList)
                .WithMany(y => y.FavListProducts)
                .HasForeignKey(x => x.FavListId);

            builder.HasOne<Product>(x => x.Product)
                .WithMany(y => y.FavListProducts)
                .HasForeignKey(x => x.ProductId);

            builder.HasIndex(u => new { u.FavListId, u.ProductId }).IsUnique();
        }
    }
}