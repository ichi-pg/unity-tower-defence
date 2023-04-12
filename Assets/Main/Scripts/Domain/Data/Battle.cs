using System.Collections.Generic;

namespace Roguelike.Domain.Data
{
    public class Battle
    {
        public IEnumerable<Team> Teams;
        public Stage Stage;
        public int Time;
    }
}