using GunfireGauntlet.Engine.Entity.Player;
using System;
using System.Drawing;
using System.Windows.Forms;
using GunfireGauntlet.Engine.Essentials;
using GunfireGauntlet.Engine.Tile;
using GunfireGauntlet.Engine.Physics;
using GunfireGauntlet.Engine.Entity;
using System.Collections.Generic;
using GunfireGauntlet.Engine.Entity.Enemies;

namespace GunfireGauntlet
{
    public partial class GameWindow : Form
    {
        private const int ORIGINAL_TILE_SIZE = 16;          // 16x16
        public const int TILESIZE = ORIGINAL_TILE_SIZE * 3; 
        private int tileColumns = 25;                       // number of columns
        private int tileRows = 25;                          // number of rows

        private string title = "Gunfire Gauntlet";          // window title

        // world
        public static string[,] map = new string[20, 20];
        public const int ROWS = 20;
        public const int COLUMNS = 20;
        Vector2 drawOffset = new Vector2();                 // for the camera to move around the map there needs to be an offset

        public static Player player = new Player(new Vector2(200, 200), 81, 48);

        private List<Entity> sEntities = new List<Entity>();
        private List<Enemy> enemies = new List<Enemy>();

        public GameWindow()
        {

            DoubleBuffered = true;

            TileManager.SettingTiles();
            MapConvertor.MaptoArray(ref map);
            MapConvertor.MapLoader(ref sEntities, map, TILESIZE);

            Enemy e0 = new Enemy(new Vector2(200, 200), 50, 50, false);
            e0.Collider.Solid = true;
            Enemy e1 = new Enemy(new Vector2(200, 500), 50, 50, false);
            e1.Collider.Solid = true;
            enemies.Add(e0);
            enemies.Add(e1);

            InitializeComponent();      // this stays at the end
        }

        private void OnLoad(object sender, EventArgs e)
        {
            Text = title;
            Size = new Size(tileColumns * TILESIZE, tileRows * TILESIZE);
        }

        private void GameLoop(object sender, EventArgs e) // Update
        {
            player.Update();

            drawOffset.X = Screen.PrimaryScreen.Bounds.Width / 2 - player.Center.X;
            drawOffset.Y = Screen.PrimaryScreen.Bounds.Height / 2 - player.Center.Y;

            foreach(Enemy _e in enemies)
            {
                _e.Update();
            }

            lblDebug.Text = player.health.ToString();

            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e) // Draw
        {
            Graphics g = e.Graphics;

            foreach(Entity _e in sEntities)
            {
                _e.Draw(g, drawOffset);
            }

            foreach (Enemy _e in enemies)
            {
                _e.Draw(g, drawOffset);
            }

            foreach(Entity _e in Entity.entities)
            {
                if (_e.tag == "bullet")
                    _e.Draw(g, drawOffset);
            }

            player.Draw(g);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            KeyHandler.KeyDetectionDown(e);
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            KeyHandler.KeyDetectionUp(e);
        }
    }
}
