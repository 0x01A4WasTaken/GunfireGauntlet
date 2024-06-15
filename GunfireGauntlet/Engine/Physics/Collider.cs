using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using GunfireGauntlet.Engine.Entity;
using GunfireGauntlet.Engine.Entity.Player;
using GunfireGauntlet.Engine.Essentials;
using GunfireGauntlet.Engine.Tile;

namespace GunfireGauntlet.Engine.Physics
{
    public class Collider
    {
        public List<Entity.Entity> entitiesCollided = new List<Entity.Entity>();
        private Entity.Entity entity;
        public Vector2 entityCollisionVector = new Vector2();
        public float old_x { get; private set; }
        public float old_y { get; private set; }
        public float top { get { return entity.Position.Y; } }
        public float oldTop { get { return old_y; } }
        public float bottom { get { return entity.Position.Y + entity.Height; } }
        public float oldBottom { get { return old_y + entity.Height; } }
        public float right { get { return entity.Position.X + entity.Width; } }
        public float oldRight { get { return old_x + entity.Width; } }
        public float left { get { return entity.Position.X; } }
        public float oldLeft { get { return old_x; } }

        // Collision Bools
        public bool collision { get; private set; }

        private bool active = true;
        private bool solid = true;
        public bool Active { get { return active; } set { active = value; } }           // things will be able to detect collisions 
        public bool Solid { get { return solid; } set { solid = value; } }              // things will not be able to pass through it
        public bool ctop = false;
        public bool cbottom = false;
        public bool cright = false;
        public bool cleft = false;


        public Collider(Entity.Entity parent)
        {
            entity = parent;
        }

        public void SetOldValues(float x, float y)
        {
            old_x = x;
            old_y = y;
        }

        public string CheckCollision(List<Entity.Entity> eList)                        // general
        {
            bool value = false;
            string returnTag = null;
            float t, b, r, l;
            foreach (Entity.Entity e in eList)
            {
                if (e != entity && e.Collider.Active)
                {
                    Collider c = e.Collider;

                    t = c.top;
                    b = c.bottom;
                    r = c.right;
                    l = c.left;

                    if (top <= b && bottom >= t && left <= r && right >= l)
                    {
                        if (!entitiesCollided.Contains(e))
                            entitiesCollided.Add(e);
                        ResolveCollision(e);
                        value = true;
                        returnTag = e.tag;
                    }
                    else
                    {
                        value = false;
                        if (entitiesCollided.Contains(e))
                            entitiesCollided.Remove(e);
                    }
                }
            }
            collision = value;
            return returnTag;
        }

        private void ResolveCollision(Entity.Entity e)                                  // resolves collisions for non tile entities
        {
            if (e.tag == "tile" || !e.Collider.Solid)
                return;

            entityCollisionVector.X = entity.Center.X - e.Center.X;
            entityCollisionVector.Y = entity.Center.Y - e.Center.Y;

            if (Math.Abs(entityCollisionVector.Y) > Math.Abs(entityCollisionVector.X))
            {
                if (entityCollisionVector.Y > 0) // pointing down
                {
                    entity.Position.Y = e.Position.Y + e.Height;
                    ctop = true;
                    cbottom = false;
                }
                else // pointing up
                {
                    entity.Position.Y = e.Position.Y - entity.Height;
                    cbottom = true;
                    ctop = false;
                }
            }
            else
            {
                if (entityCollisionVector.X > 0)
                {
                    entity.Position.X = e.Position.X + e.Width;
                    cright = true;
                    cleft = false;
                }
                else
                {
                    entity.Position.X = e.Position.X - entity.Width;
                    cleft = true;
                    cright = false;
                }
            }
        }

        public void TileCollisionHandler(Tile.Tile.Type type, int row, int col)
        {
            if (type == Tile.Tile.Type.None) return;
            else if (type == Tile.Tile.Type.Top)
                TopCollision(row);
            else if (type == Tile.Tile.Type.Bottom)
                BottomCollision(row);
            else if (type == Tile.Tile.Type.Right)
                RightCollision(col);
            else if (type == Tile.Tile.Type.Left)
                LeftCollision(col);
            else if (type == Tile.Tile.Type.BottomLeft)
            {
                BottomCollision(row);
                LeftCollision(col);
            }
            else if (type == Tile.Tile.Type.BottomRight)
            {
                BottomCollision(row);
                RightCollision(col);
            }
            else if (type == Tile.Tile.Type.TopLeft)
            {
                TopCollision(row);
                LeftCollision(col);
            }
            else if (type == Tile.Tile.Type.TopRight)
            {
                TopCollision(row);
                RightCollision(col);
            }
            else if (type == Tile.Tile.Type.Full)
            {
                if (LeftCollision(col))
                    return;
                if (TopCollision(row))
                    return;
                if (BottomCollision(row))
                    return;
                RightCollision(col);
            }
        }

        public bool BottomCollision(int row)
        {
            if (top - old_y < 0)      // if is moving up
            {
                int bottom = (row + 1) * GameWindow.TILESIZE;

                if ((int)top < bottom && oldTop >= bottom)
                {
                    entity.Velocity.Y = 0;
                    old_y = entity.Position.Y = bottom;
                    return true;
                }
            }
            return false;
        }

