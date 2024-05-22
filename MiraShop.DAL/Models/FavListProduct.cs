namespace MiraShop.DAL.Models
{
    public class FavListProduct : BaseEntity
    {
        public required Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public required Guid FavListId { get; set; }
        public FavList? FavList { get; set; }
    }
}