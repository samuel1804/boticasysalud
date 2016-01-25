using System;

namespace Pe.ByS.ERP.Services.BusinessLogic.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message)
            : base(message)
        {
        }
    }
}