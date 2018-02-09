using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pigvscakes
{
    public abstract class HealtySprite : MultiImageSprite
    {
        /// La cantidad de vida que tiene un Sprite
        public virtual int Health { get; set; }

    }
}
