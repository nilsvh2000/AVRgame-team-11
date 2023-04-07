
/*using GameLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AVRGame
{
    public class Game : GameLib.AVRGame
    {
        private Texture2D _meteor;
        private Texture2D _spaceship;

        public int XPosMeteor;
        public int YPosMeteor;


        RasterizerState rasterizerState = new RasterizerState() { MultiSampleAntiAlias = true };
        public Game()
        {
            this.ScreenWidth = 800;
            this.ScreenHeight = 600;

        }

        /// <summary>
        /// Initilizes the game.
        /// Create all your non-graphic content here
        /// </summary>
        protected override void __Initialize()
        {
         
            XPosMeteor= -700;
            YPosMeteor= -400;
        }
        /// <summary>
        /// Here you can load all the content you need.
        /// Example: Load textures, sounds or texture effects
        /// </summary>
        protected override void __LoadContent()
        {
            _meteor = Content.Load<Texture2D>("Meteor V2");
            _spaceship = Content.Load<Texture2D>("spaceship");
        }

        /// <summary>
        /// Sometimes you need to unload content.
        /// This is called once if you exit the game
        /// </summary>
        protected override void __UnloadContent()
        {

        }

        /// <summary>
        /// Here you place your update logic.
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void __Update(GameTime gameTime)
        {
            XPosMeteor++;
            YPosMeteor++;
        }

        /// <summary>
        /// Here you place your draw logic. This drawing is in the world space.
        /// The camera follows an object.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        protected override void __DrawGame(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //Refresh your frame, should not be deleted. Color can be changed.
            GraphicsDevice.Clear(Color.Green);

            //Begin your spritebatch.
            spriteBatch.Begin(rasterizerState: this.rasterizerState, transformMatrix: Camera.TransformMatrix);


            //laad de dingen in als plaaje
            spriteBatch.Draw(_meteor, new Rectangle(XPosMeteor, YPosMeteor, 589, 299), Color.White);
            spriteBatch.Draw(_spaceship, new Rectangle(-700, -400, 900, 511), Color.White);

            //Place your world drawing logic here.
            
            //End the spritebatch
            spriteBatch.End();
        }

        /// <summary>
        /// This function is for drawing on the UI elements
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        protected override void __DrawUI(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin(rasterizerState: this.rasterizerState);

            //Place your non-camera related drawing logic here, for example the UI
            spriteBatch.End();

            
        }
    }
}


*/
using GameLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace AVRGame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle screen;
        Random rnd;
        Meteoriet meteoriet;


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
                    rnd.Next(0, screenHeight/wormPartSize)*wormPartSize),Direction.None);


        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            Meteoriet.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    
    }

}

