using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inkyvirus.Models
{
    class Bacteria : Entity
    {
        public Bacteria(int maxWidth, int maxHeight, EntityBehaviour behaviour, int size) : base(maxWidth, maxHeight, behaviour)
        {
            Sprite.FontSize = size;
            Sprite.Text = "🦠";
        }
    }
}