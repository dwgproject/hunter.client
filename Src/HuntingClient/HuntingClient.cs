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

        HuntingClientResult Login(Authentication authentication)
        {
            authentication.Login(authentication);
        }

        HuntingClientResult Logout()
        {
            authentication.Logout();
        }

        HuntingClientResult Update(FullUser user)
        {
            userManipulation.Update(user);
        }

        HuntingClientResult Delete(Guid identifier)
        {
            userManipulation.Delete(identifier);
        }

        void RegisterStateChanger(IStateChanger changer)
        {
            this.changer = changer;
        }
    }
}
