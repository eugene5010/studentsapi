using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StudentsApi.Data.Models;
using StudentsApi.Models;


namespace StudentsApi.Services
{
    /// <summary>
    /// Some hand-crafted jwt authentication service to providing test application simplicity
    /// </summary>
    internal class JwtBearerAuthenticationService : IJwtBearerAuthenticationService
    {
        private readonly List<Account> _fakeAccounts = new List<Account>();
        private readonly AppSettings _appSettings;
        
        //should be injected by ioc. Avoid this to skip all the needed infrastructure.
        private readonly IPasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

        public JwtBearerAuthenticationService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _fakeAccounts.Add(new Account()
            {
                AccountId = 1,
                EmailAddress = "test@yandex.ru",
                FirstName = "test",
                LastName = "test",
                Password = new Password()
                {
                    AccountId = 1,
                    PasswordHash = passwordHasher.HashPassword(null, "123")
                }
            });
        }

        //in the real production code working with dbcontext to get user account method should be async
        public ApplicationUser Authenticate(string username, string password)
        {
            var account = _fakeAccounts
                .FirstOrDefault(x =>
                x.EmailAddress == username && !x.IsBlocked && !x.IsDeleted);

            if (account == null || passwordHasher.VerifyHashedPassword(null, account.Password.PasswordHash, password) == PasswordVerificationResult.Failed)
            {
                return null;
            }

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.GivenName, account.FirstName),
                    new Claim(ClaimTypes.Email, account.EmailAddress),
                    new Claim(ClaimTypes.Surname, account.LastName),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var user = new ApplicationUser()
            {
                //here Automapper can be used instead of direct members copy
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.EmailAddress,
                Token = tokenHandler.WriteToken(token),
                IsAuthenticated = true
            };
            return user;
        }
    }
}
