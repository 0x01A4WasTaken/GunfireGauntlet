using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace GunfireGauntlet.Engine.Essentials
{
    internal class Position
    {
        private int x;
        private int y;

        public int X { get { return x; } set {  x = value; } }
        public int Y { get { return y; } set { y = value; } }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Reset()
        {
            x = 0;
            y = 0;
        }
    }
}
