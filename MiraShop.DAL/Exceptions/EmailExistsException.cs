using MiraShop.DAL.Data.Consts.ENConsts;

namespace MiraShop.DAL.Exceptions
{
    public class EmailExistsException : Exception
    {
        public EmailExistsException() : base(GenericConsts.Exceptions.EmailAlreadyTaken)
        {
        }
    }
}
