using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using GunfireGauntlet.Engine.Helper;

namespace GunfireGauntlet.Engine.Tile
{
    class MapConvertor
    {
        static public void MaptoArray(ref string[,] array, string filePath)
        {
            try
            {
                int i = 0;
                string data;
                StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + @"\" + filePath);
                while((data = streamReader.ReadLine()) != null)
                {
                    string[] s = data.Split(',');
                    for(int j = 0; j < s.Length; j++)
                    {
                        array[i, j] = s[j];
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

        static public void MapLoader(ref List<Entity.Entity> entities, string[,] map, int tileSize)
        {
            for(int i = 0; i < World.ROWS; i++)         // rows 
            {
                for(int j = 0; j < World.COLUMNS; j++)     // columns
                {
                    if (TileManager.tileTemplates[map[i, j]].tile == true)
                    {
                        Vector2 pos = new Vector2(j * GameWindow.TILESIZE, i * GameWindow.TILESIZE);
                        Tile e = new Tile(pos, tileSize, tileSize, TileManager.tileTemplates[map[i, j]].type, TileManager.tileTemplates[map[i,j]].overlay);
                        e.Collider.Solid = TileManager.tileTemplates[map[i, j]].solid;
                        try { e.SetImage(TileManager.tileTemplates[map[i,j]].image); } 
                        catch { e.defaultBrush = TileManager.tileTemplates[map[i, j]].brush; }
                        entities.Add(e);
                    }
                }
            }
        }
    }
}
