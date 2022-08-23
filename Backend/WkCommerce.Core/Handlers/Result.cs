using MediatR;

namespace WkCommerce.Core.Handlers
{
    [Serializable]
    public class Result
    {
        #region "Constructor"

        protected Result(string failureReason = null)
        {
            FailureReason = failureReason;
        }

        #endregion

        #region "Properties"

        /// <summary>
        ///     Indicates that operation have success or failure.
        /// </summary>
        public bool IsSuccess => FailureReason == null;

        /// <summary>
        ///     Failure description.
        /// </summary>
        public string FailureReason { get; protected set; }

        #endregion

        #region "Methods"

        public static Result<T> Success<T>(T result)
        {
            return new Result<T>(result);
        }

        public static Task<Result<T>> SuccessAsync<T>(T result)
        {
            return Task.FromResult(new Result<T>(result));
        }

        public static Result<Unit> Success()
        {
            return Success(Unit.Value);
        }

        public static Task<Result<Unit>> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public static Result<T> Failure<T>(T result, string failureReason)
        {
            return new Result<T>(result, failureReason);
        }

        public static Result<T> Failure<T>(string failureReason)
        {
            return new Result<T>(default, failureReason);
        }

        public static Task<Result<T>> FailureAsync<T>(T result, string failureReason)
        {
            return Task.FromResult(new Result<T>(result, failureReason));
        }

        public static Result<Unit> Failure(string failureReason)
        {
            return Failure(Unit.Value, failureReason);
        }

        public static Task<Result<Unit>> FailureAsync(string failureReason)
        {
            return Task.FromResult(Failure(Unit.Value, failureReason));
        }

        #endregion
    }

    [Serializable]
    public class Result<T> : Result
    {
        #region "Constructor"

        internal Result(T payload, string failureReason = null) : base(failureReason)
        {
            Payload = payload;
        }

        #endregion

        #region "Properties"

        /// <summary>
        ///     Payload result.
        /// </summary>
        public T Payload { get; private set; }

        #endregion
    }
}