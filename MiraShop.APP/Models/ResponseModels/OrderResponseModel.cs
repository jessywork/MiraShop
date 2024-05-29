namespace MiraShop.API.Models.ResponseModels
{
    public class OrderResponseModel
    {
        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid Id { get; set; }

        /// <example>20-03-2023</example>
        public required DateOnly Date { get; set; }

        /// <example>50.00</example>
        public required double Total { get; set; }

        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid UserId { get; set; }   
    }
}
