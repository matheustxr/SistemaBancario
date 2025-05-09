using System.Net;
using SistemaBancario.Exception.ExceptionBase;

namespace Habits.Exception.ExceptionBase;
public class NotFoundException : AppException
{
    public NotFoundException(string message) : base(message)
    {
    }

    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
