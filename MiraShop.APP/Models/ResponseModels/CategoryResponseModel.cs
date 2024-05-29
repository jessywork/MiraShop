﻿namespace MiraShop.API.Models.ResponseModels
{
    public class CategoryResponseModel
    {
        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid Id { get; set; }

        /// <example>Category name</example>
        public required string Name { get; set; }   
    }
}
