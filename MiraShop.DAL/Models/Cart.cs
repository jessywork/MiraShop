namespace MiraShop.DAL.Models
{
    public class Cart: BaseEntity
    {
        public required string Name { get; set; }
        public required Guid UserId { get; set; }
        public User? User { get; set; }
        public ICollection<CartProduct>? CartProducts { get; set; }
    }
}