using GunfireGauntlet.Engine.Essentials;
using GunfireGauntlet.Engine.Entity.Weapons;
using GunfireGauntlet.Engine.Physics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Threading;

namespace GunfireGauntlet.Engine.Entity.Player
{
    public class Player : Entity
    {
        private Image[] playerSprites = new Image[20];
        private int speed = 10;

        public int health { get; private set; } = 5;

        public int Speed { get; private set; }

        private string spriteDirection = "right";

        public bool isMoving { get; private set; }
        private bool hit = false;
        public bool Hit { get { return hit; } set { hit = value; } }

        public Player(Vector2 position, int height, int width) : base(position, height, width, true, "player")
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
            CheckMovementKeys();

            Position = Vector2.Add(Position, Velocity);
            Collider.CheckCollision(entities);
            Collider.TileCollisionDetection();
            Velocity = Vector2.Zero();

            /*
            if (Collider.CheckCollisionTagExclusion(this, Entity.entities, "enemy"))
            {
                SetPosition(Collider.oldx, Collider.oldy);
            }
            */

            /*
            ignore this
            Slash();
            */
        }

        public void TakeDamage(int value)
        {
            int newHealth = health - value;
            if (newHealth < 0)
                health = 0;
            else
                health = newHealth;
        }

        public void CheckMovementKeys()
        {
            Collider.SetOldValues(Position.X, Position.Y);
            if (KeyHandler.w == true)
            {
                Velocity.Y = -speed;
                isMoving = true;
            }
            if (KeyHandler.a == true)
            {
                Velocity.X = -speed;
                isMoving = true;
                spriteDirection = "left";
            }
            if (KeyHandler.s == true)
            {   
                Velocity.Y = speed;
                isMoving = true;
            }

            if (KeyHandler.d == true)
            {
                Velocity.X = speed;
                isMoving = true;
                spriteDirection = "right";
            }

            if (!KeyHandler.w && !KeyHandler.a && !KeyHandler.s && !KeyHandler.d)       // not moving
            {
                isMoving = false;
                Velocity = Vector2.Zero();
            }

            else if (KeyHandler.w && !KeyHandler.a && KeyHandler.s && !KeyHandler.d)    // moving in opposite directions
            {
                isMoving = false;
                Velocity = Vector2.Zero();
            }

            else if (!KeyHandler.w && KeyHandler.a && !KeyHandler.s && KeyHandler.d)    // moving in opposite directions
            {
                isMoving = false;
                Velocity = Vector2.Zero();
            }
        }

        private void Slash()
        {

            if (KeyHandler.space)
            {
                Bullet bullet = new Bullet(Position);
                bullet.Collider.Solid = false;
                switch (spriteDirection)
                {
                    case "left":
                        break;
                    case "right":
                        break;

                }
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

            if (GetImage() == null)
                g.FillRectangle(defaultBrush, (Screen.PrimaryScreen.Bounds.Width / 2) - (Width / 2) , (Screen.PrimaryScreen.Bounds.Height / 2) - (Height / 2), Width, Height);
            else
                g.DrawImage(GetImage(), (Screen.PrimaryScreen.Bounds.Width / 2) - (Width / 2) , (Screen.PrimaryScreen.Bounds.Height / 2) - (Height / 2), Width, Height);
        }


    }
}
