﻿using GunfireGauntlet.Engine.Essentials;
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

        public Sprite(int height, int width) 
        {
            this.height = height;
            this.width = width;
        }

        public virtual void SetImage(string path)
        {
            image = Image.FromFile(Directory.GetCurrentDirectory() + path);
        }

        public Image GetImage() { return image; }
        public int GetHeight() { return height; }
        public int GetWidth() { return width; }
        public void SetHeight(int value) { height = value; }
        public void SetWidth(int value) { width = value; }

    }
}
