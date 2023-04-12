using System.Collections.Generic;
using Roguelike.Domain.Data;
using Roguelike.Domain.Repository;

namespace Roguelike.Infrastructure.Repository
{
    public class MasterDataRepository : IMasterDataRepository
    {
        public IEnumerable<Unit> Units => new List<Unit>();
        public IEnumerable<Stage> Stages => new List<Stage>();
    }
}