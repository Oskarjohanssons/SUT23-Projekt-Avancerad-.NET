using ClassLibary;

namespace SUT23_Projekt___Avancerad_.NET.Services
{
    public interface IAuthenticationRepository
    {
        public string GenerateJwtToken(User user);
        public bool ValidateLogin(string username, string password);
    }
}
