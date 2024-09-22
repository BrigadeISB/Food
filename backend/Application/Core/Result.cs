namespace Application.Core
{
    public class Result<T>
    {
        public T? Value { get; set; }
        public Exception? Error { get; set; } 
        public bool IsSuccess => Error is null;

        public static Result<T> Success(T value) => new Result<T> { Value = value, Error = null};
        public static Result<T> Failure(Exception exception) => new Result<T> { Value = default, Error = exception };
    }
}
