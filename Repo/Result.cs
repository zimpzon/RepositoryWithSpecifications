namespace Results
{
    /// <summary>
    /// Testing how using result types feels compared to exceptions.
    /// </summary>
    public class Result<T>
    {
        public T? Value { get; }
        public string ErrorCode { get; }
        public string ErrorMessage { get; }
        public bool IsSuccess { get; }

        private Result(T? value, string errorCode, string errorMessage, bool isSuccess)
        {
            Value = value;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            IsSuccess = isSuccess;
        }

        public static Result<T> Success(T value) => new(value, string.Empty, string.Empty, isSuccess: true);
        public static Result<T> Fail(string errorCode, string errorMessage) => new(default, errorCode, errorMessage, isSuccess: false);

        public override string ToString()
            => IsSuccess ? $"SUCCESS" :  $"ERROR | ErrorCode: {ErrorCode} | ErrorMessage: {ErrorMessage}";
    }
}
