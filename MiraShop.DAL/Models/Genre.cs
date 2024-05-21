namespace MiraShop.DAL.Models
{
    public class Genre : BaseEntity
    {
        public required string Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}