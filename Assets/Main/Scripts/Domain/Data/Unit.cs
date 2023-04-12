using UnityEngine;

namespace Roguelike.Domain.Data
{
    public class Unit
    {
        public int ID;
        public string Name;
        public int Level;
        public int HP;
        public int MaxHP;
        public int ATK;
        public int DEF;
        public int Buff;
        public int CoolTime;
        public int MaxCoolTime;
        public int AttackCount;
        public float AttackRange;
        public float MoveSpeed;
        public Role Role;
        public Element Element;
        public Vector2 Position;
    }
}