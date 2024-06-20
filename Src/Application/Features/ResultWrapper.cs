using FluentValidation.Results;
using MediatR;

namespace Application.Features
{
    public class ResultWrapperBase
    {
        public ResultWrapperStatus Status { get; protected set; }
    }


    public class ResultWrapper<T> : ResultWrapperBase, IRequest
    {
        public ResultWrapper() { }

        /// <summary>
        /// Wrap a success result.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static ResultWrapper<T> Ok(T result)
        {
            var rc = new ResultWrapper<T>()
            {
                Status = ResultWrapperStatus.Success,
                Result = result,
                Title = "Success"
            };

            return rc;
        }

        /// <summary>
        /// Wrap a NotFound result.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResultWrapper<T> NotFound(string message)
        {
            var rc = new ResultWrapper<T>()
            {
                Status = ResultWrapperStatus.NotFound,
                Message = new string[] { message },
                Title = "Not Found",
                Detail = message
            };

            return rc;
        }

        /// <summary>
        /// Wrap a BadRequest result
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResultWrapper<T> BadRequest(string message)
        {
            var rc = new ResultWrapper<T>()
            {
                Status = ResultWrapperStatus.BadRequest,
                Message = new string[] { message },
                Title = "Bad Request",
                Detail = message
            };

            return rc;
        }

        /// <summary>
        /// Wrap a ValidationFailures result.
        /// </summary>
        /// <param name="failures"></param>
        /// <returns></returns>
        public static ResultWrapper<T> ValidationFailure(IList<ValidationFailure> failures)
        {
            var rc = new ResultWrapper<T>()
            {
                Status = ResultWrapperStatus.ValidationErrors,
                Message = failures.Select(f => f.ErrorMessage)
                    .ToList(),
                ValidationFailures = failures,
                Title = "Validation Error"
            };

            return rc;
        }

        public static ResultWrapper<T> Forbidden(string? message = default)
        {
            var rc = new ResultWrapper<T>()
            {
                Status = ResultWrapperStatus.Forbidden,
                Message = new string[] { message ?? string.Empty },
                Title = "Forbidden",
                Detail = message
            };

            return rc;
        }

        public static ResultWrapper<T> Forbidden(string message, string detail)
        {
            var rc = new ResultWrapper<T>()
            {
                Status = ResultWrapperStatus.Forbidden,
                Message = new string[] { message },
                Title = "Forbidden",
                Detail = detail
            };

            return rc;
        }


        public static ResultWrapper<T> DuplicateKeyError(string? message = default)
        {
            var rc = new ResultWrapper<T>()
            {
                Status = ResultWrapperStatus.DuplicateKeyError,
                Message = new string[] { message ?? string.Empty },
                Title = "Duplicate",
                Detail = message
            };

            return rc;
        }
        
        public static ResultWrapper<T> InternalError(string? message = default)
        {
            var rc = new ResultWrapper<T>()
            {
                Status = ResultWrapperStatus.InternalError,
                Message = new string[] { message ?? string.Empty },
                Title = "Inernal Server Error",
                Detail = message
            };

            return rc;
        }

        public T? Result { get; private init; }
        public IList<string>? Message { get; private init; }
        public string? Title { get; private init; }
        public string? Detail { get; private init; }
        public IList<FluentValidation.Results.ValidationFailure>? ValidationFailures { get; private init; }

    }

    public enum ResultWrapperStatus
    {
        Success = 200,
        NotFound = 404,
        ValidationErrors = 403,
        BadRequest = 400,
        Forbidden = 401,
        DuplicateKeyError = 409,
        InternalError = 500
    }
}


