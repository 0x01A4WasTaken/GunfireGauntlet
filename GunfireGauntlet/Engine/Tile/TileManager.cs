using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GunfireGauntlet.Engine.Tile
{
    static class TileManager
    {
        public static Dictionary<string, TileTemplate> tileTemplates = new Dictionary<string, TileTemplate>();

        public static void SettingTiles()
        {
            // ground 0
            TileTemplate ground = new TileTemplate();
            ground.brush = new SolidBrush(Color.SandyBrown);
            ground.solid = false;
            ground.tile = true;
            ground.type = Tile.Type.None;
            tileTemplates.Add("ground", ground);
            // wall top 
            TileTemplate wallt = new TileTemplate();
            wallt.brush = new SolidBrush(Color.Black);
            wallt.solid = true;
            wallt.tile = true;
            wallt.type = Tile.Type.Top;
            tileTemplates.Add("twall", wallt);
            // wall bottom 
            TileTemplate wallb = new TileTemplate();
            wallb.brush = new SolidBrush(Color.Black);
            wallb.solid = true;
            wallb.tile = true;
            wallb.type = Tile.Type.Bottom;
            tileTemplates.Add("bwall", wallb);
            // wall left 
            TileTemplate walll = new TileTemplate();
            walll.brush = new SolidBrush(Color.Black);
            walll.solid = true;
            walll.tile = true;
            walll.type = Tile.Type.Left;
            tileTemplates.Add("lwall", walll);
            // wall right 
            TileTemplate wallr = new TileTemplate();
            wallr.brush = new SolidBrush(Color.Black);
            wallr.solid = true;
            wallr.tile = true;
            wallr.type = Tile.Type.Right;
            tileTemplates.Add("rwall", wallr);
            // top left corner
            TileTemplate topLeftCorner = new TileTemplate();
            topLeftCorner.brush = new SolidBrush(Color.Black);
            topLeftCorner.solid = true;
            topLeftCorner.tile = true;
            topLeftCorner.type = Tile.Type.TopLeft;
            tileTemplates.Add("tlcorn", topLeftCorner);
            // top right corner
            TileTemplate topRightCorner = new TileTemplate();
            topRightCorner.brush = new SolidBrush(Color.Black);
            topRightCorner.solid = true;
            topRightCorner.tile = true;
            topRightCorner.type = Tile.Type.TopRight;
            tileTemplates.Add("trcorn", topRightCorner);
            // bottom left corner
            TileTemplate bottomLeftCorner = new TileTemplate();
            bottomLeftCorner.brush = new SolidBrush(Color.Black);
            bottomLeftCorner.solid = true;
            bottomLeftCorner.tile = true;
            bottomLeftCorner.type = Tile.Type.BottomLeft;
            tileTemplates.Add("blcorn", bottomLeftCorner);
            // bottom right corner
            TileTemplate bottomRightCorner = new TileTemplate();
            bottomRightCorner.brush = new SolidBrush(Color.Black);
            bottomRightCorner.solid = true;
            bottomRightCorner.tile = true;
            bottomRightCorner.type = Tile.Type.BottomRight;
            tileTemplates.Add("brcorn", bottomRightCorner);
            // full wall 
            TileTemplate wall = new TileTemplate();
            wall.brush = new SolidBrush(Color.SaddleBrown);
            wall.solid = true;
            wall.tile = true;
            wall.type = Tile.Type.Full;
            tileTemplates.Add("wall", wall);
            // no collider wall
            TileTemplate noColWall = new TileTemplate();
            noColWall.brush = new SolidBrush(Color.SaddleBrown);
            noColWall.solid = false;
            noColWall.tile = true;
            noColWall.type = Tile.Type.None;
            tileTemplates.Add("nowall", noColWall);
            // void 
            TileTemplate nothing = new TileTemplate();
            nothing.tile = false;
            nothing.type = Tile.Type.None;
            tileTemplates.Add("void", nothing);
        }
    }

    struct TileTemplate
    {
        public SolidBrush brush;
        public bool solid;
        public bool tile;
        public Tile.Type type;
    }
}
