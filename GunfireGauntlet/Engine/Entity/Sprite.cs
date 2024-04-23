using GunfireGauntlet.Engine.Essentials;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace GunfireGauntlet.Engine.Entity
{
    internal class Sprite
    {
        private int height;
        private int width;
        private Image image;

        public int Height { get { return height; } set { height = value; } }
        public int Width { get { return width; } set { width = value; } }

        public Sprite(int height, int width) 
        {
            this.height = height;
            this.width = width;
        }

        public virtual void SetImage(string path)
        {
            image = Image.FromFile(Directory.GetCurrentDirectory() + path);
        }

        public Image GetImage () { return image; }

    }
}
