using System;
using System.Threading.Tasks;
using Gravityzero.Console.Utility.Tools;
using GravityZero.HuntingClient.Infrastructure;
using GravityZero.HuntingClient.Infrastructure.Domain;
using GravityZero.HuntingClient.Infrastructure.Result;

namespace GravityZero.HuntingClient
{
    public class AuthenticationConnected : IAuthentication
    {
        private Guid identifier;
        public AuthenticationConnected(Guid identifier)
        {
            this.identifier = identifier;
        }

        public HuntingClientResult Login(Authentication authentication)
        {
            return new HuntingClientResult(false, "You are logged.");
        }

        public HuntingClientResult Logout()
        {
            string path = "http://projecthunter.pl:80/Api/User/SignOut";
            Task<ConnectorResult<Guid>> postResult =  WinApiConnector.RequestPost<Guid, Guid>(path, identifier);
            ConnectorResult<Guid> result =  postResult.Result;
            if (!result.IsSuccess) return new HuntingClientResult(false, result.Message);
            return new HuntingClientResult(true, "You are sucessful logout.");
        }
    }
}