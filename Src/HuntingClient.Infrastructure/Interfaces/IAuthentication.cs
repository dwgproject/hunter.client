using GravityZero.HuntingClient.Infrastructure.Domain;
using GravityZero.HuntingClient.Infrastructure.Result;

namespace GravityZero.HuntingClient.Infrastructure
{
    public interface IAuthentication
    {
        HuntingClientResult Login(Authentication authentication);
        HuntingClientResult Logout();
    }
}