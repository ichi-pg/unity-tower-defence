using System.Collections.Generic;

namespace Roguelike.Domain.Data
{
    public class Stage
    {
        public IEnumerable<Tile> Tiles;
        public IEnumerable<Spawner> Spawners;
    }
}