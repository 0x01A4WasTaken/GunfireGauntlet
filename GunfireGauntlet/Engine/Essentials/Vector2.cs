using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace GunfireGauntlet.Engine.Essentials
{
    public class Vector2
    {
        private float x;
        private float y;
        public float X { get { return x; } set { x = value; } }
        public float Y { get { return y; } set { y = value; } }

        public float Magnitude { get { return (float)Math.Sqrt(Y * Y + X * X); } }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2()
        {
            this.x = 0;
            this.y = 0;
        }

        static public Vector2 Zero()
        {
            Vector2 zero = new Vector2(0, 0);
            return zero;
        }
        static public Vector2 Add(Vector2 value1, Vector2 value2)
        {
            float newx = value1.X + value2.X;
            float newy = value1.Y + value2.Y;
            return new Vector2(newx, newy);
        }

        public string ToString()
        {
            return x + "," + y;
        }
    }
}
