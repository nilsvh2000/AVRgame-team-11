using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AVRGame
{
    class WormPart : Sprite
    {
        public Meteor(Texture2D texture, Vector2 position, Direction direction)
            : base(texture, position, direction)
        {
        }

        public void InputKeyboard()
        {
            if (Keyboard.GetState() .IsKeyDown(Keys.Up))
                if (direction != Direction.Down)
                    direction = Direction.Up;
        }
            
    }
}
