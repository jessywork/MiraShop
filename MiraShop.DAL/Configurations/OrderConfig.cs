using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MiraShop.DAL.Models;

namespace MiraShop.DAL.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
			builder.HasOne<User>(x => x.User)
                .WithMany(y => y.Orders)
                .HasForeignKey(x => x.OrderId);
        }
    }
}