using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AVRGame
{
    class Galaxy : Sprite
    {
        private Texture2D texture2D;

        public Galaxy(Texture2D texture2D)
        {
            this.texture2D = texture2D;
        }

        public Galaxy(Texture2D texture, Vector2 position, Direction direction, Rectangle screen)
            : base(texture, position, direction, screen)
        {
        }
    }
}
