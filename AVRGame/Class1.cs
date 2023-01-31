using GameLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVRGame
{
    internal class ball : GameObject   
    {
        public ball()
        {
            this.HitBox = new CircleHitBox(50);
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(this.HitBox, Color.Blue);
        }
    }
}
