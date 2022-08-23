using MediatR;

namespace WkCommerce.Core.Handlers.Interfaces
{
    public interface IQueryHandler<in TRequest, TResponse> : IRequestHandler<TRequest, Result<TResponse>>
        where TRequest : IRequest<Result<TResponse>>
    {
    }
}