        public bool TopCollision(int row)
        {
            if (top - old_y > 0)      // if is moving down
            {
                int top = row * GameWindow.TILESIZE;

                if ((int)bottom > top && oldBottom <= top)
                {
                    entity.Velocity.Y = 0;
                    old_y = entity.Position.Y = top - entity.Height;
                    return true;
                }
            }
            return false;
        }

        public bool RightCollision(int col)
        {
            if (left - old_x < 0)      // if is moving left
            {
                int right = (col + 1) * GameWindow.TILESIZE;

                if ((int)left < right && oldLeft >= right )
                {
                    entity.Velocity.X = 0;
                    old_x = entity.Position.X = right;
                    return true;
                }
            }
            return false;
        }

        public bool LeftCollision(int col)
        {
            if (left - old_x > 0)      // if is moving right
            {
                int left = col * GameWindow.TILESIZE;

                if ((int)right > left && oldRight <= left)
                {
                    entity.Velocity.Y = 0;
                    old_x = entity.Position.X = left - entity.Width;
                    return true;
                }
            }
            return false;
        }

        public void TileCollisionDetection()
        {
            if (entity.Position.X < 0)
                entity.Position.X = 0;                  // not letting player move out of world
            if (entity.Position.Y < 0)
                entity.Position.Y = 0;

            if (entity.Position.X - old_x < 0)          // moving left
            {
                int leftColumn = (int)Math.Floor(left / GameWindow.TILESIZE) ;
                int bottomRow = (int)Math.Floor(bottom / GameWindow.TILESIZE);
                try
                {
                    string tile = GameWindow.map[bottomRow, leftColumn];
                    // check bottom left corner
                    if (TileManager.tileTemplates[tile].tile == true)
                    {
                        TileCollisionHandler(TileManager.tileTemplates[tile].type, bottomRow, leftColumn);
                    }

                    int topRow = (int)Math.Floor(top / GameWindow.TILESIZE);
                    tile = GameWindow.map[topRow, leftColumn];
                    // check top left corner
                    if (TileManager.tileTemplates[tile].tile == true)
                    {
                        TileCollisionHandler(TileManager.tileTemplates[tile].type, topRow, leftColumn);
                    }
                }
                catch { }


            }
            else if (entity.Position.X - old_x > 0)     // moving right
            {
                int rightColumn = (int)Math.Floor(right / GameWindow.TILESIZE   );
                int bottomRow = (int)Math.Floor(bottom / GameWindow.TILESIZE);
                try
                {
                    string tile = GameWindow.map[bottomRow, rightColumn];
                    // check the bottom right corner
                    if (TileManager.tileTemplates[tile].tile == true)
                    {
                        TileCollisionHandler(TileManager.tileTemplates[tile].type, bottomRow, rightColumn);
                    }

                    int topRow = (int)Math.Floor(top / GameWindow.TILESIZE);
                    tile = GameWindow.map[topRow, rightColumn];
                    // check top right corner
                    if (TileManager.tileTemplates[tile].tile == true)
                    {
                        TileCollisionHandler(TileManager.tileTemplates[tile].type, topRow, rightColumn);
                    }
                }
                catch { }
            }
            if (entity.Position.Y - old_y < 0)          // moving up
            {
                int topRow = (int)Math.Floor(top / GameWindow.TILESIZE);
                int leftColumn = (int)Math.Floor(left / GameWindow.TILESIZE);
                try
                {
                    string tile = GameWindow.map[topRow, leftColumn];
                    // check the top left corner
                    if (TileManager.tileTemplates[tile].tile == true)
                    {
                        TileCollisionHandler(TileManager.tileTemplates[tile].type, topRow, leftColumn);
                    }

                    int rightColumn = (int)Math.Floor(right / GameWindow.TILESIZE);
                    tile = GameWindow.map[topRow, rightColumn];
                    // check the top right corner
                    if (TileManager.tileTemplates[tile].tile == true)
                    {
                        TileCollisionHandler(TileManager.tileTemplates[tile].type, topRow, rightColumn);
                    }
                }
                catch { }
            }
            else if (entity.Position.Y - old_y > 0)          // moving down
            {
                int bottomRow = (int)Math.Floor(bottom / GameWindow.TILESIZE);
                int leftColumn = (int)Math.Floor(left / GameWindow.TILESIZE);
                try
                {
                    string tile = GameWindow.map[bottomRow, leftColumn];
                    // check the bottom left corner
                    if (TileManager.tileTemplates[tile].tile == true)
                    {
                        TileCollisionHandler(TileManager.tileTemplates[tile].type, bottomRow, leftColumn);
                    }

                    int rightColumn = (int)Math.Floor(right / GameWindow.TILESIZE);
                    tile = GameWindow.map[bottomRow, rightColumn];
                    // check the bottom right corner
                    if (TileManager.tileTemplates[tile].tile == true)
                    {
                        TileCollisionHandler(TileManager.tileTemplates[tile].type, bottomRow, rightColumn);
                    }
                }
                catch { }
            }
        }
    }
}
