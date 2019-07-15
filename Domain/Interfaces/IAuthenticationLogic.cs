using Domain.Models;

namespace Domain.Interfaces
{
    public interface IAuthenticationLogic
    {
        void GoToCreateAccount(Person person);
        void Login(Credentials credentials);
    }
}
