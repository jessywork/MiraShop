namespace MiraShop.DAL.Models
{
    public class User : BaseEntity
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required byte[] PasswordHash { get; set; }
        public required byte[] PasswordSalt { get; set; }
        public required Guid CartId { get; set; }
        public Cart? Cart { get; set; }
        public required Guid FavListId { get; set; }
        public FavList? FavList { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}