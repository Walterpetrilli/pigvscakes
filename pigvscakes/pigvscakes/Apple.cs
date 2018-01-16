using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pigvscakes
{
    public class Apple:MultiImageSprite
    {

        public Apple(Point location)
        {
            Location = location;
            images.Add(0, Game1.Instance.Content.Load<Texture2D>("apple"));
            selectedImage = 0;
            Size = new Point(25, 30);

        }


        public override void Update(GameTime gameTime)
        {
            //obtengo el valor de X
            int X = Location.X;
            X -= 2;        //incremento X para que se mueva

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
                        //hubo colision, aumento score y 
                        //destruyo la manzana
                        pepe.Score += 1;
                        Game1.Instance.newSprites.Add(this);
                        return;
                    }
                }

            }

        }
    }
}
