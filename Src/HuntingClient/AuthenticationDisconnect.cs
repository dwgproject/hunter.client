using GravityZero.HuntingClient.Infrastructure;
using GravityZero.HuntingClient.Infrastructure.Domain;
using GravityZero.HuntingClient.Infrastructure.Result;

namespace GravityZero.HuntingClient
{
    public class AuthenticationDisconnect : IAuthentication
    {
        public HuntingClientResult Login(Authentication authentication)
        {
            
        }

        public HuntingClientResult Logout()
        {
            return new HuntingClientResult(true, "You aren't logged.");
        }
    }
}