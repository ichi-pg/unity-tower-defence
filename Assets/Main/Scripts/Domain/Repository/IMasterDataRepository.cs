using System.Collections.Generic;
using Roguelike.Domain.Data;

namespace Roguelike.Domain.Repository
{
    public interface IMasterDataRepository
    {
        IEnumerable<Unit> Units { get; }
        IEnumerable<Stage> Stages { get; }
    }
}