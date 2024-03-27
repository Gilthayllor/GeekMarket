namespace GeekMarket.Shared.Reponse
{
    public class Result
    {
        public bool IsSuccess { get; init; }
        public string? Error { get; init; }
        
        public static Result Success() => new Result { IsSuccess = true };
        public static Result Failure(string error) => new Result { IsSuccess = false, Error = error };
    }

    public class Result<T> : Result
    {
        public T? Data { get; init; }
        
        public static Result<T> Success<T>(T data) => new Result<T> { IsSuccess = true, Data = data };
    }
}
