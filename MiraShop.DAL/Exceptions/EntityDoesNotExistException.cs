﻿using MiraShop.DAL.Data.Consts.ENConsts;

namespace MiraShop.DAL.Exceptions
{
    public class EntityDoesNotExistException : Exception
    {
        public EntityDoesNotExistException() : base(GenericConsts.Exceptions.EntityDoesNotExist)
        {
        }

        public EntityDoesNotExistException(string message) : base(message)
        {
        }

        public EntityDoesNotExistException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
