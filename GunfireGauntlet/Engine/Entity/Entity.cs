using GunfireGauntlet.Engine.Essentials;
using GunfireGauntlet.Engine.Physics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GunfireGauntlet.Engine.Entity
{
    public class Entity : Sprite
    {
        static private List<Entity> entityList = new List<Entity>();
        static public List<Entity> entities { get { return entityList; } }

        public string tag { get; private set; }

        private Vector2 position;

        private bool visible = true;

        public int spriteCounter { get; set; }
        public int spriteNumber { get; set; }
        
        private bool animated;

        private Collider col;
        public Collider Collider { get { return col; } set { col = value; } }
        public SolidBrush defaultBrush = new SolidBrush(Color.Black);

        public Entity(Vector2 position, int height, int width, bool animated, string tag) : base(height, width)
        {
            this.position = position;
            this.animated = animated;
            spriteCounter = 0;
            spriteNumber = 0;
            col = new Collider(GetPosition().Y, GetPosition().Y + GetHeight(), GetPosition().X + GetWidth(), GetPosition().X);
            entityList.Add(this);
            this.tag = tag;

        }

        #region getters&setters
        public Vector2 GetPosition() { return position; }
        public void SetPosition(Vector2 value) 
        { 
            position = value;
        }
        public void SetPosition(float x, float y) 
        {
            position = new Vector2(x, y); 
        }

        public Collider GetCollider() { return col; }

        public void UpdateColliderValues() { col.SetValues(position.Y, position.Y + GetHeight(), position.X + GetWidth(), position.X); }
        public void UpdateOldColliderValues() { col.SetOldValues(col.left, col.top); }
        #endregion

        public virtual void Update()
        {
            if (animated)
                spriteCounter++;
        }

        public void ColliderUpdater()
        {
            UpdateOldColliderValues();
            UpdateColliderValues();
        }

        public virtual void Draw(Graphics g)
        {
            if (!visible)
                return;



            if (GetImage() == null)
                g.FillRectangle(defaultBrush, position.X, position.Y, GetWidth(), GetHeight());
            else
                g.DrawImage(GetImage(), position.X, position.Y, GetWidth(), GetHeight());
        }

        public void DrawCollider(Graphics g)
        {
            SolidBrush brushRed = new SolidBrush(Color.FromArgb((byte)100, (byte)255, (byte)0, (byte)0));
            SolidBrush brushGreen = new SolidBrush(Color.FromArgb((byte)100, (byte)0, (byte)255, (byte)0));
            Collider col = GetCollider();
            Rectangle colRect = new Rectangle((int)col.left, (int)col.top, (int)col.right - (int)col.left, (int)col.bottom - (int)col.top);
            Rectangle colRectOld = new Rectangle((int)col.oldx, (int)col.oldy, (int)GetWidth(), (int)GetHeight());
            g.FillRectangle(brushRed, colRect);
            g.FillRectangle(brushGreen, colRectOld);
        }
    }
}
