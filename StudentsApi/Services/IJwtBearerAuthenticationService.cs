using StudentsApi.Models;

namespace StudentsApi.Services
{
    public interface IJwtBearerAuthenticationService
    {
        ApplicationUser Authenticate(string username, string password);
    }
}
