using MiraShop.DAL.Data.Consts.ENConsts;

namespace MiraShop.DAL.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base(GenericConsts.Exceptions.NotFoundException)
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
