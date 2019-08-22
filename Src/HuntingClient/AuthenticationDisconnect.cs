using System;
using System.Threading.Tasks;
using Gravityzero.Console.Utility.Tools;
using GravityZero.HuntingClient.Infrastructure;
using GravityZero.HuntingClient.Infrastructure.Domain;
using GravityZero.HuntingClient.Infrastructure.Result;

namespace GravityZero.HuntingClient
{
    public class AuthenticationDisconnect : IAuthentication
    {
        
        public HuntingClientResult Login(Authentication authentication)
        {
            string path = "http://projecthunter.pl:80/Api/User/SignIn";
            Task<ConnectorResult<Guid>> postResult =  WinApiConnector.RequestPost<Authentication, Guid>(path, authentication);
            ConnectorResult<Guid> result =  postResult.Result;
        }

        public HuntingClientResult Logout()
        {
            return new HuntingClientResult(true, "You aren't logged.");
        }
    }
}