using GunfireGauntlet.Engine.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace GunfireGauntlet.Engine.Entity
{
    public class Sprite
    {
        private int height;
        private int width;
        public int Height { get { return height; } 
            set 
            {
                if (value > 0)
                    height = value;
                else
                    height = 1;
            } 
        }
        public int Width { get { return width; } 
            set 
            {
                if (value > 0)
                    width = value;
                else
                    width = 1;
            } 
        }
        private Image image;

        public Sprite(int height, int width) 
        {
            this.height = height;
            this.width = width;
        }

        public void SetImage(string path)
        {
            image = Image.FromFile(Directory.GetCurrentDirectory() + path);
        }

        public void SetImage(Image image)
        {
            this.image = image;
        }

        public Image GetImage() { return image; }
    }
}
