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
        //protected static Random rnd;

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
        
        public abstract void Update(GameTime gametime);

        public virtual void Draw(GameTime gameTime)
        {
            Game1.Instance.spriteBatch.Draw(imagen, Rectangle, Color.White);
        }

        #endregion
    }
}