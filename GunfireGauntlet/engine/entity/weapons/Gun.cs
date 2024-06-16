using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GunfireGauntlet.Engine.Entity.Weapons;
using GunfireGauntlet.Engine.Helper;
using GunfireGauntlet.Engine.Input;

namespace GunfireGauntlet.Engine.Entity.Weapons
{
    public class Gun : Weapon
    {
        List<Bullet> bullets = new List<Bullet>();
        public Gun(Vector2 position) : base(position, 58, 12, 5, false, 300)
        {
            SetImage(Properties.Resources.weapon_katana);
        }

        public override void Update()
        {
            base.Update();
            foreach (Bullet b in bullets.ToList())
            {
                b.Update();
                if (!entities.Contains(b))
                {
                    bullets.Remove(b);
                }
            }
        }

        public async void RemoveBullet(Bullet b)
        {
            await Task.Delay(5000);
            bullets.Remove(b);
            b.Remove();
        }

        public override void Attack()
        {
            if (KeyHandler.space && !onFireCooldown)
            {        
                if (GameWindow.player.spriteDirection == "left")
                {
                    Bullet bullet = new Bullet(Vector2.Add(Center, new Vector2(-Width / 2, 0)));
                    bullet.Collider.Solid = false;
                    bullet.SetImage(Properties.Resources.weapon_katana_left);
                    bullets.Add(bullet);
                    bullet.direction = GameWindow.player.spriteDirection;
                    RemoveBullet(bullet);
                }
                else if (GameWindow.player.spriteDirection == "right")
                {
                    Bullet bullet = new Bullet(Vector2.Add(Center, new Vector2(Width / 2, 0)));
                    bullet.Collider.Solid = false;
                    bullet.SetImage(Properties.Resources.weapon_katana_right);
                    bullets.Add(bullet);
                    bullet.direction = GameWindow.player.spriteDirection;
                    RemoveBullet(bullet);
                }
         
                AttackCooldown();
            }
        }

        public override void Draw(Graphics g, Vector2 offset)
        {
            base.Draw(g, offset);
        }
    }
}
