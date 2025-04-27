using FluentValidation.Results;

namespace SalesApi.Application.Common;

public class HandlerResult<T>
{
    public HandlerResult(bool success, string message, T? data = default, IEnumerable<ValidationFailure>? errors = null)
    {
        Success = success;
        Message = message;
        Data = data;
        _validationFailures = errors;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }
    public IEnumerable<object>? Errors => _validationFailures?.Select(error => new { Error = error.PropertyName, Detail = error.ErrorMessage });
    private IEnumerable<ValidationFailure>? _validationFailures;
}

