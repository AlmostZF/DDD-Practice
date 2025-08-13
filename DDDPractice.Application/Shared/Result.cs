namespace DDDPractice.Application.Shared;

public class Result<T>
{
    public bool IsSuccess { get; set; }
    public string? Error { get; set; }
    public T? Value { get; set; }

    public int StatusCode { get; set; }

    public static Result<T> Success(T value,int statusCode = 200) 
        => new Result<T> { IsSuccess = true, Value = value, StatusCode = statusCode};
    public static Result<T> Failure(string error,int statusCode = 400) 
        => new Result<T> { IsSuccess = false, Error = error, StatusCode = statusCode };
}
public class Result
{
    public bool IsSuccess { get; set; }
    public string? Error { get; set; }
    public int StatusCode { get; set; }

    public static Result Success(int statusCode = 204) 
        => new Result { IsSuccess = true, StatusCode = statusCode };

    public static Result Failure(string error, int statusCode = 500)
        => new Result { IsSuccess = false, Error = error, StatusCode = statusCode };
}