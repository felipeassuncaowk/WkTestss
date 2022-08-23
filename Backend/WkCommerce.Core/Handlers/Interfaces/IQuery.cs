using MediatR;

namespace WkCommerce.Core.Handlers.Interfaces
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}