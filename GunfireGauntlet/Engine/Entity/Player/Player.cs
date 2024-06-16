using GunfireGauntlet.Engine.Helper;
using GunfireGauntlet.Engine.Input;
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
        public List<Bullet> bullets = new List<Bullet>();
        private int speed = 10;

        public Weapon equippedWeapon { get; private set; } = null;

        private int health = 6;
        public int Health
        {
            get { return health; }
            set { if (value >= 0) health = value; }
        }


        public int Speed { get; private set; }

        public string spriteDirection { get; private set; } = "right";

        public bool IsMoving { get; private set; } = false;

        public bool Hit { get; private set; } = false;
        public bool Invulnerable { get; private set; } = false;

        public Player(Vector2 position, int height, int width) : base(position, height, width, true, "player")
        {
            try
            {
                playerSprites[0] = Properties.Resources.knight_hit_f0;              // right
                playerSprites[1] = Properties.Resources.knight_hit_f1;              // left 
                playerSprites[2] = Properties.Resources.knight_idle_f0;             // right
                playerSprites[3] = Properties.Resources.knight_idle_f1;
                playerSprites[4] = Properties.Resources.knight_idle_f2;
                playerSprites[5] = Properties.Resources.knight_idle_f3;
                playerSprites[6] = Properties.Resources.knight_idle_f4;             // left
                playerSprites[7] = Properties.Resources.knight_idle_f5;
                playerSprites[8] = Properties.Resources.knight_idle_f6;
                playerSprites[9] = Properties.Resources.knight_idle_f7;
                playerSprites[10] = Properties.Resources.knight_run_f0;             // right 
                playerSprites[11] = Properties.Resources.knight_run_f1;
                playerSprites[12] = Properties.Resources.knight_run_f2;
                playerSprites[13] = Properties.Resources.knight_run_f3;     
                playerSprites[14] = Properties.Resources.knight_run_f4;             // left
                playerSprites[15] = Properties.Resources.knight_run_f5;
                playerSprites[16] = Properties.Resources.knight_run_f6;
                playerSprites[17] = Properties.Resources.knight_run_f7;
            }
            catch
            {
                MessageBox.Show("Player Sprites Not Found");
            }

            equippedWeapon = new Gun(position);
        }

        public override void Update()
        {
            base.Update();
            CheckMovementKeys();

            Position = Vector2.Add(Position, Velocity);
            Collider.CheckCollision(entities);
            Collider.TileCollisionDetection();
            Velocity = Vector2.Zero();

            equippedWeapon.Update();
        }

        public void TakeDamage(int value)
        {
            if (Invulnerable)
                return;

            int newHealth = health - value;
            if (newHealth < 0)
                health = 0;
            else
                health = newHealth;

            InvulnerabilityCooldown();
        }

        public void CheckMovementKeys()
        {
            Collider.SetOldValues(Position.X, Position.Y);
            if (KeyHandler.w == true)
            {
                Velocity.Y += -speed;
            }
            if (KeyHandler.a == true)
            {
                Velocity.X += -speed;
                spriteDirection = "left";
            }
            if (KeyHandler.s == true)
            {   
                Velocity.Y += speed;
            }

            if (KeyHandler.d == true)
            {
                Velocity.X += speed;
                spriteDirection = "right";
            }

            if (Velocity.Magnitude == 0)
                IsMoving = false;
            else
                IsMoving = true;
        }
        
        public override void Draw(Graphics g)
        {
            
            switch (spriteDirection)
            {
                case "left":
                    {
                        if (!Hit)
                        {
                            if(IsMoving)
                                SetImage(playerSprites[14 + spriteNumber]);
                            else
                                SetImage(playerSprites[6 + spriteNumber]);
                        }
                        else
                        {
                            SetImage(playerSprites[1]);
                        }
                       break;
                    }
                case "right":
                    {
                        if (!Hit)
                        {
                            if(IsMoving)
                                SetImage(playerSprites[10 + spriteNumber]);
                            else
                                SetImage(playerSprites[2 + spriteNumber]);
                        }
                        else
                        {
                            SetImage(playerSprites[0]);
                        }
                        break;
                    }
            }

            if (GetImage() == null)
                g.FillRectangle(defaultBrush, (Screen.PrimaryScreen.Bounds.Width / 2) - (Width / 2) , (Screen.PrimaryScreen.Bounds.Height / 2) - (Height / 2), Width, Height);
            else
                g.DrawImage(GetImage(), (Screen.PrimaryScreen.Bounds.Width / 2) - (Width / 2) , (Screen.PrimaryScreen.Bounds.Height / 2) - (Height / 2), Width, Height);
        }

        public async void InvulnerabilityCooldown()
        {
            Hit = true;
            Invulnerable = true;
            await Task.Delay(700);
            Hit = false;
            Invulnerable = false;
        }
    }
}
