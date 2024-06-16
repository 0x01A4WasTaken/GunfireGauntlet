using GunfireGauntlet.Engine.Entity.Player;
using System;
using System.Drawing;
using System.Windows.Forms;
using GunfireGauntlet.Engine.Helper;
using GunfireGauntlet.Engine.Input;
using GunfireGauntlet.Engine.Tile;
using GunfireGauntlet.Engine.Entity;
using System.Collections.Generic;
using GunfireGauntlet.Engine.Entity.Enemies;
using System.Linq;
using GunfireGauntlet.Engine.UI;

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
        Vector2 drawOffset = new Vector2();                 // for the camera to move around the map there needs to be an offset

        public static Player player = new Player(new Vector2(200, 200), 81, 48);

        private List<Entity> sEntities = new List<Entity>();
        private List<Enemy> enemies = new List<Enemy>();

        public GameWindow()
        {
            DoubleBuffered = true;

            TileManager.SettingTiles();
            World.GenerateMap(sEntities);

            InitializeComponent();      // this stays at the end
        }

        private void OnLoad(object sender, EventArgs e)
        {
            player.Health = 5;
            Text = title;
            Size = new Size(tileColumns * TILESIZE, tileRows * TILESIZE);
            tmrGameLoop.Enabled = true;
            player.Position = new Vector2(TILESIZE * World.COLUMNS / 2, TILESIZE * World.ROWS / 2);
        }

        private void GameLoop(object sender, EventArgs e) // Update
        {
            player.Update();

            drawOffset.X = Screen.PrimaryScreen.Bounds.Width / 2 - player.Center.X;
            drawOffset.Y = Screen.PrimaryScreen.Bounds.Height / 2 - player.Center.Y;

            foreach(Enemy _e in enemies.ToList())
            {
                _e.Update();

                if (_e.health == 0)
                {
                    _e.Remove();
                    enemies.Remove(_e);
                }
            }
            
            SpawnEnemies(5);

            lblDebug.Text = player.Health.ToString();

            UIManager.SetHearts();

            if (player.Health <= 0)
                GameOver();

            Invalidate();
        }

        private void SpawnEnemies(int max)
        {
            Random rnd = new Random();
            while (enemies.Count < max)
            {
                int x = rnd.Next(0, World.COLUMNS * TILESIZE);
                int y = rnd.Next(0, World.ROWS * TILESIZE);
                Enemy e = new Enemy(new Vector2(x, y), 50, 50, false);
                if (!e.Collider.CheckCollision(Entity.entities).Collider.Solid &&
                    !e.Collider.TileCollisionDetection())
                    e.Remove();
                else
                    enemies.Add(e);
            }
        }

        public void GameOver()
        {
            tmrGameLoop.Enabled = false;
            Engine.MainMenu mainMenu = new Engine.MainMenu();
            mainMenu.Show();
            foreach (Entity e in enemies.ToList()) { e.Remove(); }
            KeyHandler.ResetAllKeys();

            enemies.Clear();
            Hide();
        }

        private void OnPaint(object sender, PaintEventArgs e) // Draw
        {
            Graphics g = e.Graphics;

            foreach(Entity _e in Entity.entities)
            {
                if (_e.tag == "tile")
                    _e.Draw(g, drawOffset);
            }
            foreach (Entity _e in Entity.entities)
            {
                if (_e.tag == "enemy")
                    _e.Draw(g, drawOffset);
            }
            foreach (Entity _e in Entity.entities)
            {
                if (_e.tag == "weapon")
                    _e.Draw(g, drawOffset);
            }
            foreach (Entity _e in Entity.entities)
            {
                if (_e.tag == "bullet")
                    _e.Draw(g, drawOffset);
            }

            player.Draw(g);

            UIManager.Draw(g);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            KeyHandler.KeyDetectionDown(e);
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            KeyHandler.KeyDetectionUp(e);
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
