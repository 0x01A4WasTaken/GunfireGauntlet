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

namespace GunfireGauntlet
{
    public partial class GameWindow : Form
    {
        private int originalTileSize = 16;          // 16x16
        private int tileScale = 5;
        private int tileSize;

        private int tileColumns = 50;               // number of columns
        private int tileRows = 25;                  // number of rows

        private string title = "Gunfire Gauntlet";  // window title

        private int[,] map = new int[15, 15];

        private Player player = new Player(new Vector2(250, 300), 108, 64);

        private List<Entity> sEntities = new List<Entity>();

        private KeyHandler keyHandler = new KeyHandler();

        private TileManager tileManager = new TileManager();

        public GameWindow()
        {
            tileSize = originalTileSize * tileScale;

            InitializeComponent();
            Text = title;
            Size = new Size(1980, 1080);
            DoubleBuffered = true;

            MapConvertor.MaptoArray(ref map);
            MapConvertor.MapLoader(ref sEntities, map, 100);
            lblMap.Text = null;
        }

        private void GameLoop(object sender, EventArgs e) // Update
        {
            Collider c = player.Collider;
            keyHandler.KeyDetection();
            player.CheckMovementKeys(keyHandler.w, keyHandler.a, keyHandler.s, keyHandler.d, keyHandler.space);
            CollisionDetection();
            player.Update();

            lblCol.Text = "\ncollision: " + c.CheckCollision(player, Entity.entities).ToString() +
                "\nentityCount: " + Entity.entities.Count +
                "\ncollided: " + c.entitiesCollided.Count +
                "\nvelocity: " + player.Velocity.GetX() + " " + player.Velocity.GetY();

            Invalidate();
        }

        private void CollisionDetection()
        {
            Collider pCol = player.GetCollider();
            pCol.BottomCollision(sEntities);
        }

        private void OnPaint(object sender, PaintEventArgs e) // Draw
        {
            Graphics g = e.Graphics;

            player.Draw(g);
            player.DrawCollider(g);

            foreach(Entity _e in sEntities)
            {
                _e.Draw(g);
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {

        }
    }
}
