﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GunfireGauntlet.Engine.Tile
{
    class MapConvertor
    {
        static public void MaptoArray(ref int[,] array)
        {
            try
            {
                int i = 0;
                string data;
                StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + @"\map01.txt");
                while((data = streamReader.ReadLine()) != null)
                {
                    int j = 0;
                    string[] lineSplit = data.Split(' ');
                    foreach(string s in lineSplit)
                    {

                        int value = int.Parse(s);
                        array[i, j] = value;
                        j++;
                    }
                    i++;
                }
                streamReader.Close();
            }
            catch
            {
                MessageBox.Show("Unable to load map");
            }
        }

        static public void MapLoader(ref List<Entity.Entity> entities, int[,] map, int tileSize)
        {
            for(int i = 0; i < 30; i++)         // y
            {
                for(int j = 0; j < 30; j++)     // x
                {
                    if (map[i, j] == 1)
                    {
                        Entity.Entity e = new Entity.Entity(new Essentials.Vector2(j * tileSize, i * tileSize), tileSize, tileSize, false, "tile");
                        e.Collider.Active = true;
                        entities.Add(e);
                    }
                    if (map[i, j] == 0)
                    {
                        Entity.Entity e = new Entity.Entity(new Essentials.Vector2(j * tileSize, i * tileSize), tileSize, tileSize, false, "tile");
                        e.defaultBrush = new SolidBrush(Color.FromArgb((byte)100, (byte)117, (byte)32, (byte)4));
                        entities.Add(e);
                    }
                    if (map[i, j] == 2)
                    {
                        Entity.Entity e = new Entity.Entity(new Essentials.Vector2(j * tileSize, i * tileSize), tileSize, tileSize, false, "tile");
                        e.defaultBrush = new SolidBrush(Color.FromArgb((byte)100, (byte)4, (byte)130, (byte)200));
                        entities.Add(e);
                    }
                }
            }
        }
    }
}
