using ClassLibary;

namespace SUT23_Projekt___Avancerad_.NET.Services
{
    public interface IUserRepository
    {

        Task<int> CreateUser(User user);
        bool CheckPassword(User user, string password);
        User FindByUsername(string username);

    }
}
