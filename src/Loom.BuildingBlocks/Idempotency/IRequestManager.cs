namespace Loom.BuildingBlocks.Idempotency
{
    public interface IRequestManager
    {
        Task<bool> IsRegistered(Guid id, CancellationToken cancellationToken = default(CancellationToken));

        Task Register(Guid id, CancellationToken cancellationToken = default(CancellationToken));
    }
}
