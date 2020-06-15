using System.Collections.Generic;

namespace CommonServices.Authentication
{
    public interface IAuthenticationService
    {
        void SetLoggedUser(KeyValuePair<string, string> emailAndName);
        KeyValuePair<string, string> GetLoggedUser();
        bool IsEmailValid(string email);
    }
}
