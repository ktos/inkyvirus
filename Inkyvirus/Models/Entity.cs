using System;
using System.Collections.Generic;
using Windows.Foundation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Inkyvirus.Models
{
    /// <summary>
    /// Represents game entity
    /// </summary>
    internal class Entity
    {
        private int maxWidth;
        private int maxHeight;

        /// <summary>
        /// UI object which is a visual representation of Entity
        /// </summary>
        public TextBlock Sprite { get; set; }

        /// <summary>
        /// The centerpoint for the entity
        /// </summary>
        public Point CentralPoint { get; set; }

        /// <summary>
        /// Is it alive?
        /// </summary>
        public bool IsDead { get; set; }

        /// <summary>
        /// How the entity should move?
        /// </summary>
        public EntityBehaviour Behaviour { get; set; }

        /// <summary>
        /// Initializes a new entity
        /// </summary>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        /// <param name="behaviour"></param>
        public Entity(int maxWidth, int maxHeight, EntityBehaviour behaviour)
        {
            CentralPoint = new Point(GameState.R.Next(50, maxWidth - 50), GameState.R.Next(50, maxHeight - 50));

            this.maxHeight = maxHeight;
            this.maxWidth = maxWidth;

            Behaviour = behaviour;

            Sprite = new TextBlock();
            Sprite.FontSize = 28;
            Sprite.Text = "x";
        }

        /// <summary>
        /// Change the centerpoint based on the behaviour
        /// </summary>
        public virtual void Move()
        {
            double newX = CentralPoint.X, newY = CentralPoint.Y;
            if (Behaviour == EntityBehaviour.SlowRandom)
            {
                newX += GameState.R.Next(-1, 1);
                newY += GameState.R.Next(-1, 1);
            }

            if (Behaviour == EntityBehaviour.FastRandom)
            {
                newX += GameState.R.Next(-8, 8);
                newY += GameState.R.Next(-8, 8);
            }

            if (Behaviour == EntityBehaviour.Horizontal)
            {
                newX += -3;
            }

            if (Behaviour == EntityBehaviour.Vertical)
            {
                newY += -3;
            }

            if (newX > maxWidth - 20) newX = 0;
            if (newX <= 20) newX = maxWidth - 20;

            if (newY > maxHeight - 20) newY = 0;
            if (newY <= 20) newY = maxHeight - 20;

            CentralPoint = new Point(newX, newY);
        }
    }

    /// <summary>
    /// List of possible entity behaviours
    /// </summary>
    internal enum EntityBehaviour
    {
        Static,
        SlowRandom,
        FastRandom,
        Horizontal,
        Vertical
    }
}