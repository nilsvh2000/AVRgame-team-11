using GameLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Reflection.PortableExecutable;

namespace AVRGame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle screen;
        Random rnd;
        Meteoriet meteoriet;
        WormPart wormPart;

        int screenWidth = 400;
        int screenHeight = 400;
        int wormPartSize = 20;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            screen = new Rectangle(0, 0, screenWidth, screenHeight);
            rnd = new Random();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            meteoriet = new Meteoriet(Content.Load<Texture2D>("Meteor V2 beste"), new Vector2
                (rnd.Next(0,(screenWidth/wormPartSize)*wormPartSize), 
                    rnd.Next(0, screenHeight/wormPartSize)*wormPartSize)),Direction.None, screen);

            wormPart = new WormPart(Content.Load<Texture2D>("later invullen"), new Vector2
                (rnd.Next(0, (screenWidth / wormPartSize) * wormPartSize),
                    rnd.Next(0, screenHeight / wormPartSize) * wormPartSize)), Direction.Right, screen);
                //sprite van Slang moet nog worden toegevoegd
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            wormPart.Update(gameTime);
            wormPart.InputKeyboard();

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            meteoriet.Draw(spriteBatch);
            wormpart.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}