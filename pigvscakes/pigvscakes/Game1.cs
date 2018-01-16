using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace pigvscakes
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics { get; private set; }
        public SpriteBatch spriteBatch { get; private set; }
        public static Game1 Instance { get; private set; }
        private string msgpaused = "Paused";
        SpriteFont font;

        //Crear Menu
        enum GameState
        {
            MainMenu,
            Score,
            Playing,
        }

        // Crear Fondo
        Texture2D background;
        Rectangle rectangle1;
        Rectangle rectangle2;
        int width;
        int height;
        int speed;
        int r1x;
        int r2x;
        internal List<Updatable> Sprites { get; private set; }
        internal List<Updatable> newSprites { get; private set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Instance = this;
            Sprites = new List<Updatable>();
            newSprites = new List<Updatable>();

            // Ajuste resolucion del formulario
            width = 800;
            height = 600;
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;

    }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // Creo el fondo
            r1x = 0;
            rectangle1 = new Rectangle(r1x, 0, width, height);
            r2x = r1x + rectangle1.Width;
            rectangle2 = new Rectangle(r2x, 0, width, height);
            speed = 1;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //Fondo
            background = Game1.Instance.Content.Load<Texture2D>("background");

            //Fuente
            font = Game1.Instance.Content.Load<SpriteFont>("fonts/score");

            // Cerdo
            Sprites.Add(new Pig(new Point(300, 430), Point.Zero, new Point(70, 65)));

            //Manzanas
            Sprites.Add(new AppleFabric());

            //Pasteles
            Sprites.Add(new EnemyFabric());
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            
        }
        bool pausa;
        TimeSpan t_anterior;
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Pausa

            if (gameTime.TotalGameTime.Subtract(t_anterior) > new TimeSpan(0, 0, 0, 0, 200))
            {

                if (Keyboard.GetState().IsKeyDown(Keys.P))

                    pausa = !pausa;
                t_anterior = gameTime.TotalGameTime;

            }


            if (pausa)
                return;

            // TODO: Add your update logic here

            //Movimiento del Fondo
            r1x -= speed;
            r2x -= speed;

            rectangle1 = new Rectangle(r1x, 0, width, height);
            rectangle2 = new Rectangle(r2x, 0, width, height);

            if (rectangle1.X == -width)
            {
                r1x = 0;
            }
            if (rectangle2.X == 0)
            {
                r2x = width;
            }




            foreach (var item in Sprites)
            {

                item.Update(gameTime);
            }

            //agrego los nuevos sprites
            foreach (var item in newSprites)
            {
                if (Sprites.Contains(item))
                    Sprites.Remove(item);
                else
                    Sprites.Add(item);
            }
            //borro los nuevos sprites
            newSprites.Clear();

            base.Update(gameTime);

            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            //Fondo
            spriteBatch.Draw(background, rectangle1, Color.White);
            spriteBatch.Draw(background, rectangle2, Color.White);

            // Sprites
            foreach (var item in Sprites)
            {
                Sprite aux = item as Sprite;
                if (aux != null)
                    aux.Draw(gameTime);
            }

            if (pausa)
            {
                spriteBatch.DrawString(font, msgpaused, new Vector2(280, 200), Color.Yellow);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}