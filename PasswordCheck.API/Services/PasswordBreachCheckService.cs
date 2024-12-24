using PasswordCheck.API.Models;

namespace PasswordCheck.API.Services
{
    public interface IPasswordBreachCheckService
    {
        ////  https://api.pwnedpasswords.com/range/{first 5 hash chars}
        public PasswordBreachResponse CheckBreach(PasswordRequest password);

    }

    public class PasswordBreachCheckService : IPasswordBreachCheckService
    {
        // send Get request to the pwnd endpoint and returns how many times a password is breached.
        public PasswordBreachResponse CheckBreach(PasswordRequest password)
        {
            //throw new NotImplementedException();
            PasswordBreachResponse passwordBreachedCheckObject = new PasswordBreachResponse();

            // call the endpoint
            string hibpEndpoint = @"https://api.pwnedpasswords.com/range/";

            return passwordBreachedCheckObject;
        }

        
    }
}
