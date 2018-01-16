using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pigvscakes
{
    public abstract class ScoreSprite : HealtySprite
    {
        /// La cantidad de puntos que tiene un Sprite
        public virtual int Score { get; set; }

    }
}
