using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using GunfireGauntlet.Engine.Entity;
using GunfireGauntlet.Engine.Entity.Player;

namespace GunfireGauntlet.Engine.Physics
{
    internal class Collider
    {
        public List<Entity.Entity> entitiesCollided = new List<Entity.Entity>();
        public float top { get; private set; }
        public float bottom { get; private set; }
        public float right { get; private set; }
        public float left { get; private set; }
        public float oldTop { get; private set; }
        public float oldBottom { get; private set; }
        public float oldRight { get; private set; }
        public float oldLeft { get; private set; }
        public float oldx { get; private set; }
        public float oldy { get; private set; }

        // Collision Bools
        public bool topCollision { get; private set; }
        public bool bottomCollision { get; private set; }
        public bool rightCollision { get; private set; }
        public bool leftCollision { get; private set; }
        public bool collision { get; private set; }


        public Collider(float t, float b, float r, float l)
        {
            SetValues(t, b, r, l);
        }

        public void SetValues(float t, float b, float r, float l)
        {
            top = t;
            bottom = b;
            right = r;
            left = l;
        }
        
        public void SetOldValues(float x, float y)
        {
            oldx = x;
            oldy = y;
        }

        public bool CheckCollision(Collider c)
        {
            float t, b, r, l;
            t = c.top;
            b = c.bottom;
            r = c.right;
            l = c.left;

            if (top < b && bottom > t && left < r && right > l)
            {
                collision = true;
            }
            else
                collision = false;
            return collision;
        }

        public bool CheckCollision(List<Collider> colList)
        {
            float t, b, r, l;
            foreach (Collider e in colList)
            {
                t = e.top;
                b = e.bottom;
                r = e.right;
                l = e.left;

                if (top < b && bottom > t && left < r && right > l)
                {
                    collision = true;
                    break;
                }
                else
                    collision = false;
            }
            return collision;
        }

        public bool CheckCollision(Entity.Entity exclude, List<Entity.Entity> eList)
        {
            bool value = false;
            float t, b, r, l;
            foreach (Entity.Entity e in eList)
            {
                if (e != exclude)
                {

                    Collider c = e.GetCollider();

                    t = c.top;
                    b = c.bottom;
                    r = c.right;
                    l = c.left;

                    if (top < b && bottom > t && left < r && right > l)
                    {
                        value = true;
                        if (!entitiesCollided.Contains(e))
                            entitiesCollided.Add(e);
                        break;
                    }
                    else
                    {
                        if (entitiesCollided.Contains(e))
                            entitiesCollided.Remove(e);
                        value = false;
                    }
                }
            }
            return value;
        }

        public bool CheckCollision(Entity.Entity exclude, List<Entity.Entity> eList, int x, int y, int width, int height)
        {
            bool value = false;
            float t, b, r, l;
            foreach (Entity.Entity e in eList)
            {
                if (e != exclude)
                {

                    Collider c = e.GetCollider();

                    t = c.top;
                    b = c.bottom;
                    r = c.right;
                    l = c.left;

                    if (y < b && y + height > t && x < r && x + width > l)
                    {
                        value = true;
                        return value;
                    }
                    else
                    {
                        value = false;
                    }
                }
            }
            return value;
        }

        public bool BottomCollision(List<Entity.Entity> eList)
        {
            bool value = false;
            foreach(Entity.Entity e in eList)
            {
                Collider col = e.Collider;
                if (bottom > col.top && oldBottom <= col.top)
                {
                    bottomCollision = true;
                    return true;
                }
                else
                    value = false;
            }
            bottomCollision = value;
            return value;
        }

        public bool RightCollision(Entity.Entity exclude, List<Entity.Entity> eList)
        {
            bool value = false;
            foreach(Entity.Entity e in eList)
            {
                if (e != exclude)
                {
                    Collider col = e.Collider;
                    if (right > col.left && left < col.right - 64 / 2 && bottom > col.top)
                    {
                        return true;
                    }
                    else
                        value = false;
                    }
            }
            return value;
        }
    }
}
