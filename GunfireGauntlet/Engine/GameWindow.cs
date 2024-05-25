using GunfireGauntlet.Engine.Entity.Player;
using System;
using System.Drawing;
using System.Windows.Forms;
using GunfireGauntlet.Engine.Essentials;
using GunfireGauntlet.Engine.Tile;
using GunfireGauntlet.Engine.Physics;
using System.Drawing.Imaging;
using GunfireGauntlet.Engine.Entity;
using System.Security.AccessControl;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using GunfireGauntlet.Engine.Entity.Enemies;

namespace GunfireGauntlet
{
    public partial class GameWindow : Form
    {
        private int originalTileSize = 16;          // 16x16
        private int tileScale = 3;
        private int tileSize;

        private int tileColumns = 50;               // number of columns
        private int tileRows = 25;                  // number of rows

        private string title = "Gunfire Gauntlet";  // window title

        private int[,] map = new int[30, 30];

        public static Player player = new Player(new Vector2(250, 300), 81, 48);

        private List<Entity> sEntities = new List<Entity>();

        private List<Enemy> enemies = new List<Enemy>();

        private KeyHandler keyHandler = new KeyHandler();

        private TileManager tileManager = new TileManager();

        public GameWindow()
        {
            tileSize = originalTileSize * tileScale;

            InitializeComponent();
            Text = title;
            Size = new Size(1280, 720);
            DoubleBuffered = true;

            MapConvertor.MaptoArray(ref map);
            MapConvertor.MapLoader(ref sEntities, map, tileSize);
            lblMap.Text = null;

            Enemy e = new Enemy(new Vector2(200, 200), 100, 100, false);
            enemies.Add(e);
        }

        private void GameLoop(object sender, EventArgs e) // Update
        {
            Collider c = player.Collider;
            keyHandler.KeyDetection();
            player.CheckMovementKeys(keyHandler.w, keyHandler.a, keyHandler.s, keyHandler.d);
            CollisionDetection();
            player.Update();

            lblCol.Text = "\ncollision: " + c.CheckCollision(player, Entity.entities).ToString() +
                "\nentityCount: " + Entity.entities.Count +
                "\ncollided: " + c.entitiesCollided.Count +
                "\nplayer health: " + player.health;

            foreach(Enemy _e in enemies)
            {
                _e.Update();
            }

            Invalidate();
        }

        private void CollisionDetection()
        {
        }

        private void OnPaint(object sender, PaintEventArgs e) // Draw
        {
            Graphics g = e.Graphics;

            foreach(Entity _e in sEntities)
            {
                _e.Draw(g);
            }
            foreach (Enemy _e in enemies)
            {
                _e.Draw(g);
            }

            player.Draw(g);
        }

        private void OnLoad(object sender, EventArgs e)
        {

        }
    }
}
