using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pigvscakes
{
    public class AppleFabric : FabricBase
    {
        TimeSpan tiempoanterior;
        public override void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Subtract(tiempoanterior).Seconds > 2)
            {
                Apple manzana = new Apple(new Point(rnd.Next(
                    Game1.Instance.graphics.GraphicsDevice.Viewport.Width
                    ), 450));
                Game1.Instance.newSprites.Add(manzana);
                tiempoanterior = gameTime.TotalGameTime;
            }


        }

    }
}
