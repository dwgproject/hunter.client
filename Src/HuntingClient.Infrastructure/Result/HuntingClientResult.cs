namespace GravityZero.HuntingClient.Infrastructure.Result
{
    public class HuntingClientResult
    {
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }

        public HuntingClientResult(bool isSuccess, string message)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
        }
    }
}