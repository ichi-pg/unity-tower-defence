using System.Collections.Generic;

namespace Roguelike.Domain.Data
{
    public class Room
    {
        public IEnumerable<Room> NextRooms;
    }
}