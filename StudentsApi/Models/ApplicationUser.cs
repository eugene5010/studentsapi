using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace StudentsApi.Models
{
    public class ApplicationUser : IIdentity
    {
        public string? Name => Email.Split("@").FirstOrDefault();
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Token { get; set; }
        public string? AuthenticationType { get; }
        public bool IsAuthenticated { get; set; }
        public bool? IsBlocked { get; set; }
        public string PasswordHash { get; set; }
    }
}
