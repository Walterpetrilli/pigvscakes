using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace pigvscakes
{
    public class Cake : MultiImageSprite
    {


        public Cake(Point location)
        {
            Location = location;
            images.Add(0, Game1.Instance.Content.Load<Texture2D>("cake_life"));
            selectedImage = 0;
            Size = new Point(55, 55);

        }


        public override void Update(GameTime gameTime)
        {
            //obtengo el valor de X
            int X = Location.X;
            X-=2;        //incremento X para que se mueva

            //if (X > Game1.Instance.graphics.GraphicsDevice.Viewport.Width)
            if (X < 10)
            {
                //destruyo el pastel que salio lejos de la pantalla
                Game1.Instance.newSprites.Add(this);
                return;
            }

            Location = new Point(X, Location.Y);    //actualizo su posicion
   
            foreach (var item in Game1.Instance.Sprites)
            {
                if (item is Pig)
                {
                    Pig pepe = item as Pig;
                    if (Rectangle.Intersects(pepe.Rectangle))
                    {
                        //hubo colision, descuento vida y 
                        //destruyo el pastel
                        pepe.Health -= 25;
                        Game1.Instance.newSprites.Add(this);
                        return;
                    }
                    // aumento dificultad del enemigo
                    if (pepe.Score >= 5)
                    {
                        X -= 3;
                        Location = new Point(X, Location.Y);
                    }
                }
            }



        }
    }

}