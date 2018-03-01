using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pigvscakes
{

    public enum Direction {LeftRight, RightLeft,UpDown,DownUp}

    class Move
    {
        private Texture2D texture;
        private Rectangle rectangle1;
        private Rectangle rectangle2;
        private Direction direction;
        private int x1;
        private int x2;
        private int y1;
        private int y2;
        private int speed;
        private int width;
        private int height;

        public void Initialize(Texture2D texture, int x, int y, Direction direction, int speed, int width,
            int height)
        {
            this.texture = texture;
            this.x1 = x;
            this.y1 = y;
            this.direction = direction;
            this.speed = speed;
            this.width = width;
            this.height = height;

            //Derecha

            if (direction == Direction.LeftRight)
            {
                this.rectangle1 = new Rectangle(x1, 0, width, height);
                this.x2 = x1 + rectangle1.Width;
                this.rectangle2 = new Rectangle(x2, 0, width, height);
            }
            else if (direction == Direction.RightLeft)
            {
                this.rectangle1 = new Rectangle(x1, 0, width, height);
                this.x2 = x1 - rectangle1.Width;
                this.rectangle2 = new Rectangle(x2, 0, width, height);

            }

            else if (direction == Direction.UpDown)
            {
                this.rectangle1 = new Rectangle(0, y1, width, height);
                this.y2 = y1 + rectangle1.Height;
                this.rectangle2 = new Rectangle(0, y2, width, height);

            }

            else 
            {
                this.rectangle1 = new Rectangle(0, y1, width, height);
                this.y2 = y1 - rectangle1.Height;
                this.rectangle2 = new Rectangle(0, y2, width, height);

            }
            
        }

        public void Update (GameTime gameTime)
        {
            //Derecha
            if (direction == Direction.LeftRight)
            {
                x1 -= speed;
                x2 -= speed;
            }

            else if (direction == Direction.RightLeft)
            {
                x1 += speed;
                x2 += speed;
            }

            else if (direction == Direction.UpDown)
            {
                y1 -= speed;
                y2 -= speed;
            }

            else
            {
                y1 += speed;
                y2 += speed;
            }

            if (direction == Direction.LeftRight || direction == Direction.RightLeft)
            {
                rectangle1 = new Rectangle(x1, 0, width, height);
                rectangle2 = new Rectangle(x2, 0, width, height);

            }

            else
            {
                rectangle1 = new Rectangle(0, y1, width, height);
                rectangle2 = new Rectangle(0, y2, width, height);

            }


            
            if (direction == Direction.LeftRight)
            {

                if (rectangle1.X == -width)
                {
                    x1 = 0;
                }


                if (rectangle2.X == 0)
                {
                    x2 = width;
                }

            }

            else if (direction == Direction.RightLeft)
            {

                if (rectangle1.X == width)
                {
                    x1 = 0;
                }


                if (rectangle2.X == 0)
                {
                    x2 = -width;
                }

            }

            else if (direction == Direction.UpDown)
            {
                if (rectangle1.Y == -height)
                {
                    y1 = 0;
                }


                if (rectangle2.Y == 0)
                {
                    y2 = height;
                }


            }

            else
            {
                if (rectangle1.Y == height)
                {
                    y1 = 0;
                }


                if (rectangle2.Y == 0)
                {
                    y2 = -height;
                }

            }


        }

        public void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle1, Color.White);
            spriteBatch.Draw(texture, rectangle2, Color.White);

        }

    }
}
