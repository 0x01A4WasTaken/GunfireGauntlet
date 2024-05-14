using GunfireGauntlet.Engine.Essentials;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunfireGauntlet.Engine.Entity
{
    internal class Entity : Sprite
    {
        private Vector2 position;

        private bool visible;

        public Entity(Vector2 position, int height, int width, string path) : base(height, width)
        {
            this.position = position;
            base.SetImage(path);
        }

        public Vector2 GetPosition() { return position; }
        public void SetPosition(Vector2 value) { position = value; }
        public void SetPosition(float x, float y) { position = new Vector2(x, y); }

        public void Draw(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            if (GetImage() == null)
                g.DrawRectangle(new Pen(brush), position.GetX(), position.GetY(), GetWidth(), GetHeight());
            else
                g.DrawImage(GetImage(), position.GetX(), position.GetY(), GetWidth(), GetHeight());
        }
    }
}
