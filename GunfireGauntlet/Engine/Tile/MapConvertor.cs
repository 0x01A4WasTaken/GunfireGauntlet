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

namespace GunfireGauntlet.Engine.Tile
{
    class MapConvertor
    {
        static public void MaptoArray(ref string[,] array)
        {
            try
            {
                int i = 0;
                string data;
                StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + @"\map01.csv");
                while((data = streamReader.ReadLine()) != null)
                {
                    string[] s = data.Split(';');
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
            for(int i = 0; i < GameWindow.ROWS; i++)         // rows 
            {
                for(int j = 0; j < GameWindow.COLUMNS; j++)     // columns
                {
                    if (TileManager.tileTemplates[map[i, j]].tile == true)
                    {
                        Essentials.Vector2 pos = new Essentials.Vector2(j * GameWindow.TILESIZE, i * GameWindow.TILESIZE);
                        Tile e = new Tile(pos, tileSize, tileSize, TileManager.tileTemplates[map[i, j]].type);
                        e.Collider.Solid= TileManager.tileTemplates[map[i, j]].solid;
                        e.defaultBrush = TileManager.tileTemplates[map[i, j]].brush;
                        entities.Add(e);
                    }
                }
            }
        }
    }
}
