using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace GunfireGauntlet.Engine.Essentials
{
    internal class Vector2
    {
        private float x;
        private float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float GetX() {  return x; }
        public float GetY() { return y; }
        public void SetX(float x) { this.x = x; }
        public void SetY(float y) { this.y = y; }

        public Vector2 Zero()
        {
            Vector2 zero = new Vector2(0, 0);
            return zero;
        }
    }
}
