using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GunfireGauntlet.Engine.Entity;
using GunfireGauntlet.Engine.Helper;

namespace GunfireGauntlet.Engine.Tile
{
    public class Tile : Entity.Entity
    {
        public Type collisionType { get; private set; } = Type.None;
        public enum Type{
            Top,
            Bottom,
            Left,
            Right,
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight,
            Full,
            None
        }

        public Tile(Vector2 pos, int height, int width, Type type, bool overlay) : base(pos, height, width, false, "tile")
        {
            this.collisionType = type;
            if (overlay)
                SetTag("tileOverlay");
        }
    }
}
