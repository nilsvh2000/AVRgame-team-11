using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AVRGame
{
     class Meteoriet : Sprite
    {
        public Meteoriet(Texture2D texture, Vector2 position, Direction direction, Rectangle screen) 
            : base(texture, position, direction, screen)
        {
        }
    }
}
