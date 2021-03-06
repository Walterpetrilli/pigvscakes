﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pigvscakes
{
    public class Pig : ScoreSprite
    {
        public enum states { right, left, injured, jump }
        public states State { get; set; }
        Texture2D rect;
        Microsoft.Xna.Framework.Graphics.SpriteFont font;

        public Pig(Point? location = null, Point? speed = null, Point? size=null)
        {

            if (location != null)
                Location = location.Value;
            if (size != null)
                Size = size.Value;

            if (speed != null)
                Speed = speed.Value;
            images.Add(states.right, Game1.Instance.Content.Load<Texture2D>("right"));
            images.Add(states.left, Game1.Instance.Content.Load<Texture2D>("left"));
            images.Add(states.injured, Game1.Instance.Content.Load<Texture2D>("injured"));
            images.Add(states.jump, Game1.Instance.Content.Load<Texture2D>("jump"));

            selectedImage = State;
            Health = 50;
            Score = 0;
            font = Game1.Instance.Content.Load<Microsoft.Xna.Framework.Graphics.SpriteFont>("fonts/score");

        }


        bool saltando;
        //bool andando;
        int Yanterior;

        public override void Update(GameTime gametime)
        {
            int x = Location.X;
            int y = Location.Y;
            x--;

            //Ajustes de margen (impedir salir)
            if (x < 5)
                x++;

            // Salto
            if (saltando)
            {
                y++;
                if (y == Yanterior)
                {
                    saltando = false;
                    State = states.right;
                    selectedImage = states.right;

                }
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Yanterior = y;
                saltando = true;
                State = states.jump;
                selectedImage = states.jump;
                y -= 150;
            }

            //Movimiento a la derecha

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {

                x += 2;
                State = states.right;
                selectedImage = states.right;


            }

            //Movimiento a la Izquierda

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {

                x -= 2;
                State = states.left;
                selectedImage = states.left;


            }

            //disparo




            ////Animacion andando

            //if (andando == true)
            //{ 
            //    foreach (states xState in Enum.GetValues(typeof(states)))
            //    {
            //        State = xState;
            //        selectedImage = xState;
            //    }
            //}

            Location = new Point(x, y);

            //Vida del sprite
            if (Health <=25)
            {
                State = states.injured;
                selectedImage = states.injured;
            }
            int puntaje = Score;
            if (Health <= 0)
            {
                //se murio el cerdo
                Game1.Instance.newSprites.Add(this);   

                //Open the File
                StreamWriter sw = new StreamWriter("content/prueba.txt");

                //Writeout the numbers 1 to 10 on the same line.
                sw.Write("Hola");
                return;
            }

            if (Health > 0)
                rect = new Texture2D(Game1.Instance.graphics.GraphicsDevice, Health, 10);
            else
                rect = new Texture2D(Game1.Instance.graphics.GraphicsDevice, 1, 10);

            Color[] data = new Color[Health * 10];
            for (int i = 0; i < data.Length; ++i)
                data[i] = Color.White;
            rect.SetData(data);


        }



    public override void Draw(GameTime gameTime)
        {
            //Dibujo la barra de vida
            Vector2 coor = new Vector2(Location.X-15, Location.Y - 20);

            Game1.Instance.spriteBatch.Draw(rect, coor, Color.GreenYellow);

            //Dibujo el puntaje

            //Game1.Instance.spriteBatch.DrawString(font, "Puntaje: " + Score,
            //                                new Vector2(10, 5), Color.White);

            //disparo bala



            base.Draw(gameTime);
        }

    }
}