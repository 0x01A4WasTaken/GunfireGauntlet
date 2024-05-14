using GunfireGauntlet.Engine.Essentials;
using GunfireGauntlet.Engine.Physics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GunfireGauntlet.Engine.Entity.Player
{
    internal class Player : Entity
    {
        private Image[] playerSprites = new Image[20];
        private float speed = 15;

        private string direction;
        private string spriteDirection = "right";

        private bool isMoving = false;

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
        }

        public void CheckMovementKeys(bool w, bool a, bool s, bool d)
        {
            if (w == true)
            { 
                SetPosition(GetPosition().GetX(), GetPosition().GetY() - speed);
                direction = "up";
                isMoving = true;
            }
            if (a == true)
            {
                SetPosition(GetPosition().GetX() - speed, GetPosition().GetY());
                direction = "left";
                spriteDirection = "left";
                isMoving = true;
            }
            if (s == true)
            {
                SetPosition(GetPosition().GetX(), GetPosition().GetY() + speed);
                direction = "down";
                isMoving = true;
            }
            if (d == true)
            {
                SetPosition(GetPosition().GetX() + speed, GetPosition().GetY());
                direction = "right";
                spriteDirection = "right";
                isMoving = true;
            }

            if (!w && !a && !s && !d)       // not moving
                isMoving = false;
            else if (w && !a && s && !d)    // moving in opposite directions
                isMoving = false;
            else if (!w && a && !s && d)    // moving in opposite directions
                isMoving = false;
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
