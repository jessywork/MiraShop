namespace MiraShop.API.Models.RequestModels
{
    public class FavListProductRequestModel
    {

        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid ProductId { get; set; }

        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid FavListId { get; set; }
    }
}
