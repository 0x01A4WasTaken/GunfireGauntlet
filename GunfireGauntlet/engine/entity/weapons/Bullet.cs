using GunfireGauntlet.Engine.Entity.Enemies;
using GunfireGauntlet.Engine.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace GunfireGauntlet.Engine.Entity.Weapons
{
    public class Bullet : Entity
    {
        int speed = 15;
        public string direction;
        int damage = 6;

        public Bullet(Vector2 position) : base(position, 12, 58, false, "bullet")
        {
            Collider.Solid = false;
            defaultBrush = new SolidBrush(Color.White);
        }

        public override void Update()
        {
            base.Update();
            Move();
            Entity e = Collider.CheckCollision(entities);
            if (e == null || e.Tag == "bullet")
                return;
            if (e.Tag == "tile" && e.Collider.Solid)
            {
                Remove();
                return;
            }
            if (e.Tag == "enemy")
            {
                Enemy enemy = e as Enemy;
                enemy.TakeDamage(damage);
                Remove();
            }
        }

        public void Move()
        {
            Vector2 right = new Vector2(speed, 0);
            Vector2 left = new Vector2(-speed, 0);
            if (direction == "right")
            {
                Position = Vector2.Add(Position, right);
            }
            else if (direction == "left")
            {
                Position = Vector2.Add(Position, left);
            }
        }

        public override void Remove()
        {
            base.Remove();
        }
    }
}
