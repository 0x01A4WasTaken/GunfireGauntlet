using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using GunfireGauntlet.Engine.Helper;
using GunfireGauntlet.Engine.Input;

namespace GunfireGauntlet.Engine.Entity.Weapons
{
    public class Weapon : Entity
    {
        int damage;
        bool isDropped;
        Entity wielder;
        public bool onFireCooldown { get; private set; } = false;

        int cooldown;

        Vector2 leftOffset;
        Vector2 rightOffset;

        public Weapon(Vector2 position, int height, int width, int damage, bool isDropped, int cooldown) : base(position, height, width, false, "weapon")
        {
            this.damage = damage;
            this.isDropped = isDropped;

            this.cooldown = cooldown;
            Collider.Active = false;
            Collider.Solid = false;
        }

        public override void Update()
        {
            base.Update();

            if (GameWindow.player.equippedWeapon != this)
                isDropped = true;
            else
            {
                isDropped = false;
                wielder = GameWindow.player;
            }

            try
            {
                rightOffset = new Vector2(wielder.Width / 2, - Height / 2);
            }
            catch
            {
                rightOffset = Vector2.Zero();
            }

            try
            {
                leftOffset = new Vector2(- Width - wielder.Width / 2, - Height / 2);
            }
            catch
            {
                leftOffset = Vector2.Zero();
            }

            if (!isDropped)
            {
                if (GameWindow.player.spriteDirection == "right")
                    Position = Vector2.Add(wielder.Center, rightOffset);
                else if (GameWindow.player.spriteDirection == "left")
                    Position = Vector2.Add(wielder.Center, leftOffset);
            }

            Attack();
        }

        public virtual void Attack()
        {
            if (KeyHandler.space && !onFireCooldown)
            {
                AttackCooldown();
            }
        }

        public async void AttackCooldown()
        {
            onFireCooldown = true;
            await Task.Delay(cooldown);
            onFireCooldown = false;
        }
    }
}
