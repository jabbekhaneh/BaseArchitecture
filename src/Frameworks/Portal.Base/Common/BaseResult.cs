namespace Portal.Base.Common;

public class BaseResult<TResult>
{

    private readonly List<string> _messages = new();
    public IEnumerable<string> Messages => _messages;
    public TResult? Result { get; private set; }
    public bool IsSuccess { get; private set; }
    public Exception? Exception { get; private set; }
    public int Status { get; private set; }


    public void ClearMessages() => _messages.Clear();
    public void AddMessage(string error) => _messages.Add(error);
    public void AddMessages(IEnumerable<string> errors) => _messages.AddRange(errors);
    public static BaseResult<TResult> BuildSuccess(TResult result)
    {
        return new BaseResult<TResult> { IsSuccess = true, Result = result , Status = BaseStatusCodes.OK };
    }

    public static BaseResult<TResult> BuildFailure(int status)
    {
        return new BaseResult<TResult> { IsSuccess = false, Status = status };
    }
    public static BaseResult<TResult> BuildFailure(Exception exception)
    {
        return new BaseResult<TResult> { IsSuccess = false, Exception = exception };
    }
    public static BaseResult<TResult> BuildFailure(Exception exception, int status)
    {
        return new BaseResult<TResult> { IsSuccess = false, Exception = exception, Status = status };
    }


}
