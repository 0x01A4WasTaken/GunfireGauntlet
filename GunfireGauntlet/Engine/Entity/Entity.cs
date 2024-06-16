using GunfireGauntlet.Engine.Helper;
using GunfireGauntlet.Engine.Physics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace GunfireGauntlet.Engine.Entity
{
    public class Entity : Sprite
    {
        static private List<Entity> entityList = new List<Entity>();
        static public List<Entity> entities { get { return entityList; } }

        public string Tag { get; private set; }

        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        private Vector2 velocity = new Vector2(0,0);
        public Vector2 Velocity { get { return velocity; } set { velocity = value; } } 

        private bool visible = true;
        public Vector2 Center { get { return new Vector2(position.X + Width / 2, position.Y + Height / 2); } }

        public int spriteCounter { get; set; }
        public int spriteNumber { get; set; }
        
        private bool animated;

        private Collider col;
        public Collider Collider { get { return col; } set { col = value; } }
        public SolidBrush defaultBrush = new SolidBrush(System.Drawing.Color.Black);

        public Entity(Vector2 position, int height, int width, bool animated, string tag) : base(height, width)
        {
            this.position = position;
            this.animated = animated;
            spriteCounter = 0;
            spriteNumber = 0;
            col = new Collider(this);
            entityList.Add(this);
            this.Tag = tag.ToLower();
        }

        public void SetTag(string value)
        {
            if (value != Tag || string.IsNullOrEmpty(value))
                Tag = value;
        }

        public virtual void Update()
        {
            if (!animated)
                return;

            spriteCounter++;
            
            if (spriteCounter > 6)
            {
                switch (spriteNumber)
                {
                    case 0:
                        {
                            spriteNumber = 1;
                            break;
                        }
                    case 1:
                        {
                            spriteNumber = 2;
                            break;
                        }
                    case 2:
                        {
                            spriteNumber = 3;
                            break;
                        }
                    case 3:
                        {
                            spriteNumber = 0;
                            break;
                        }
                }
                spriteCounter = 0;
            }
        }

        public virtual void Draw(Graphics g)
        {
            if (!visible)
                return;

            if (GetImage() == null)
                g.FillRectangle(defaultBrush, position.X, position.Y, Width, Height);
            else
                g.DrawImage(GetImage(), position.X, position.Y, Width, Height);
        }
        
        public virtual void Draw(Graphics g, Vector2 offset)
        {
            if (!visible)
                return;

            Vector2 spriteOffset = Vector2.Add(offset, position);

            if (GetImage() == null)
                g.FillRectangle(defaultBrush, spriteOffset.X, spriteOffset.Y, Width, Height);
            else
                g.DrawImage(GetImage(), spriteOffset.X, spriteOffset.Y, Width, Height);
        }

        public void DrawCollider(Graphics g)
        {
            SolidBrush brushRed = new SolidBrush(System.Drawing.Color.FromArgb((byte)100, (byte)255, (byte)0, (byte)0));
            SolidBrush brushGreen = new SolidBrush(System.Drawing.Color.FromArgb((byte)100, (byte)0, (byte)255, (byte)0));
            Rectangle colRect = new Rectangle((int)col.left, (int)col.top, (int)col.right - (int)col.left, (int)col.bottom - (int)col.top);
            Rectangle colRectOld = new Rectangle((int)col.old_x, (int)col.old_y, (int)Width, (int)Height);
            g.FillRectangle(brushRed, colRect);
            g.FillRectangle(brushGreen, colRectOld);
        }

        public virtual void Remove()
        {
            entities.Remove(this);
        }
    }
}
