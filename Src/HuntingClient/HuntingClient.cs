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
        
        public Client()
        {

        }
        
        public HuntingClientResult Login(Authentication authentication)
        {
            return this.authentication.Login(authentication);
        }

        public HuntingClientResult Logout()
        {
            return this.authentication.Logout();
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
