using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Roguelike.Domain.Data;

namespace Roguelike.Domain.Model
{
    public static class AttackModel
    {
        private static IEnumerable<Unit> GetAttackTargets<T>(Unit attacker, IEnumerable<Unit> targets, System.Func<(Unit unit, float sqrMagnitude), T> orderBy)
        {
            var attackRange = attacker.AttackRange * attacker.AttackRange;
            return targets
                .Select(unit => (unit, (unit.Position - attacker.Position).sqrMagnitude))
                .Where(target => target.sqrMagnitude <= attackRange)
                .OrderBy(orderBy)
                .Take(attacker.AttackCount)
                .Select(target => target.unit);
        }

        public static IEnumerable<Unit> GetAttackTargets(Unit attacker, IEnumerable<Unit> teammates, IEnumerable<Unit> enemies)
        {
            switch (attacker.Role)
            {
                case Role.Attacker:
                    return GetAttackTargets(attacker, enemies, target => target.sqrMagnitude);
                case Role.Healer:
                    return GetAttackTargets(attacker, teammates, target => target.unit.HP - target.unit.MaxHP);
                case Role.Buffer:
                    return GetAttackTargets(attacker, teammates.Where(unit => unit.Role == Role.Attacker), target => target.unit.Buff);
                default:
                    return new Unit[] { };
            }
        }

        private static void Attack(Unit attacker, Unit target)
        {
            switch (attacker.Role)
            {
                case Role.Attacker:
                    var damage = System.Math.Max(0, attacker.ATK + attacker.Buff - target.DEF);
                    target.HP = System.Math.Max(0, target.HP - damage);
                    break;
                case Role.Healer:
                    target.HP = System.Math.Min(target.MaxHP, target.HP + attacker.ATK);
                    break;
                case Role.Buffer:
                    target.Buff = target.ATK;
                    break;
            }
        }

        public static void Attack(Unit attacker, IEnumerable<Unit> teammates, IEnumerable<Unit> enemies)
        {
            if (attacker.CoolTime > 0)
            {
                attacker.CoolTime--;
                return;
            }
            var targets = GetAttackTargets(attacker, teammates, enemies);
            if (!targets.Any())
            {
                return;
            }
            foreach (var target in targets)
            {
                Attack(attacker, target);
            }
            attacker.CoolTime = attacker.MaxCoolTime;
        }
    }
}