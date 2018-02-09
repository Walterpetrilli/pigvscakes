using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pigvscakes
{

    class cerdo
    {
        private Animation animation;
        private Direction direction;
        public enum MovementType { Recto, Senoidal, Parabolico, ZigZag }
        private MovementType movementType;
        private int speed;
        private Rectangle rectangle;

        internal Direction Direction
        {
            get
            {
                return direction;
            }

            set
            {
                direction = value;
            }
        }

        public Vector2 Position
        {
            get
            {
                return animation.Position;
            }

            set
            {
                animation.Position = value;
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                return animation.Rectangle;
            }
        }

        public void Initialize(Animation animation, Direction direction, MovementType movementType)
        {
            this.animation = animation;
            this.direction = direction;
            this.movementType = movementType;
            this.speed = 2;

        }
        public void Update(GameTime gameTime)
        {
            if (direction == Direction.LeftRight)
            {
                animation.Position.X += speed;                
            }

            else
            {
                animation.Position.X -= speed;
            }
            animation.Update(gameTime);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animation.Draw(spriteBatch);

        }

    }
}
