namespace ECart.API.Data.Models;
public class ApiResult
{
    public bool IsSuccess { get; }

    public string Message { get; }

    public int StatusCode { get; set; } = StatusCodes.Status200OK;

    public ApiResult(bool isSuccess, string message, int statusCode)
    {
        IsSuccess = isSuccess;
        Message = message;
        StatusCode = statusCode;
    }
}


public class ApiResult<T>
{
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
    public string Message { get; set; }
    public int StatusCode { get; set; } = StatusCodes.Status200OK;
}


