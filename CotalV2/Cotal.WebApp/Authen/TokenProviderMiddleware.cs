﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Cotal.App.Business.Constants;
using Cotal.App.Business.Services;
using Cotal.Core.Identity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Cotal.WebApp.Authen
{
    /// <summary>
    ///   Token generator middleware component which is added to an HTTP pipeline.
    ///   This class is not created by application code directly,
    ///   instead it is added by calling the
    ///   <see
    ///     cref="TokenProviderAppBuilderExtensions.UseSimpleTokenProvider(Microsoft.AspNetCore.Builder.IApplicationBuilder, TokenProviderOptions)" />
    ///   extension method.
    /// </summary>
    public class TokenProviderMiddleware
    {
        private readonly ILogger _logger;
        private readonly ILoginService _loginService;
        private readonly RequestDelegate _next;
        private readonly TokenProviderOptions _options;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly IUserService _userService;

        public TokenProviderMiddleware(
          RequestDelegate next,
          IOptions<TokenProviderOptions> options,
          ILoggerFactory loggerFactory, ILoginService loginService, IUserService userService)
        {
            _next = next;
            _loginService = loginService;
            _userService = userService;
            _logger = loggerFactory.CreateLogger<TokenProviderMiddleware>();

            _options = options.Value;
           
            ThrowIfInvalidOptions(_options);

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        public Task Invoke(HttpContext context)
        {
            // If the request path doesn't match, skip
            _logger.LogDebug("HttpContext request: " + JsonConvert.SerializeObject(context.Request.Headers)); 

            if (!context.Request.Path.Equals(_options.Path, StringComparison.Ordinal))
                return _next(context);
            // Request must be POST with Content-Type: application/x-www-form-urlencoded
            if (!context.Request.Method.Equals("POST")
                || !context.Request.HasFormContentType)
            {
                context.Response.StatusCode = 400;
                return context.Response.WriteAsync("Bad request.");
            }

            _logger.LogInformation("Handling request: " + context.Request.Path);

            return GenerateToken(context);
        }

        private async Task GenerateToken(HttpContext context)
        {
            var username = context.Request.Form["username"];
            var password = context.Request.Form["password"];
            _logger.LogDebug($"username:{username}, password:{password}");
            var identity = await _options.IdentityResolver(username, password, _userService);
            if (identity == null)
            {
                _logger.LogError("Invalid username or password.");
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid username or password.");
                return;
            }

            var now = DateTime.UtcNow;

            // Specifically add the jti (nonce), iat (issued timestamp), and sub (subject/user) claims.
            // You can add other claims here, if you want:
            var user = await _loginService.CurrenrUser(username);
            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, username),
        new Claim(JwtRegisteredClaimNames.Jti, await _options.NonceGenerator()),
        new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(now).ToString(), ClaimValueTypes.Integer64),
        new Claim(Constants.CURRENT_USER, JsonConvert.SerializeObject(user))
      };

            // Create the JWT and write it to a string
            var jwt = new JwtSecurityToken(
              _options.Issuer,
              _options.Audience,
              claims,
              now,
              now.Add(_options.Expiration),
              _options.SigningCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new
            {
                user.Id,
                user.UserName,
                user.FullName,
                user.Email,
                user.Avatar,
                access_token = encodedJwt,
                ExpiresIn = (int)_options.Expiration.TotalSeconds,
                Permissions = JsonConvert.SerializeObject(user.Permissions),
                Roles = JsonConvert.SerializeObject(user.Roles)
            };

            // Serialize and return the response
            context.Response.ContentType = "application/json";
            _logger.LogInformation("User:" + JsonConvert.SerializeObject(response, _serializerSettings));
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, _serializerSettings));
        }

        private static void ThrowIfInvalidOptions(TokenProviderOptions options)
        {
            if (string.IsNullOrEmpty(options.Path))
                throw new ArgumentNullException(nameof(TokenProviderOptions.Path));

            if (string.IsNullOrEmpty(options.Issuer))
                throw new ArgumentNullException(nameof(TokenProviderOptions.Issuer));

            if (string.IsNullOrEmpty(options.Audience))
                throw new ArgumentNullException(nameof(TokenProviderOptions.Audience));

            if (options.Expiration == TimeSpan.Zero)
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(TokenProviderOptions.Expiration));

            if (options.IdentityResolver == null)
                throw new ArgumentNullException(nameof(TokenProviderOptions.IdentityResolver));

            if (options.SigningCredentials == null)
                throw new ArgumentNullException(nameof(TokenProviderOptions.SigningCredentials));

            if (options.NonceGenerator == null)
                throw new ArgumentNullException(nameof(TokenProviderOptions.NonceGenerator));
        }

        /// <summary>
        ///   Get this datetime as a Unix epoch timestamp (seconds since Jan 1, 1970, midnight UTC).
        /// </summary>
        /// <param name="date">The date to convert.</param>
        /// <returns>Seconds since Unix epoch.</returns>
        public static long ToUnixEpochDate(DateTime date)
        {
            return new DateTimeOffset(date).ToUniversalTime().ToUnixTimeSeconds();
        }
    }
}
