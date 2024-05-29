﻿namespace MiraShop.API.Models.RequestModels
{
    public class OrderProductRequestModel
    {
        /// <example>1</example>
        public required int Quantity { get; set; }

        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid ProductId { get; set; }

        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid OrderId { get; set; }
    }
}
