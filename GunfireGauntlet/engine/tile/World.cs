using GunfireGauntlet.Engine.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunfireGauntlet.Engine.Tile
{
    public static class World
    {
        public static string[,] map = new string[20, 20];
        public static string[,] mapOverlay = new string[20, 20];
        public const int ROWS = 20;
        public const int COLUMNS = 20;
        public static bool mapGenerated = false;

        public static void GenerateMap(List<Entity.Entity> entities)
        {
            if (mapGenerated)
                return;
            MapConvertor.MaptoArray(ref map, "map01.csv");
            MapConvertor.MapLoader(ref entities, map, GameWindow.TILESIZE);
            MapConvertor.MaptoArray(ref mapOverlay, "map01_overlay.csv");
            MapConvertor.MapLoader(ref entities, mapOverlay, GameWindow.TILESIZE);
            mapGenerated = true;
        }

    }
}
