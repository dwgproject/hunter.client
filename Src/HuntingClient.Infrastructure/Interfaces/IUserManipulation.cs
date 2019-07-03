using System;
using GravityZero.HuntingClient.Infrastructure.Domain;
using GravityZero.HuntingClient.Infrastructure.Result;

namespace GravityZero.HuntingClient.Infrastructure
{
    public interface IUserManipulation
    {
        HuntingClientResult Update(FullUser user);
        HuntingClientResult Delete(Guid identifier);
    }
}