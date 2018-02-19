using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace pigvscakes
{
    class Level
    {
        private List<Texture2D> images;
        private Rectangle rec1;
        private Rectangle rec2;
        private int currentImage;
        private int width;
        private int height;
        private int x;
        private int y;
        private Direction direction;


        public void Initiliaze (List<Texture2D> images, int width, int height, Direction direction)
        {
            this.images = images;
            this.width = width;
            this.height = height;
            this.direction = direction;
            this.x = 0;
            this.y = 0;


        }

        public void Update (GameTime gameTime)
        {

        }

        public void Draw (SpriteBatch spriteBatch)
        {



        }

    }
}
