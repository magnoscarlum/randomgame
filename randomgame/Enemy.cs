using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomgame
{
    internal class Enemy
    {
        public class enemy : Player
        {
            bool isDead = false;
            double damage;
            public enemy(double hp, double maxHp, int level, bool isDead, double damage) : base(hp, maxHp, level)

            {
                this.isDead = isDead;
                this.damage = damage;
            }
        }
    }
}