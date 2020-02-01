using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inkyvirus.Models
{
    /// <summary>
    /// A pill
    /// </summary>
    internal class Pill : Entity
    {
        /// <summary>
        /// Initializes a new instance of pill entity
        /// </summary>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        /// <param name="behaviour"></param>
        /// <param name="size"></param>
        public Pill(int maxWidth, int maxHeight, EntityBehaviour behaviour, int size) : base(maxWidth, maxHeight, behaviour)
        {
            Sprite.FontSize = size;
            Sprite.Text = "💊";
        }
    }
}