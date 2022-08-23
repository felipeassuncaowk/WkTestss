using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WkCommerce.Core.Handlers;
using WkCommerce.Core.Handlers.Interfaces;

namespace WkCommerce.WebApi.Abstractions;

[ApiController]
[Route("[controller]")]
public abstract class ApiControllerBase : Controller
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<ApiControllerBase> _logger;
        
    protected ApiControllerBase(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _logger = serviceProvider.GetService<ILogger<ApiControllerBase>>();
    }


    protected async Task<IActionResult> ExecuteCommandAsync<TRequest>(TRequest request)
        where TRequest : class, ICommand =>
        await ExecuteAsync<TRequest, Unit>(request);

    protected async Task<IActionResult> ExecuteCommandAsync<TRequest, TResult>(TRequest request)
        where TRequest : class, ICommand<TResult> =>
        await ExecuteAsync<TRequest, TResult>(request);

    protected async Task<IActionResult> ExecuteQueryAsync<TRequest, TResult>()
        where TRequest : class, IQuery<TResult>, new() =>
        await ExecuteAsync<TRequest, TResult>(new TRequest());

    protected async Task<IActionResult> ExecuteQueryAsync<TRequest, TResult>(TRequest request)
        where TRequest : class, IQuery<TResult> =>
        await ExecuteAsync<TRequest, TResult>(request);

    private async Task<IActionResult> ExecuteAsync<TRequest, TResult>(TRequest request)
        where TRequest : class, IRequest<Result<TResult>>
    {
        IActionResult actionResult;

        try
        {
            var validationResult = await Validate<TRequest, TResult>(request);

            if (validationResult.IsSuccess)
            {
                var mediator = _serviceProvider.GetRequiredService<IMediator>();
                var result = await mediator.Send(request);

                if (result.IsSuccess)
                    actionResult = Ok(result);
                else
                    actionResult = BadRequest(result);
            }
            else
            {
                actionResult = BadRequest(validationResult);
            }

        }
        catch (Exception)
        {
            actionResult = StatusCode(StatusCodes.Status500InternalServerError,
                Result.Failure("Erro ao processar a requisição."));
        }

        return actionResult;
    }

    private async Task<Result> Validate<TRequest, TResult>(TRequest request)
        where TRequest : class, IRequest<Result<TResult>>
    {
        var validator = _serviceProvider.GetService<IValidator<TRequest>>();

        if (validator != null)
        {
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new {Field = e.PropertyName, Message = e.ErrorMessage})
                    .ToArray();

                return Result.Failure(new {ValidationErrors = errors}, "Validation Errors");
            }
        }

        return await Result.SuccessAsync();
    }
}