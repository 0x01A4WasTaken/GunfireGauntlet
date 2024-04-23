using GunfireGauntlet.Engine.Essentials;
using GunfireGauntlet.Engine.Physics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GunfireGauntlet.Engine.Entity.Player
{
    internal class Player : Entity
    {
        private Image[] playerSprites;

        public Player(Position position, int height, int width) : base(position, height, width, @"\player.png")
        {

        }

        public override void SetImage(string path)
        {
            base.SetImage(path);
        }

    }
}
