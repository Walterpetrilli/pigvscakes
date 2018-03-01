using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pigvscakes
{
    public class NewPig:AnimationSprite
    {

        private Direction direction;
        public enum MovementType { Recto, Senoidal, Parabolico, ZigZag }
        private int speed;
        public states State { get; set; }
        public enum states { right, left, injured, jump }

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

        public Vector2 Pos
        {
            get
            {
                return Position;
            }

            set
            {
                Position = value;
            }
        }

        public Rectangle Rec
        {
            get
            {
                return Rectangle1;
            }
        }

        public NewPig(Texture2D texture)
        {
            Vector2 vector2 = new Vector2(750, 460);
            color = Color.White;
            FrameWidth = 60;
            FrameHeight = 55;
            frameCount = 14;
            frameTime = 120;
            scale = 1f;
            Looping = true;
            Pos = vector2;
            spriteStrip = texture;
            elapsedTime = 0;
            currentFrame = 0;
            Active = true;
            speed = 1;
            selectedImage = State;
            images.Add(states.right, Game1.Instance.Content.Load<Texture2D>("pig"));

            


        }

        public override void Update(GameTime gameTime)
        {
            State = states.right;
            selectedImage = states.right;
            Position.X += speed;

        }


    }
}
