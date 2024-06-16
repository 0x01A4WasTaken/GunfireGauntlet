using GunfireGauntlet.Engine.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunfireGauntlet.Engine.Entity.Enemies
{
    internal class Enemy : Entity
    {
        public int health { get; private set; } = 10;
        int speed = 1;
        int damage = 1;
        bool onAttackCooldown = false;

        public Enemy(Vector2 position, int height, int width, bool animated) : base(position, height, width, animated, "enemy")
        {
            Collider.Active = true;
        }

        public override void Update()
        {
            base.Update();

            // update the old values
            Collider.SetOldValues(Position.X, Position.Y);

            // move towards the player
            FollowEntity(GameWindow.player);
            Position = Vector2.Add(Position, Velocity);

            // check collisions with entites and then with player to deal damange
            Collider.CheckCollision(entities);
            Collider.TileCollisionDetection();
            CheckPlayerCollision();
            Velocity = Vector2.Zero();
        }

        private void CheckPlayerCollision()
        {
            if (Collider.entitiesCollided.Contains(GameWindow.player))
            {
                if(!onAttackCooldown)
                {
                    GameWindow.player.TakeDamage(damage);
                    AttackCooldown();
                }
            }
        }

        private void FollowEntity(Entity e)
        {
            if (Center.X > e.Center.X)
                Velocity = Vector2.Add(Velocity, new Vector2(-speed, 0));
            if (Center.X < e.Center.X)
                Velocity = Vector2.Add(Velocity, new Vector2(speed, 0));
            if (Center.Y > e.Center.Y)
                Velocity = Vector2.Add(Velocity, new Vector2(0, -speed));
            if (Center.Y < e.Center.Y)
                Velocity = Vector2.Add(Velocity, new Vector2(0, speed));
        }

        public void TakeDamage(int damage)
        {
            if ((health - damage) > 0)
                health -= damage;
            else if ((health - damage) <= 0)
                health = 0;
        }

        public override void Remove()
        {
            base.Remove();
        }

        public async void AttackCooldown()
        {
            onAttackCooldown = true;
            await Task.Delay(700);
            onAttackCooldown = false;
        }
    }
}
