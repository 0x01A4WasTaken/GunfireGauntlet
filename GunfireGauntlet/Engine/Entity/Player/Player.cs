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
    public class Player : Entity
    {
        private Image[] playerSprites = new Image[20];
        private int speed = 10;
        private Vector2 nextPos;

        public int health { get; private set; } = 5;

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
            nextPos = GetPosition();
            Collider.Active = true;
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
            
            if (!Collider.CheckCollisionTagExclusion(this, Entity.entities, (int)nextPos.X, (int)nextPos.Y, GetWidth(), GetHeight(), "enemy"))
            {
                SetPosition(Vector2.Add(GetPosition(), velocity));
            }
            velocity = Vector2.Zero();
            nextPos = GetPosition();

            if (Collider.CheckCollisionTagExclusion(this, Entity.entities, "enemy"))
            {
                SetPosition(Collider.oldx, Collider.oldy);
            }
        }

        public void TakeDamage(int value)
        {
            int newHealth = health - value;
            if (newHealth < 0)
                health = 0;
            else
                health = newHealth;
        }

        public void CheckMovementKeys(bool w, bool a, bool s, bool d)
        {
            ColliderUpdater();
            if (w == true)
            {
                nextPos = new Vector2(nextPos.X, nextPos.Y - speed);
                velocity.Y = -speed;
                isMoving = true;
                up = true;
            }
            if (a == true)
            {
                nextPos = new Vector2(nextPos.X - speed, nextPos.Y);
                velocity.X = -speed;
                isMoving = true;
                left = true;
                spriteDirection = "left";
            }
            if (s == true)
            {   
                nextPos = new Vector2(nextPos.X, nextPos.Y + speed);
                velocity.Y = speed;
                isMoving = true;
                down = true;
            }

            if (d == true)
            {
                nextPos = new Vector2(nextPos.X + speed, nextPos.Y);
                velocity.X = speed;
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
        }
    }
}
