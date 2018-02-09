using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.IO;

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
        Microsoft.Xna.Framework.Graphics.SpriteFont font;
        Move desplazamiento;


        //Crear Menu

        //formulario 
        int width;
        int height;
        //Fondo
        //Rectangle rectangle1;
        //Rectangle rectangle2;
        //int speed;
        //int r1x;
        //int r2x;
        //Texture2D background;

        //Listas
        internal List<Updatable> Sprites { get; private set; }
        internal List<Updatable> newSprites { get; private set; }

        //sprite animado
        //Animation animation;

        //pruebas
        List<cerdo> cerdos;
        TimeSpan previouscerdosTimeSpan;
        float secondsToCerdo;
        List<Texture2D> cerdosTexture;
        Random random;
        int points;
        int lifes;
        int bombs;
        Texture2D sniperTexture;
        Rectangle sniperRectangle;
        MouseState previousMouseState;
        List<Animation> deads;
        List<Animation> explosions;
        Texture2D deadTexture;
        Texture2D explosionTexture;
        static StreamReader leer;
        static StreamWriter escribir;
        SoundEffect shoot;
        Song song;




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
            desplazamiento = new Move();

            // Sprite animado
            //animation = new Animation();

            //prueba
            leer = new StreamReader("C:/Users/Felipe/Desktop/prueba.txt");

            cerdos = new List<cerdo>();
            previouscerdosTimeSpan = TimeSpan.Zero;
            secondsToCerdo = 3;
            cerdosTexture = new List<Texture2D>();
            random = new Random();
            lifes = 5;
            points = 0;
            bombs = 10;
            deads = new List<Animation>();
            explosions = new List<Animation>();


            ////r1x = 0;
            ////rectangle1 = new Rectangle(r1x, 0, width, height);
            ////r2x = r1x + rectangle1.Width;
            ////rectangle2 = new Rectangle(r2x, 0, width, height);
            ////speed = 1;

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

            //Menu


            //Fondo
            desplazamiento.Initialize (Game1.Instance.Content.Load<Texture2D>("background"),0,0,Direction.LeftRight,1,width,height);

            //Fuente
            font = Game1.Instance.Content.Load<Microsoft.Xna.Framework.Graphics.SpriteFont>("fonts/score");

            // Cerdo
            Sprites.Add(new Pig(new Point(300, 430), Point.Zero, new Point(70, 65)));

            //Manzanas
            //Sprites.Add(new AppleFabric());

            //disparos
            //Sprites.Add(new Shoot(Point.Zero, Point.Zero, new Point(70, 65)));



            //Pasteles
            //Sprites.Add(new EnemyFabric());



            //Sprite animado
            //Texture2D texture = Game1.Instance.Content.Load<Texture2D>("pig");
            //Vector2 vector2 = new Vector2(50, 100);
            //animation.Initialize(texture, vector2, 75, 65, 3, 160, Color.White, 1f, true);

            //prueba
            cerdosTexture.Add(Game1.Instance.Content.Load<Texture2D>("pig"));
            sniperTexture = Game1.Instance.Content.Load<Texture2D>("sniper");
            sniperRectangle = new Rectangle ((width - 100)/2, (height -100) /2 , 40 , 40);
            deadTexture = Game1.Instance.Content.Load<Texture2D>("explosion");
            //explosionTexture = Game1.Instance.Content.Load<Texture2D>("explosion");
            song = Game1.Instance.Content.Load<Song>("sounds/musica");
            shoot = Game1.Instance.Content.Load<SoundEffect>("sounds/shoot");

            Sounds.Play(song);

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
            //r1x -= speed;
            //r2x -= speed;

            //rectangle1 = new Rectangle(r1x, 0, width, height);
            //rectangle2 = new Rectangle(r2x, 0, width, height);

            //if (rectangle1.X == -width)
            //{
            //    r1x = 0;
            //}
            //if (rectangle2.X == 0)
            //{
            //    r2x = width;
            //}




            foreach (var item  in Sprites)
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



            //Sprite animado
            //animation.Update(gameTime);

            //prueba
            UpdateCerdos(gameTime);
            MouseState mouseState = Mouse.GetState();
            sniperRectangle.X = mouseState.X;
            sniperRectangle.Y = mouseState.Y;

            if (mouseState.LeftButton == ButtonState.Pressed && 
                previousMouseState.LeftButton != ButtonState.Pressed)
            {
                shoot.Play();
                CheckKill(); 
            }
            UpdateDeads(gameTime);


            //Fondo
            desplazamiento.Update(gameTime);

            SaveScore(gameTime);



            base.Update(gameTime);

        }

        private void SaveScore(GameTime gameTime)
        {
            if (lifes == 0)
            {
               

            }
        }

        //prueba

        private void UpdateDeads(GameTime gameTime)
        {
            foreach (Animation dead in deads)
            {
                dead.Update(gameTime);

            }
        }



        private void CheckKill()
        {
            for (int i = 0; i < cerdos.Count; i++)
            {
                if (sniperRectangle.Intersects(cerdos[i].Rectangle))
                {

                    addDead(sniperRectangle.X + 50, sniperRectangle.Y + 50);
                    points++;
                    cerdos.RemoveAt(i);
                    return;

                }
                

            }
        }

        private void addDead(int x, int y)
        {
            Animation dead = new Animation();
            dead.Initialize(deadTexture, new Vector2(x, y), 171, 124, 5, 100, Color.White, 1f, false);
            deads.Add(dead);
        }

        private void UpdateCerdos(GameTime gameTime)
        {
            TimeSpan timetoCerdo = TimeSpan.FromSeconds(secondsToCerdo);
            if(gameTime.TotalGameTime - previouscerdosTimeSpan > timetoCerdo)
            {
                AddCerdo(gameTime);
                previouscerdosTimeSpan = gameTime.TotalGameTime;
                secondsToCerdo *= 0.95f;
                if (secondsToCerdo < 0.3f) secondsToCerdo = 0.3f;
                
            }

            for (int i=0; i < cerdos.Count; i++)
            {
                cerdos[i].Update(gameTime);
                if (cerdos[i].Direction == Direction.LeftRight && cerdos[i].Position.X > width)
                {
                    lifes--;
                    cerdos.RemoveAt(i);
                }
                else if (cerdos[i].Direction == Direction.RightLeft && cerdos[i].Position.X < 0)
                {
                    lifes--;
                    cerdos.RemoveAt(i);
                }

            }

        }

        private void AddCerdo(GameTime gameTime)
        {
            Animation animation = new Animation();
            Direction direction = Direction.LeftRight;
            Vector2 vector2 = new Vector2(50, 300);
            animation.Initialize(cerdosTexture[0], vector2, 75, 65, 3, 160, Color.White, 1f, true);

            cerdo cerdo = new cerdo();
            cerdo.Initialize(animation, direction, cerdo.MovementType.Recto);
            cerdos.Add(cerdo);
  
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
            ////spriteBatch.Draw(background, rectangle1, Color.White);
            ////spriteBatch.Draw(background, rectangle2, Color.White);
            desplazamiento.Draw(spriteBatch);

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

            //Sprite animado
            //animation.Draw(spriteBatch);

            //prueba
            DrawCerdos(spriteBatch);
            DrawDeads(spriteBatch);
            spriteBatch.DrawString(font,"Lifes: " + lifes, new Vector2(10, 0), Color.White);
            spriteBatch.DrawString(font, "Points: " + points, new Vector2(10, 50), Color.White);
            spriteBatch.DrawString(font, "Bombs: " + bombs, new Vector2(10, 100), Color.White);
            spriteBatch.Draw(sniperTexture, sniperRectangle, Color.White);


            spriteBatch.End();



            base.Draw(gameTime);
        }

        private void DrawDeads(SpriteBatch spriteBatch)
        {
           foreach (Animation dead in deads)
            {
                dead.Draw(spriteBatch);
            }
        }

        private void DrawCerdos(SpriteBatch spriteBatch)
        {
            foreach (cerdo cerdo in cerdos)
            {
                cerdo.Draw(spriteBatch);

            }
        }
    }
}