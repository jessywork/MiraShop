﻿namespace MiraShop.BLL.Data.Consts.ENConsts
{
    public class GenericConsts
    {
        public static class Entities
        {
            public const string Category = "Category";
            public const string Product = "Product";
            public const string Genre = "Genre";
            public const string Order = "Order";
            public const string User = "User";
            public const string Entity = "Entity";
        }

        public static class Exceptions
        {
            public const string InsertDuplicateUserInHouse = "This user already exists in this house";
            //public const string DuplicateHouseName = "House name";
            //public const string InsertDuplicateProductInList = "This product already exists in this shopping list";
            //public const string NoUsersFoundInHouse = "No users found in house";
            //public const string NoProductsFoundInList = "No products found in shopping list";
            //public const string NoHouseFoundForUser = "User has no houses";
            //public const string NoProductsFoundInHouse = "No products found in house";
            //public const string NoSectionsFoundInHouse = "No sections found in house";
            //public const string NoMeasuresFoundInHouse = "No measures found in house";
            //public const string NoListsFoundInHouse = "No {0} found in house";
            //public const string HouseCannotBeNull = "House cannot be null";
            //public const string DeleteAllUsersFromHouse = "Delete all users from house will remove the house";
            public const string DuplicateEntityFormat = "{0} already exists.";
        }
    }
}
