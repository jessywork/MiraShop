using MiraShop.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MiraShop.DAL.Configurations
{
    public class CartConfig : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne<User>(x => x.User)
                .WithOne(y => y.Cart)
                .HasForeignKey(x => x.UserId);
        }
    }
}