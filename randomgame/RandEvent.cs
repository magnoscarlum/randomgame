using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomgame
{
    internal class RandEvent
    {
        public ConsoleColor colour;
        public string desc;
        public RandEvent(ConsoleColor colour, string desc)
            {
            this.colour = colour;
            this.desc = desc;
            }
    }
}
