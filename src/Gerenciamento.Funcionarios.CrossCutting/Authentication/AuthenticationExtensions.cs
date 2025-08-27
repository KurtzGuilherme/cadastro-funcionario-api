using Gerenciamento.Funcionarios.CrossCutting.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Gerenciamento.Funcionarios.CrossCutting.Authentication;
public static class AuthenticationExtensions
{
    public static IServiceCollection AddAuthenticationJwt(this IServiceCollection services, AuthenticationJwt AuthenticationJwt)
    {
        var key = AuthenticationJwt.SecretKey;

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidIssuer = AuthenticationJwt.Issuer,
                ValidAudience = AuthenticationJwt.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                ClockSkew = TimeSpan.Zero,
            };
        });

        return services;
    }
}
