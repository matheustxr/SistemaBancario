using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaBancario.API.Filters
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExceptionFilter : ControllerBase
    {
    }
}
