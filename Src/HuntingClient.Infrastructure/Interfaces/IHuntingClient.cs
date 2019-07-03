using GravityZero.HuntingClient.Infrastructure.Domain;
using GravityZero.HuntingClient.Infrastructure.Result;

namespace GravityZero.HuntingClient.Infrastructure
{
    public interface IHuntingClient : IAuthentication, IUserManipulation
    {
        void RegisterStateChanger(IStateChanger changer);
    }
}