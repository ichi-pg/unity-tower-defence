using System.Collections.Generic;

namespace Roguelike.Domain.Data
{
    public class Dungeon
    {
        public IEnumerable<Room> RootRooms;
        public Room CurrentRoom;
    }
}