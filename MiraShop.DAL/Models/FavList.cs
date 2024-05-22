namespace MiraShop.DAL.Models
{
    public class FavList: BaseEntity
    {
        public required Guid UserId { get; set; }
        public User? User { get; set; }
        public ICollection<FavListProduct>? FavListProducts { get; set; }
    }
}