using GunfireGauntlet.Engine.Essentials;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunfireGauntlet.Engine.Entity.Enemies
{
    internal class Enemy : Entity
    {
        int health = 10;
        int speed = 3;
        int damage = 1;
        bool onAttackCooldown = false;

        Vector2 nextPos = new Vector2 (0, 0);

        public Enemy(Vector2 position, int height, int width, bool animated) : base(position, height, width, animated, "enemy")
        {
            Collider.Active = true;
            nextPos = position;
        }

        public override void Update()
        {
            base.Update();
            ColliderUpdater();
            CheckCollision();
        }

        private void CheckCollision()
        {
            if (Collider.CheckCollisionTagIsolation(this, entities, "player") && !onAttackCooldown)
            {
                GameWindow.player.TakeDamage(damage);
                AttackCooldown();
            }
            FollowEntity(GameWindow.player);
            if (!Collider.CheckCollisionTagExclusion(this, Entity.entities, (int)nextPos.X, (int)nextPos.Y, GetWidth(), GetHeight(), "player"))
            {
                SetPosition(nextPos);
            }
            nextPos = GetPosition();
        }

        private void FollowEntity(Entity e)
        {
            if ((int)GetPosition().X + GetWidth() / 2 > (int)e.GetPosition().X + e.GetWidth() / 2)
                nextPos = new Vector2((int)nextPos.X - speed, (int)nextPos.Y);
            if ((int)GetPosition().X + GetWidth() / 2 < (int)e.GetPosition().X + e.GetWidth() / 2)
                nextPos = new Vector2((int)nextPos.X + speed, (int)nextPos.Y);
            if ((int)GetPosition().Y + GetHeight() / 2 > (int)e.GetPosition().Y + e.GetHeight() / 2)
                nextPos = new Vector2((int)nextPos.X, (int)nextPos.Y - speed);
            if ((int)GetPosition().Y + GetHeight() / 2 < (int)e.GetPosition().Y + e.GetHeight() / 2)
                nextPos = new Vector2((int)nextPos.X, (int)nextPos.Y + speed);
        }

        public async void AttackCooldown()
        {
            onAttackCooldown = true;
            await Task.Delay(1000);
            onAttackCooldown = false;
        }
    }
}
