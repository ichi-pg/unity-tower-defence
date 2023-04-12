using System.Collections.Generic;
using System.Linq;
using Roguelike.Domain.Data;

namespace Roguelike.Domain.Model
{
    public static class BattleModel
    {
        public static void Update(Battle battle)
        {
            Update(battle, args => MoveModel.Move(args.unit, args.teammates, args.enemies));
            Update(battle, args => AttackModel.Attack(args.unit, args.teammates, args.enemies));
            battle.Time++;
        }

        private static void Update(Battle battle, System.Action<(Unit unit, IEnumerable<Unit> teammates, IEnumerable<Unit> enemies)> callback)
        {
            foreach (var team in battle.Teams)
            {
                var enemies = battle.Teams
                    .Where(otherTeam => team != otherTeam)
                    .SelectMany(otherTeam => otherTeam.Units);

                foreach (var unit in team.Units)
                {
                    callback((unit, team.Units, enemies));
                }
            }
        }

        public static bool IsFinished(Battle battle)
        {
            return false;
        }
    }
}