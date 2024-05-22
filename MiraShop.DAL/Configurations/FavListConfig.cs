using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MiraShop.DAL.Models;

namespace MiraShop.DAL.Configurations
{
    public class FavListConfig : IEntityTypeConfiguration<FavList>
    {
        public void Configure(EntityTypeBuilder<FavList> builder)
        {
            builder.HasOne<User>(x => x.User)
                .WithOne(y => y.Cart)
                .HasForeignKey(x => x.UserId);
        }
    }
}