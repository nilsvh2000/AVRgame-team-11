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
        public WormPart(Texture2D texture, Vector2 position, Direction direction, Rectangle screen)
            : base(texture, position, direction, screen)
        {
        }

        public override void Update(GameTime gameTime)
        {
            switch (direction)
            {
                case Direction.Up:
                    position.Y += -texture.Height;
                    break;
                case Direction.Down: 
                    position.Y += texture.Height;
                    break;
                case Direction.Left:
                    position.X += -texture.Height; 
                    break;
                case Direction.Right:
                    position.X += texture.Height; 
                    break;
                case Direction.None: 
                    break;
            }
            Teleportation();


            base.Update(gameTime);
        }

        

        public void InputKeyboard()
        {
            if (Keyboard.GetState() .IsKeyDown(Keys.Up))
                if (direction != Direction.Down)
                    direction = Direction.Up;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                if (direction != Direction.Up)
                    direction = Direction.Down;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                if (direction != Direction.Right)
                    direction = Direction.Left;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                if (direction != Direction.Left)
                    direction = Direction.Right;
        }

        private void Teleportation()
        {
            if (position.X < 0)
                position.X = screen.Width - texture.Width;
            if (position.X > screen.Width - texture.Width)
                position.X = 0;
            if (position.Y < 0)
                position.Y = screen.Height - texture.Height;
            if (position.Y > screen.Height - texture.Height)
                position.Y = 0;
        }
    }
}
