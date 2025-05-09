using System.Net;
using SistemaBancario.Exception.ExceptionBase;

namespace Habits.Exception.ExceptionBase;

public class InvalidLoginException : AppException
{
    public InvalidLoginException() : base(ResourceErrorMessages.EMAIL_OR_PASSWORD_INVALID)
    {
    }

    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
