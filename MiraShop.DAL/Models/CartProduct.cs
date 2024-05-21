namespace MiraShop.DAL.Models
{
    public class CartProduct : BaseEntity
    {
        public required int Quantity { get; set; }
        public required Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public required Guid CartId { get; set; }
        public Cart? Cart { get; set; }
    }
}