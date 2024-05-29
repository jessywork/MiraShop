namespace MiraShop.API.Models.ResponseModels
{
    public class ProductResponseModel
    {
        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid Id { get; set; }

        /// <example>Product name</example>
        public required string Name { get; set; }

        /// <example>Product price</example>
        public required double Price { get; set; }

        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid CategoryId { get; set; }

        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid GenreId { get; set; }
    }
}
