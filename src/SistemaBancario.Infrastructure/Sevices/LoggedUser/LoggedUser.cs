using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using SistemaBancario.Domain.Entities;
using SistemaBancario.Domain.Security.Tokens;
using SistemaBancario.Domain.Services.LoggdUser;
using SistemaBancario.Infrastructure.DataAccess;

namespace SistemaBancario.Infrastructure.Sevices.LoggedUser
{
    public class LoggedUser : ILoggedUser
    {
        private readonly SistemaBancarioDbContext _dbContext;
        private readonly ITokenProvider _tokenProvider;

        public LoggedUser(SistemaBancarioDbContext dbContext, ITokenProvider tokenProvider)
        {
            _dbContext = dbContext;
            _tokenProvider = tokenProvider;
        }

        public async Task<User> Get()
        {
            string token = _tokenProvider.TokenOnRequest();

            var tokenHandler = new JwtSecurityTokenHandler();

            var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

            var identifier = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

            return await _dbContext
                .Users
                .AsNoTracking()
                .FirstAsync(user => user.Id == Guid.Parse(identifier));
        }
    }
}
