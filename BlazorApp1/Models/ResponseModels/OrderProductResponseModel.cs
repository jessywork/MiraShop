namespace MiraShop.API.Models.ResponseModels
{
    public class OrderProductResponseModel
    {
        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid Id { get; set; }

        /// <example>Quantity</example>
        public required int Quantity { get; set; }

        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid ProductId { get; set; }

        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid OrderId { get; set; }

        public ProductResponseModel? Product { get; set; }
    }
}
