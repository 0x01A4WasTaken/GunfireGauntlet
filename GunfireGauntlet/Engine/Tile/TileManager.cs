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
            // floor 1 
            TileTemplate floor_1 = new TileTemplate();
            floor_1.brush = new SolidBrush(Color.SandyBrown);
            floor_1.image = Properties.Resources.floor_1;
            floor_1.solid = false;
            floor_1.tile = true;
            floor_1.type = Tile.Type.None;
            try { tileTemplates.Add("floor_1", floor_1); }
            catch { MessageBox.Show("ahhhhh"); }

            TileTemplate floor_2 = new TileTemplate();
            floor_2.brush = new SolidBrush(Color.SandyBrown);
            floor_2.image = Properties.Resources.floor_2;
            floor_2.solid = false;
            floor_2.tile = true;
            floor_2.type = Tile.Type.None;
            try { tileTemplates.Add("floor_2", floor_2); }
            catch { }

            TileTemplate floor_3 = new TileTemplate();
            floor_3.brush = new SolidBrush(Color.SandyBrown);
            floor_3.image = Properties.Resources.floor_3;
            floor_3.solid = false;
            floor_3.tile = true;
            floor_3.type = Tile.Type.None;
            try { tileTemplates.Add("floor_3", floor_3); }
            catch { }

            TileTemplate floor_4 = new TileTemplate();
            floor_4.brush = new SolidBrush(Color.SandyBrown);
            floor_4.image = Properties.Resources.floor_4;
            floor_4.solid = false;
            floor_4.tile = true;
            floor_4.type = Tile.Type.None;
            try { tileTemplates.Add("floor_4", floor_4); }
            catch { }

            TileTemplate floor_5 = new TileTemplate();
            floor_5.brush = new SolidBrush(Color.SandyBrown);
            floor_5.image = Properties.Resources.floor_5;
            floor_5.solid = false;
            floor_5.tile = true;
            floor_5.type = Tile.Type.None;
            try { tileTemplates.Add("floor_5", floor_5); }
            catch { }

            TileTemplate floor_6 = new TileTemplate();
            floor_6.brush = new SolidBrush(Color.SandyBrown);
            floor_6.image = Properties.Resources.floor_6;
            floor_6.solid = false;
            floor_6.tile = true;
            floor_6.type = Tile.Type.None;
            try { tileTemplates.Add("floor_6", floor_6); }
            catch { }

            TileTemplate floor_7 = new TileTemplate();
            floor_7.brush = new SolidBrush(Color.SandyBrown);
            floor_7.image = Properties.Resources.floor_7;
            floor_7.solid = false;
            floor_7.tile = true;
            floor_7.type = Tile.Type.None;
            try { tileTemplates.Add("floor_7", floor_7); }
            catch { }

            TileTemplate floor_8 = new TileTemplate();
            floor_8.brush = new SolidBrush(Color.SandyBrown);
            floor_8.image = Properties.Resources.floor_8;
            floor_8.solid = false;
            floor_8.tile = true;
            floor_8.type = Tile.Type.None;
            try { tileTemplates.Add("floor_8", floor_8); }
            catch { }

            TileTemplate wall_outer_top_left = new TileTemplate();
            wall_outer_top_left.brush = new SolidBrush(Color.SandyBrown);
            wall_outer_top_left.image = Properties.Resources.wall_outer_top_left;
            wall_outer_top_left.solid = false;
            wall_outer_top_left.tile = true;
            wall_outer_top_left.type = Tile.Type.None;
            try { tileTemplates.Add("wall_outer_top_left", wall_outer_top_left); }
            catch { }

            TileTemplate wall_outer_top_right= new TileTemplate();
            wall_outer_top_right.brush = new SolidBrush(Color.SandyBrown);
            wall_outer_top_right.image = Properties.Resources.wall_outer_top_right;
            wall_outer_top_right.solid = false;
            wall_outer_top_right.tile = true;
            wall_outer_top_right.type = Tile.Type.None;
            try { tileTemplates.Add("wall_outer_top_right", wall_outer_top_right); }
            catch { }

            TileTemplate wall_outer_mid_left = new TileTemplate();
            wall_outer_mid_left.brush = new SolidBrush(Color.SandyBrown);
            wall_outer_mid_left.image = Properties.Resources.wall_outer_mid_left;
            wall_outer_mid_left.solid = false;
            wall_outer_mid_left.tile = true;
            wall_outer_mid_left.type = Tile.Type.Right;
            try { tileTemplates.Add("wall_outer_mid_left", wall_outer_mid_left); }
            catch { }

            TileTemplate wall_outer_mid_right = new TileTemplate();
            wall_outer_mid_right.brush = new SolidBrush(Color.SandyBrown);
            wall_outer_mid_right.image = Properties.Resources.wall_outer_mid_right;
            wall_outer_mid_right.solid = false;
            wall_outer_mid_right.tile = true;
            wall_outer_mid_right.type = Tile.Type.Left;
            try { tileTemplates.Add("wall_outer_mid_right", wall_outer_mid_right); }
            catch { }

            TileTemplate wall_top_mid = new TileTemplate();
            wall_top_mid.brush = new SolidBrush(Color.SandyBrown);
            wall_top_mid.image = Properties.Resources.wall_top_mid;
            wall_top_mid.solid = false;
            wall_top_mid.tile = true;
            wall_top_mid.type = Tile.Type.None;
            try { tileTemplates.Add("wall_top_mid", wall_top_mid); }
            catch { }

            TileTemplate wall_mid_top = new TileTemplate();
            wall_mid_top.brush = new SolidBrush(Color.SandyBrown);
            wall_mid_top.image = Properties.Resources.wall_mid;
            wall_mid_top.solid = true;
            wall_mid_top.tile = true;
            wall_mid_top.type = Tile.Type.Bottom;
            try { tileTemplates.Add("wall_mid_top", wall_mid_top); }
            catch { }

            TileTemplate wall_mid_bottom = new TileTemplate();
            wall_mid_bottom.brush = new SolidBrush(Color.SandyBrown);
            wall_mid_bottom.image = Properties.Resources.wall_mid;
            wall_mid_bottom.solid = true;
            wall_mid_bottom.tile = true;
            wall_mid_bottom.type = Tile.Type.Top;
            try { tileTemplates.Add("wall_mid_bottom", wall_mid_bottom); }
            catch { }

            TileTemplate wall_outer_front_left = new TileTemplate();
            wall_outer_front_left.brush = new SolidBrush(Color.SandyBrown);
            wall_outer_front_left.image = Properties.Resources.wall_outer_front_left;
            wall_outer_front_left.solid = true;
            wall_outer_front_left.tile = true;
            wall_outer_front_left.type = Tile.Type.Right;
            try { tileTemplates.Add("wall_outer_front_left", wall_outer_front_left); }
            catch { }

            TileTemplate wall_outer_front_right = new TileTemplate();
            wall_outer_front_right.brush = new SolidBrush(Color.SandyBrown);
            wall_outer_front_right.image = Properties.Resources.wall_outer_front_right;
            wall_outer_front_right.solid = true;
            wall_outer_front_right.tile = true;
            wall_outer_front_right.type = Tile.Type.Left;
            try { tileTemplates.Add("wall_outer_front_right", wall_outer_front_right); }
            catch { }

            TileTemplate nothing = new TileTemplate();
            nothing.tile = false;
            try { tileTemplates.Add("void", nothing); }
            catch { }
        }
    }

    struct TileTemplate
    {
        public SolidBrush brush;
        public Image image;
        public bool solid;
        public bool tile;
        public Tile.Type type;
    }
}
