using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiseAndWalk_Server.ExceptionFilters
{
    public enum ValidationErrorType
    {
        UserEvenExist,
        UserNotExist,
        Unauthorized,
        RequiresTwoFactor,
        LoginNotAllowed
    }

    public class ValidationException : Exception
    {
        public string ErrorType { get; private set; }

        public ValidationException(ValidationErrorType errorType) : base()
        {
            ErrorType = errorType.ToString();
        }

        public ValidationException(string errorType) : base()
        {
            ErrorType = errorType;
        }
    }
}
