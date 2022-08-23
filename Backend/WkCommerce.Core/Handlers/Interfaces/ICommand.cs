using MediatR;

namespace WkCommerce.Core.Handlers.Interfaces
{
    public interface ICommand : IRequest<Result<Unit>>
    {
    }

    public interface ICommand<TResult> : IRequest<Result<TResult>>
    {
    }
}