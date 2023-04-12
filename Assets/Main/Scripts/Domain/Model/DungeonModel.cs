using System.Collections.Generic;
using System.Linq;
using Roguelike.Domain.Data;

namespace Roguelike.Domain.Model
{
    public static class DungeonModel
    {
        public const int LotteryTake = 3;

        public static IEnumerable<Unit> LotteryUnits(Dungeon dungeon, IEnumerable<Unit> units, System.Random random)
        {
            //TODO 抽選ルール
            return units.OrderBy(_ => random.Next()).Take(LotteryTake);
        }

        public static void AddUnit(Team team, Unit newUnit)
        {
            var unit = team.Units.FirstOrDefault(unit => unit.ID == newUnit.ID);
            if (unit != null)
            {
                unit.Level++;
            }
            else
            {
                team.Units.Append(newUnit);
            }
        }

        public static void MoveRoom(Dungeon dungeon, Room room)
        {
            dungeon.CurrentRoom = room;
        }

        public static Dungeon CreateDungeon(IEnumerable<Room> rooms)
        {
            //TODO 生成ルール
            var rootRooms = new List<Room>();
            for (var i = 0; i < 10; ++i)
            {
            }
            return new Dungeon()
            {
                RootRooms = rootRooms,
            };
        }
    }
}