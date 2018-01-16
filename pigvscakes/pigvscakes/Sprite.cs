using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pigvscakes
{
    public abstract class Sprite:Updatable
    {
        protected Texture2D imagen;
        protected static Random rnd;

        #region Propiedades

        //Ubicacion de mi sprite
        public Point Location { get; set; }

        //Velocidad del sprite
        public Point Speed { get; set; }

        //Tamaño del sprite
        public Point Size { get; set; }

        public Rectangle Rectangle
        {
            get { return new Rectangle(Location, Size); }
        }


        /// <summary>
        /// Constructor
        /// </summary>
        public Sprite()
        {
            if (rnd == null)
                rnd = new Random();

            Location = new Point(rnd.Next(100), rnd.Next(100));
            Size = new Point(rnd.Next(100), rnd.Next(100));
            Speed = new Point(rnd.Next(5), 0);
        }

        public abstract void Update(GameTime gametime);

        public virtual void Draw(GameTime gameTime)
        {
            Game1.Instance.spriteBatch.Draw(imagen, Rectangle, Color.White);
        }

        #endregion
    }
}