using System;
using GravityZero.HuntingClient.Infrastructure;
using GravityZero.HuntingClient.Infrastructure.Domain;
using GravityZero.HuntingClient.Infrastructure.Result;

namespace GravityZero.HuntingClient
{
    public class Client : IHuntingClient 
    {
        private IAuthentication authentication;
        private IUserManipulation userManipulation;
        private IStateChanger changer;
        private Guid identifier;
        
        public Client()
        {
            this.authentication = new AuthenticationDisconnect();
        }
        
        public HuntingClientResult Login(Authentication authentication)
        {

            HuntingClientResult loginResult = this.authentication.Login(authentication);
            if (loginResult.IsSuccess){
                this.authentication = new AuthenticationConnected(identifier);
            }
            return loginResult;
        }

        public HuntingClientResult Logout()
        {
            HuntingClientResult logoutResult = this.authentication.Logout();
            if (logoutResult.IsSuccess)
            {
                this.authentication = new AuthenticationDisconnect();
            }
            return logoutResult;
        }

        public HuntingClientResult Update(FullUser user)
        {
            return this.userManipulation.Update(user);
        }

        public HuntingClientResult Delete(Guid identifier)
        {
            return this.userManipulation.Delete(identifier);
        }

        public void RegisterStateChanger(IStateChanger changer)
        {
            
        }
    }
}