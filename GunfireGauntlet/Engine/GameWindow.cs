using GunfireGauntlet.Engine.Entity.Player;
using System;
using System.Drawing;
using System.Windows.Forms;
using GunfireGauntlet.Engine.Essentials;
using GunfireGauntlet.Engine.Tile;

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

        private Player player = new Player(new Vector2(10, 10), 108, 64);

        private KeyHandler keyHandler = new KeyHandler();

        private TileManager tileManager = new TileManager();

        public GameWindow()
        {
            tileSize = originalTileSize * tileScale;

            InitializeComponent();
            Text = title;
            Size = new Size(1980, 1080);
            DoubleBuffered = true;
        }

        private void GameLoop(object sender, EventArgs e) // Update
        {
            keyHandler.KeyDetection();

            player.CheckMovementKeys(keyHandler.w, keyHandler.a, keyHandler.s, keyHandler.d);
            player.Update();

            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e) // Draw
        {
            Graphics g = e.Graphics;

            player.Draw(g);
        }

        private void OnLoad(object sender, EventArgs e)
        {

        }
    }
}
