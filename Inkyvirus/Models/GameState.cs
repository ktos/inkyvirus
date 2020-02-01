using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Inkyvirus
{
    /// <summary>
    /// Saves overall game state
    /// </summary>
    internal static class GameState
    {
        /// <summary>
        /// Player GUID
        /// </summary>
        public static string PlayerId;

        /// <summary>
        /// Random generator based on seed by user's signature
        /// </summary>
        public static Random R { get; set; }

        /// <summary>
        /// Current level number
        /// </summary>
        public static int CurrentLevel { get; set; }

        /// <summary>
        /// Definition of the current level
        /// </summary>
        public static LevelDefinition CurrentLevelDefinition
        {
            get
            {
                return Levels[CurrentLevel];
            }
        }

        /// <summary>
        /// All level definitions
        /// </summary>
        public static List<LevelDefinition> Levels { get; set; }

        /// <summary>
        /// How many time user has remaining in total
        /// </summary>
        public static TimeSpan OverallElapsedTime { get; set; }

        /// <summary>
        /// Game difficulty
        /// </summary>
        public static Difficulty Difficulty { get; set; }

        /// <summary>
        /// Goes to winner page
        /// </summary>
        /// <param name="remainingTime"></param>
        public static void Win(TimeSpan remainingTime)
        {
            OverallElapsedTime += remainingTime;

            CurrentLevel++;
            var root = Window.Current.Content as Frame;

            var hs = new Services.Highscore();

            if (CurrentLevel >= Levels.Count)
            {
                root.Navigate(typeof(Views.WinnerPage), remainingTime, new DrillInNavigationTransitionInfo());
            }
            else
            {
                root.Navigate(typeof(Views.GamePage), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromBottom });
            }
        }

        /// <summary>
        /// Goes to loser page
        /// </summary>
        public static void Lose()
        {
            var root = Window.Current.Content as Frame;
            root.Navigate(typeof(Views.LoserPage), null, new DrillInNavigationTransitionInfo());
        }

        /// <summary>
        /// Restarts the game
        /// </summary>
        public static void Restart()
        {
            var root = Window.Current.Content as Frame;
            root.Navigate(typeof(Views.WelcomePage), null, new DrillInNavigationTransitionInfo());
        }
    }

    internal enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
}