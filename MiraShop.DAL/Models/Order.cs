namespace MiraShop.DAL.Models
{
    public class Order : BaseEntity
    {
        public required DateOnly Date { get; set; }
        public required double Total { get; set; }
        public ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}