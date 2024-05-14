using GunfireGauntlet.Engine.Essentials;
using GunfireGauntlet.Engine.Physics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GunfireGauntlet.Engine.Entity.Player
{
    internal class Player : Entity
    {
        private Image[] playerSprites;
        private KeyHandler keyHandler;
        private float speed = 15;

        public Player(Vector2 position, int height, int width) : base(position, height, width, @"\player.png")
        {

        }

        public override void SetImage(string path)
        {
            base.SetImage(path);
        }

        public void CheckMovementKeys(bool w, bool a, bool s, bool d)
        {
            if (w == true)
                SetPosition(GetPosition().GetX(), GetPosition().GetY() - speed);
            if (a == true)
                SetPosition(GetPosition().GetX() - speed, GetPosition().GetY());
            if (s == true)
                SetPosition(GetPosition().GetX(), GetPosition().GetY() + speed);
            if (d == true)
                SetPosition(GetPosition().GetX() + speed, GetPosition().GetY());
        }

    }
}
