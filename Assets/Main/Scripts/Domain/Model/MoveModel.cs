using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Roguelike.Domain.Data;

namespace Roguelike.Domain.Model
{
    public static class MoveModel
    {
        public static void Move(Unit mover, IEnumerable<Unit> teammates, IEnumerable<Unit> enemies)
        {
            // if (mover.MoveRoute == null)
            // {
            //     return;
            // }
            // if (mover.MoveTime > mover.MoveParamaters.Max(paramater => paramater.Time))
            // {
            //     return;
            // }
            // if (AttackModel.GetAttackTargets(mover, teammates, enemies).Any())
            // {
            //     return;
            // }
            // var nextPosition = mover.MovePositions[mover.NextPosition];
            // var direction = nextPosition - mover.Position;
            // if (direction.sqrMagnitude < mover.MoveSpeed * mover.MoveSpeed)
            // {
            //     mover.Position = nextPosition;
            //     mover.NextPosition++;
            //     return;
            // }
            // mover.Position += direction.normalized * mover.MoveSpeed;
        }
    }
}