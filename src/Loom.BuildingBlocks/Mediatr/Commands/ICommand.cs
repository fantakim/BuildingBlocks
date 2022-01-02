using MediatR;

namespace Loom.BuildingBlocks.Mediatr.Commands
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<out TResult> : IRequest<TResult>
    {
    }
}
