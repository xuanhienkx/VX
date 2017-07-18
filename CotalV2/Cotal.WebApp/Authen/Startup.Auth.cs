﻿using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Cotal.Core.Identity.Services;
using Cotal.WebApp.Authen;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;

namespace Cotal.WebApp
{
  public partial class Startup
  {
    // The secret key every token will be signed with.
    // Keep this safe on the server!
    private static readonly string secretKey = "mysupersecret_secretkey!123";

    private void ConfigureAuth(IApplicationBuilder app)
    {
      var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

      app.UseSimpleTokenProvider(new TokenProviderOptions
      {
        Path = "/token",
        Audience = "ExampleAudience",
        Issuer = "ExampleIssuer",
        SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
        IdentityResolver = GetIdentity
      });

      var tokenValidationParameters = new TokenValidationParameters
      {
        // The signing key must match!
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = signingKey,

        // Validate the JWT Issuer (iss) claim
        ValidateIssuer = true,
        ValidIssuer = "ExampleIssuer",

        // Validate the JWT Audience (aud) claim
        ValidateAudience = true,
        ValidAudience = "ExampleAudience",

        // Validate the token expiry
        ValidateLifetime = true,

        // If you want to allow a certain amount of clock drift, set that here:
        ClockSkew = TimeSpan.Zero
      };

      app.UseJwtBearerAuthentication(new JwtBearerOptions
      {
        AutomaticAuthenticate = true,
        AutomaticChallenge = true,
        TokenValidationParameters = tokenValidationParameters
      });

      app.UseCookieAuthentication(new CookieAuthenticationOptions
      {
        AutomaticAuthenticate = true,
        AutomaticChallenge = true,
        AuthenticationScheme = "Cookie",
        CookieName = "access_token",
        TicketDataFormat = new CustomJwtDataFormat(
          SecurityAlgorithms.HmacSha256,
          tokenValidationParameters)
      });
    }

    private Task<ClaimsIdentity> GetIdentity(string username, string password, IUserService userService)
    {
      if (userService.Login(username, password))
        return Task.FromResult(
          new ClaimsIdentity(new GenericIdentity(username, "Token"),
            new Claim[]
            {
              /*new Claim("Roles", JsonConvert.SerializeObject(_loginService.CurrenrUser(username))) */
            }));

      // Credentials are invalid, or account doesn't exist
      return Task.FromResult<ClaimsIdentity>(null);
    }
  }
}
