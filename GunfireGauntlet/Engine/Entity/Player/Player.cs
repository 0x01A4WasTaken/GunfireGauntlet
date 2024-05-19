using GunfireGauntlet.Engine.Essentials;
using GunfireGauntlet.Engine.Physics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace GunfireGauntlet.Engine.Entity.Player
{
    internal class Player : Entity
    {
        private Image[] playerSprites = new Image[20];
        private int speed = 10;
        private Vector2 newPos;

        public int Speed { get; internal set; }
        private Vector2 velocity;
        public Vector2 Velocity { get { return velocity; } set { velocity = value; } } 

        // movement directions
        public bool up {  get; private set; }
        public bool down {  get; private set; }
        public bool left {  get; private set; }
        public bool right {  get; private set; }

        private string spriteDirection = "right";

        public bool isMoving { get; private set; }

        public Player(Vector2 position, int height, int width) : base(position, height, width, true)
        {
            try
            {
                playerSprites[0] = Image.FromFile(@"C:\Users\hamzasalim\source\repos\GunfireGauntlet\GunfireGauntlet\bin\Debug\res\player\knight_hit_f0.png");      // hit
                playerSprites[1] = Image.FromFile(@"C:\Users\hamzasalim\source\repos\GunfireGauntlet\GunfireGauntlet\bin\Debug\res\player\knight_idle_f0.png");     // idle
                playerSprites[2] = Image.FromFile(@"C:\Users\hamzasalim\source\repos\GunfireGauntlet\GunfireGauntlet\bin\Debug\res\player\knight_idle_f1.png");
                playerSprites[3] = Image.FromFile(@"C:\Users\hamzasalim\source\repos\GunfireGauntlet\GunfireGauntlet\bin\Debug\res\player\knight_idle_f2.png");
                playerSprites[4] = Image.FromFile(@"C:\Users\hamzasalim\source\repos\GunfireGauntlet\GunfireGauntlet\bin\Debug\res\player\knight_idle_f3.png");
                playerSprites[5] = Image.FromFile(@"C:\Users\hamzasalim\source\repos\GunfireGauntlet\GunfireGauntlet\bin\Debug\res\player\knight_idle_f4.png");     // left
                playerSprites[6] = Image.FromFile(@"C:\Users\hamzasalim\source\repos\GunfireGauntlet\GunfireGauntlet\bin\Debug\res\player\knight_idle_f5.png");
                playerSprites[7] = Image.FromFile(@"C:\Users\hamzasalim\source\repos\GunfireGauntlet\GunfireGauntlet\bin\Debug\res\player\knight_idle_f6.png");
                playerSprites[8] = Image.FromFile(@"C:\Users\hamzasalim\source\repos\GunfireGauntlet\GunfireGauntlet\bin\Debug\res\player\knight_idle_f7.png");
                playerSprites[9] = Image.FromFile(@"C:\Users\hamzasalim\source\repos\GunfireGauntlet\GunfireGauntlet\bin\Debug\res\player\knight_run_f0.png");      // run
                playerSprites[10] = Image.FromFile(@"C:\Users\hamzasalim\source\repos\GunfireGauntlet\GunfireGauntlet\bin\Debug\res\player\knight_run_f1.png");
                playerSprites[11] = Image.FromFile(@"C:\Users\hamzasalim\source\repos\GunfireGauntlet\GunfireGauntlet\bin\Debug\res\player\knight_run_f2.png");
                playerSprites[12] = Image.FromFile(@"C:\Users\hamzasalim\source\repos\GunfireGauntlet\GunfireGauntlet\bin\Debug\res\player\knight_run_f3.png");     
                playerSprites[13] = Image.FromFile(@"C:\Users\hamzasalim\source\repos\GunfireGauntlet\GunfireGauntlet\bin\Debug\res\player\knight_run_f4.png");     // left
                playerSprites[14] = Image.FromFile(@"C:\Users\hamzasalim\source\repos\GunfireGauntlet\GunfireGauntlet\bin\Debug\res\player\knight_run_f5.png");
                playerSprites[15] = Image.FromFile(@"C:\Users\hamzasalim\source\repos\GunfireGauntlet\GunfireGauntlet\bin\Debug\res\player\knight_run_f6.png");
                playerSprites[16] = Image.FromFile(@"C:\Users\hamzasalim\source\repos\GunfireGauntlet\GunfireGauntlet\bin\Debug\res\player\knight_run_f7.png");
            }
            catch
            {
                MessageBox.Show("Player Sprites Not Found");
            }
            isMoving = false;
            newPos = GetPosition();
        }

        public override void Update()
        {
            base.Update();
            if (spriteCounter > 6)
            {
                switch (spriteNumber)
                {
                    case 0:
                        {
                            spriteNumber = 1;
                            break;
                        }
                    case 1:
                        {
                            spriteNumber = 2;
                            break;
                        }
                    case 2:
                        {
                            spriteNumber = 3;
                            break;
                        }
                    case 3:
                        {
                            spriteNumber = 0;
                            break;
                        }
                }
                spriteCounter = 0;
            }
            
            if (!Collider.CheckCollision(this, Entity.entities, (int)newPos.GetX(), (int)newPos.GetY(), GetWidth(), GetHeight()))
            {
                SetPosition(Vector2.Add(GetPosition(), velocity));
            }
            velocity = Vector2.Zero();
            newPos = GetPosition();

            if (Collider.CheckCollision(this, Entity.entities))
            {
                SetPosition(Collider.oldx, Collider.oldy);
            }
        }

        public void CheckMovementKeys(bool w, bool a, bool s, bool d, bool space)
        {
            ColliderUpdater();
            if (space == true)
                SetPosition(new Vector2(100, 100));
            if (w == true)
            {
                newPos = new Vector2(newPos.GetX(), newPos.GetY() - speed);
                velocity.SetY(-speed);
                isMoving = true;
                up = true;
            }
            if (a == true)
            {
                newPos = new Vector2(newPos.GetX() - speed, newPos.GetY());
                velocity.SetX(-speed);
                isMoving = true;
                left = true;
                spriteDirection = "left";
            }
            if (s == true)
            {
                newPos = new Vector2(newPos.GetX(), newPos.GetY() + speed);
                velocity.SetY(speed);
                isMoving = true;
                down = true;
            }

            if (d == true)
            {
                newPos = new Vector2(newPos.GetX() + speed, newPos.GetY());
                velocity.SetX(speed);
                isMoving = true;
                right = true;
                spriteDirection = "right";
            }

            if (!w && !a && !s && !d)       // not moving
            {
                up = false;
                left = false;
                down = false;
                right = false;
                isMoving = false;
                velocity = Vector2.Zero();
            }

            else if (w && !a && s && !d)    // moving in opposite directions
            {
                up = true;
                left = false;
                down = true;
                right = false;
                isMoving = false;
                velocity = Vector2.Zero();
            }

            else if (!w && a && !s && d)    // moving in opposite directions
            {
                up = false;
                left = true;
                down = false;
                right = true;
                isMoving = false;
                velocity = Vector2.Zero();
            }
        }

        public override void Draw(Graphics g)
        {
            switch (spriteDirection)
            {
                case "left":
                    {
                        if(isMoving)
                            SetImage(playerSprites[13 + spriteNumber]);
                        else
                            SetImage(playerSprites[5 + spriteNumber]);
                        break;
                    }
                case "right":
                    {
                        if(isMoving)
                            SetImage(playerSprites[9 + spriteNumber]);
                        else
                            SetImage(playerSprites[1 + spriteNumber]);
                        break;
                    }
            }
            base.Draw(g);
            SolidBrush brush = new SolidBrush(Color.FromArgb((byte)100, (byte)0, (byte)0, (byte)255));
            g.FillRectangle(brush, newPos.GetX(), newPos.GetY(), GetWidth(), GetHeight());
            
        }
    }
}
