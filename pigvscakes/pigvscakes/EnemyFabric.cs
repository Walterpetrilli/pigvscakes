using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace pigvscakes
{
    public class EnemyFabric : FabricBase
    {

        TimeSpan tiempoanterior;
        public override void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Subtract(tiempoanterior).Seconds > 2)
            {
                Cake pastel = new Cake(new Point(rnd.Next(
                    Game1.Instance.graphics.GraphicsDevice.Viewport.Width
                    ), 430));
                Game1.Instance.newSprites.Add(pastel);
                tiempoanterior = gameTime.TotalGameTime;
            }


        }
    }
}
