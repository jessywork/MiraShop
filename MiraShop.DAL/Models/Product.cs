namespace MiraShop.DAL.Models
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public required double Price { get; set; }
        public required Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        public required Guid GenreId { get; set; }
        public Genre? Genre { get; set; }
        public ICollection<OrderProduct>? OrderProducts { get; set; }
        public ICollection<CartProduct>? CartProducts { get; set; }
        public ICollection<FavListProduct>? FavListProducts { get; set; }
    }
}