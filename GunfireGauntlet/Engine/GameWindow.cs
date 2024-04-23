using GunfireGauntlet.Engine.Entity.Player;
using System;
using System.Drawing;
using System.Windows.Forms;
using GunfireGauntlet.Engine.Essentials;

namespace GunfireGauntlet
{
    public partial class GameWindow : Form
    {
        private int originalTileSize = 16; // 16x16
        private int tileScale = 3;
        private int tileSize;

        private int tileColumns = 27; // number of columns
        private int tileRows = 15; // number of rows

        private string title = "Gunfire Gauntlet";

        private Player player;

        public GameWindow()
        {
            tileSize = originalTileSize * tileScale;

            InitializeComponent();
            Text = title;
            Size = new Size(tileSize * tileColumns, tileSize * tileRows);
        }

        private void LoadForm(object sender, EventArgs e) // Start
        {
            player = new Player(new Position(10, 10), 100, 100);
        }

        private void GameLoop(object sender, EventArgs e) // Update
        {
            Console.WriteLine(player.Position.ToString());
        }

        private void OnPaint(object sender, PaintEventArgs e) // Draw
        {
            Graphics g = e.Graphics;

            RectangleF destinationRect = new RectangleF(player.Position.X, player.Position.Y,player.Width,player.Height);
            g.DrawImage(player.GetImage(), 10, 10, 32, 32);
        }
        
    }
}
