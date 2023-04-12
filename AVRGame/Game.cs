using GameLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
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
        WormPart head;
        List<WormPart> wormParts;


        int screenWidth = 400;
        int screenHeight = 400;
        int wormPartSize = 20;
        bool dood = false;

        float timer = 0;
        float delay = 200;
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
                (rnd.Next(0, (screenWidth / wormPartSize) * wormPartSize),
                    rnd.Next(0, screenHeight / wormPartSize) * wormPartSize), Direction.None, screen);

            wormParts = new List<WormPart>();

            head = new WormPart(Content.Load<Texture2D>("wormhead"), new Vector2
                (rnd.Next(0, (screenWidth / wormPartSize) * wormPartSize),
                    rnd.Next(0, screenHeight / wormPartSize) * wormPartSize), Direction.Right, screen);

            wormParts.Add(head);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (dood == false)
            {

                if (timer > delay)
                {
                    timer = 0;

                    foreach (WormPart s in wormParts)
                    {
                        s.Update(gameTime);
                    }

                    for (int i = wormParts.Count - 1; i > 0; i--)
                    {
                        wormParts[i].Direction = wormParts[i - 1].Direction;
                    }

                    wormParts[0].InputKeyboard();

                    if (wormParts[0].SpriteBox.Intersects(meteoriet.SpriteBox))
                    {
                        meteoriet.Position = new Vector2
                    (rnd.Next(0, (screenWidth / wormPartSize) * wormPartSize),
                        rnd.Next(0, screenHeight / wormPartSize) * wormPartSize);

                        WormPart tail = new WormPart(Content.Load<Texture2D>("wormbody"),
                            new Vector2(wormParts[wormParts.Count - 1].Position.X,
                            wormParts[wormParts.Count - 1].Position.Y),
                            wormParts[wormParts.Count - 1].Direction, screen);

                        switch (wormParts[wormParts.Count - 1].Direction)
                        {
                            case Direction.Up:
                                tail.Position = new Vector2(tail.Position.X,
                                    tail.Position.Y + wormPartSize);
                                break;
                            case Direction.Down:
                                tail.Position = new Vector2(tail.Position.X,
                                    tail.Position.Y - wormPartSize);

                                break;
                            case Direction.Left:
                                tail.Position = new Vector2(tail.Position.X + wormPartSize,
                                    tail.Position.Y);
                                break;
                            case Direction.Right:
                                tail.Position = new Vector2(tail.Position.X - wormPartSize,
                                    tail.Position.Y);
                                break;
                            case Direction.None:
                                break;
                        }

                        wormParts.Add(tail);
                    }
                    for (int i = 1; i < wormParts.Count - 1; i++)
                    {
                        if (wormParts[0].SpriteBox.Intersects(wormParts[i].SpriteBox))
                            dood = true;
                    }
                    if (dood)
                        Exit();

                }
            }


            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {


            spriteBatch.Begin();

            GraphicsDevice.Clear(Color.Black);

            meteoriet.Draw(spriteBatch);

            foreach (WormPart s in wormParts)
            {
                s.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}


