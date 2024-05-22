using MiraShop.DAL.Data.Consts.ENConsts;

namespace MiraShop.DAL.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException() : base(GenericConsts.Exceptions.Generic)
        {
        }

        public CustomException(string message) : base(message)
        {
        }

        public CustomException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
