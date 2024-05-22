using MiraShop.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MiraShop.DAL.Configurations
{
    public class CartConfig : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasOne<User>(x => x.User)
                .WithOne(y => y.Cart)
                .HasForeignKey<Cart>(x => x.UserId);
        }
    }
}