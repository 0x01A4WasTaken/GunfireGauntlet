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
    public class Collider
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
        public bool collision { get; private set; }
        private bool active = false;
        public bool Active { get { return active; } set { active = value; } }


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

        public bool CheckCollision(Entity.Entity exclude, Entity.Entity e)
        {
            bool value = false;
            float t, b, r, l;
            Collider c = e.Collider;

            t = c.top;
            b = c.bottom;
            r = c.right;
            l = c.left;

            if (e != exclude && c.Active)
            {
                if (top < b && bottom > t && left < r && right > l)
                {
                    value = true;
                    if (!entitiesCollided.Contains(e))
                        entitiesCollided.Add(e);
                }
                else
                {
                    if (entitiesCollided.Contains(e))
                        entitiesCollided.Remove(e);
                    value = false;
                }
            }

            return value;
        }

        public bool CheckCollision(Entity.Entity exclude, List<Entity.Entity> eList)                        // general
        {
            bool value = false;
            float t, b, r, l;
            foreach (Entity.Entity e in eList)
            {
                if (e != exclude && e.Collider.Active)
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

        public bool CheckCollisionTagIsolation(Entity.Entity exclude, List<Entity.Entity> eList, string tagExclude)            // with tag isolation
        {
            bool value = false;
            float t, b, r, l;
            foreach (Entity.Entity e in eList)
            {
                if (e != exclude && e.Collider.Active && e.tag.Equals(tagExclude))
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
        public bool CheckCollisionTagExclusion(Entity.Entity exclude, List<Entity.Entity> eList, string tagExclude)            // with tag isolation
        {
            bool value = false;
            float t, b, r, l;
            foreach (Entity.Entity e in eList)
            {
                if (e != exclude && e.Collider.Active && !e.tag.Equals(tagExclude))
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

        public bool CheckCollisionTagIsolation(Entity.Entity exclude, List<Entity.Entity> eList, int x, int y, int width, int height, string tagInclude)       // with tag isolation
        {
            bool value = false;
            float t, b, r, l;
            foreach (Entity.Entity e in eList)
            {
                if (e != exclude && e.Collider.Active)
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

        public bool CheckCollisionTagExclusion(Entity.Entity exclude, List<Entity.Entity> eList, int x, int y, int width, int height, string tagExclude)       // with tag exclusion
        {
            bool value = false;
            float t, b, r, l;
            foreach (Entity.Entity e in eList)
            {
                if (e != exclude && e.Collider.Active && !e.tag.Equals(tagExclude))
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
    }
}
