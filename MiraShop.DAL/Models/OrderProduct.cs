namespace MiraShop.DAL.Models
{
    public class OrderProduct : BaseEntity
    {
        public required int Quantity { get; set; }
        public required Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public required Guid OrderId { get; set; }
        public Order? Order { get; set; }
    }
}