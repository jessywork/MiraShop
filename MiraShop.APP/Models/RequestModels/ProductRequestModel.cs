namespace MiraShop.API.Models.RequestModels
{
    public class ProductRequestModel
    {
        /// <example>Mom jeans</example>
        public required string Name { get; set; }

        /// <example>19.99</example>
        public required double Price { get; set; }

        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid CategoryId { get; set; }

        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid GenreId { get; set; }
    }
}
