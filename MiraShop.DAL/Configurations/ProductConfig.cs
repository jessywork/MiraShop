using MiraShop.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MiraShop.DAL.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(60);

            builder.HasOne<Category>(x => x.Category)
                .WithMany(y => y.Products)
                .HasForeignKey(x => x.CategoryId);

            builder.HasIndex(u => u.Name).IsUnique();
        }
    }
}