using System;
using System.Threading.Tasks;
using Gravityzero.Console.Utility.Tools;
using GravityZero.HuntingClient.Infrastructure;
using GravityZero.HuntingClient.Infrastructure.Domain;
using GravityZero.HuntingClient.Infrastructure.Result;

namespace GravityZero.HuntingClient
{
    public class Client : IHuntingClient 
    {
        private readonly string path = "http://projecthunter.pl:80/Api/User/KeepAlive";
        private IAuthentication authentication;
        private IUserManipulation userManipulation;
        private IStateChanger changer;
        private Guid identifier;
        
        public Client()
        {
            this.authentication = new AuthenticationDisconnect();
            Task.Run(async () => {
                short connectionErrorCounter = 0;
                while(true)
                {
                    ConnectorResult<Guid>  getResult = await WinApiConnector.RequestGet<Guid>(path);
                    if (getResult.IsSuccess)
                    {
                        connectionErrorCounter = 0;
                    }
                    else
                    {
                        connectionErrorCounter += 1;
                        if (connectionErrorCounter > 10)
                        {
                            //co zrobić na błąd połączebnia
                            //stworzyć obiekt odpowiadający na zbieranie danych do czasu odzyskania połączenia???
                        }
                    }
                    await Task.Delay(2000);
                }
            });
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