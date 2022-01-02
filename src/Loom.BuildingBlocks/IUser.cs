using System.Security.Claims;

namespace Loom.BuildingBlocks
{
    public interface IUser
    {
        string Id { get; }
        string Name { get; }
        IEnumerable<Claim> Claims { get; }
    }
}
