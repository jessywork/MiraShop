using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MiraShop.DAL.Models;

namespace MiraShop.DAL.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(60);
            
            builder.HasIndex(u => u.Name).IsUnique();
        }
    }
}