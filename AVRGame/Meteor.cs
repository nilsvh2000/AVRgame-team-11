using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AVRGame
{
     class Meteor : Sprite
    {
        public Meteor(Texture2D texture, Vector2 position, Direction direction) 
            : base(texture, position, direction)
        {

        }
    }
}
