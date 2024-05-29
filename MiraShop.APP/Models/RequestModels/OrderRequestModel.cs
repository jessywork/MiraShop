namespace MiraShop.API.Models.RequestModels
{
    public class OrderRequestModel
    {
        /// <example>20-03-2023</example>
        public required DateOnly Date { get; set; }

        /// <example>50.00</example>
        public required double Total { get; set; }

        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid UserId { get; set; }   
    }
}
