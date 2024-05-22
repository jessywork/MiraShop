namespace MiraShop.DAL.Models
{
    public class Order : BaseEntity
    {
        public required DateOnly Date { get; set; }
        public required double Total { get; set; }
        public required Guid UserId { get; set; }
        public User? User { get; set; }
        public ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}