using GettingStartedAPI.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GettingStartedAPI.HelperClasses
{
    public class SecurityConfigs
    {
        public static void ConfigureAuthorization(AuthorizationOptions options)
        {
            options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            options.AddPolicy(PolicyConstants.MustBeAnOwner, policy => { policy.RequireClaim("title", "Business Owner"); });
            options.AddPolicy(PolicyConstants.MustBeAVeteranEmployee, policy => { policy.RequireClaim("emp_id", "E000", "E001", "E002"); });
            options.AddPolicy(PolicyConstants.MustHaveEmployeeId, policy => { policy.RequireClaim("emp_id"); });
        }
        public static void ConfigureAuthentication(JwtBearerOptions opts,WebApplicationBuilder builder)
        {
            opts.TokenValidationParameters = new()
            {

                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("Authentication:SecretKey"))),
                ValidIssuer = builder.Configuration.GetValue<string>("Authentication:Issuer"),
                ValidAudience = builder.Configuration.GetValue<string>("Authentication:Audience")
            };

        }
    }
}
