using Inkyvirus.Models;
using System;

namespace Inkyvirus
{
    /// <summary>
    /// Definition of the game level
    /// </summary>
    internal class LevelDefinition
    {
        /// <summary>
        /// Emoji which will be used for background
        /// </summary>
        public string Background { get; set; }

        /// <summary>
        /// Number of bacterias in level
        /// </summary>
        public int BacteriasNumber { get; set; }

        /// <summary>
        /// Maximum size of bacteria
        /// </summary>
        public int BacteriasMaxSize { get; set; }

        /// <summary>
        /// Minimum size of bacteria
        /// </summary>
        public int BacteriasMinSize { get; set; }

        /// <summary>
        /// Number of pills in level
        /// </summary>
        public int PillsNumber { get; set; }

        /// <summary>
        /// Maximum size of pill
        /// </summary>
        public int PillsMaxSize { get; set; }

        /// <summary>
        /// Minimum size of pill
        /// </summary>
        public int PillsMinSize { get; set; }

        /// <summary>
        /// How much time should be reduced by killing pill
        /// </summary>
        public TimeSpan PillPenalty { get; set; }

        /// <summary>
        /// List of possible behaviours for bacteria
        /// </summary>
        public EntityBehaviour[] BacteriaBehaviours { get; set; }

        /// <summary>
        /// List of possible behaviours for pills
        /// </summary>
        public EntityBehaviour[] PillsBehaviours { get; set; }

        /// <summary>
        /// Time available for level
        /// </summary>
        public TimeSpan AvailableTime { get; set; }
    }
}