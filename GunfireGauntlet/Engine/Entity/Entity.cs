using GunfireGauntlet.Engine.Essentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunfireGauntlet.Engine.Entity
{
    internal class Entity : Sprite
    {
        private Position position;

        private bool visible;

        private string path;
        private int width;
        private int height;

        public Position Position { get { return position; } set { position = value; } }

        public Entity(Position position, int height, int width, string path) : base(height, width)
        {
            this.position = position;
            base.SetImage(path);
        }

        public void Destroy()
        {
            visible = false;
            position = null;
        }
    }
}
