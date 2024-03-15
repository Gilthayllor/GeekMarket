using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GeekMarket.Shared.Reponse
{
    public class Result
    {
        protected Result()
        {
            Error = string.Empty;
            IsSuccess = true;
        }

        protected Result(bool isSuccess, string error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;

        public string Error { get; }

        public static Result Success() => new();

        public static Result Failure(string error) => new(false, error);
    }

    public class Result<T> : Result
    {
        public T Data { get; init; }

        public Result(T data) : base()
        {
            Data = data;
        }

        public static Result<T> Success(T data) => new(data);
    }
}
