using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inkyvirus.Models
{
    internal static class Levels
    {
        public static void Add()
        {
            if (GameState.Difficulty == Difficulty.Easy)
            {
                GameState.Levels.Add(new LevelDefinition
                {
                    BacteriasNumber = 5,
                    PillsNumber = 0,
                    PillsMaxSize = 60,
                    PillsMinSize = 28,
                    PillsBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom },
                    PillPenalty = TimeSpan.FromMilliseconds(0.5),
                    Background = "🦶",
                    BacteriaBehaviours = new EntityBehaviour[] { EntityBehaviour.Static },
                    AvailableTime = TimeSpan.FromSeconds(20),
                    BacteriasMinSize = 48,
                    BacteriasMaxSize = 60
                });

                GameState.Levels.Add(new LevelDefinition
                {
                    BacteriasNumber = 7,
                    PillsNumber = 0,
                    PillsMaxSize = 60,
                    PillsMinSize = 28,
                    PillsBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom },
                    PillPenalty = TimeSpan.FromMilliseconds(0.5),
                    Background = "👍",
                    BacteriaBehaviours = new EntityBehaviour[] { EntityBehaviour.Static, EntityBehaviour.SlowRandom },
                    AvailableTime = TimeSpan.FromSeconds(15),
                    BacteriasMinSize = 38,
                    BacteriasMaxSize = 50
                });

                GameState.Levels.Add(new LevelDefinition
                {
                    BacteriasNumber = 9,
                    PillsNumber = 0,
                    PillsMaxSize = 60,
                    PillsMinSize = 28,
                    PillsBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom },
                    PillPenalty = TimeSpan.FromMilliseconds(0.5),
                    Background = "🤧",
                    BacteriaBehaviours = new EntityBehaviour[] { EntityBehaviour.Static, EntityBehaviour.SlowRandom, EntityBehaviour.FastRandom },
                    AvailableTime = TimeSpan.FromSeconds(15),
                    BacteriasMinSize = 38,
                    BacteriasMaxSize = 45
                });

                GameState.Levels.Add(new LevelDefinition
                {
                    BacteriasNumber = 13,
                    PillsNumber = 0,
                    PillsMaxSize = 60,
                    PillsMinSize = 28,
                    PillsBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom },
                    PillPenalty = TimeSpan.FromMilliseconds(0.5),
                    Background = "😷",
                    BacteriaBehaviours = new EntityBehaviour[] { EntityBehaviour.SlowRandom, EntityBehaviour.FastRandom },
                    AvailableTime = TimeSpan.FromSeconds(14),
                    BacteriasMinSize = 38,
                    BacteriasMaxSize = 45
                });

                GameState.Levels.Add(new LevelDefinition
                {
                    BacteriasNumber = 14,
                    PillsNumber = 0,
                    PillsMaxSize = 60,
                    PillsMinSize = 28,
                    PillsBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom },
                    PillPenalty = TimeSpan.FromMilliseconds(0.5),
                    Background = "🤢",
                    BacteriaBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom },
                    AvailableTime = TimeSpan.FromSeconds(14),
                    BacteriasMinSize = 38,
                    BacteriasMaxSize = 45
                });

                GameState.Levels.Add(new LevelDefinition
                {
                    BacteriasNumber = 15,
                    PillsNumber = 2,
                    PillsMaxSize = 60,
                    PillsMinSize = 28,
                    PillsBehaviours = new EntityBehaviour[] { EntityBehaviour.Static },
                    PillPenalty = TimeSpan.FromMilliseconds(0.5),
                    Background = "🦷",
                    BacteriaBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom },
                    AvailableTime = TimeSpan.FromSeconds(14),
                    BacteriasMinSize = 38,
                    BacteriasMaxSize = 45
                });
            }
            else if (GameState.Difficulty == Difficulty.Medium)
            {
                GameState.Levels.Add(new LevelDefinition
                {
                    BacteriasNumber = 16,
                    PillsNumber = 4,
                    PillsMaxSize = 45,
                    PillsMinSize = 28,
                    PillsBehaviours = new EntityBehaviour[] { EntityBehaviour.Static, EntityBehaviour.SlowRandom },
                    PillPenalty = TimeSpan.FromMilliseconds(0.5),
                    Background = "🦷",
                    BacteriaBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom },
                    AvailableTime = TimeSpan.FromSeconds(13),
                    BacteriasMinSize = 30,
                    BacteriasMaxSize = 45
                });

                GameState.Levels.Add(new LevelDefinition
                {
                    BacteriasNumber = 17,
                    PillsNumber = 4,
                    PillsMaxSize = 30,
                    PillsMinSize = 28,
                    PillsBehaviours = new EntityBehaviour[] { EntityBehaviour.SlowRandom },
                    PillPenalty = TimeSpan.FromMilliseconds(0.5),
                    Background = "👅",
                    BacteriaBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom },
                    AvailableTime = TimeSpan.FromSeconds(13),
                    BacteriasMinSize = 30,
                    BacteriasMaxSize = 45
                });

                GameState.Levels.Add(new LevelDefinition
                {
                    BacteriasNumber = 18,
                    PillsNumber = 4,
                    PillsMaxSize = 30,
                    PillsMinSize = 28,
                    PillsBehaviours = new EntityBehaviour[] { EntityBehaviour.SlowRandom },
                    PillPenalty = TimeSpan.FromMilliseconds(0.5),
                    Background = "🦴",
                    BacteriaBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom, EntityBehaviour.Horizontal },
                    AvailableTime = TimeSpan.FromSeconds(15),
                    BacteriasMinSize = 30,
                    BacteriasMaxSize = 45
                });

                GameState.Levels.Add(new LevelDefinition
                {
                    BacteriasNumber = 20,
                    PillsNumber = 4,
                    PillsMaxSize = 30,
                    PillsMinSize = 28,
                    PillsBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom },
                    PillPenalty = TimeSpan.FromMilliseconds(0.5),
                    Background = "💪",
                    BacteriaBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom, EntityBehaviour.Horizontal },
                    AvailableTime = TimeSpan.FromSeconds(15),
                    BacteriasMinSize = 30,
                    BacteriasMaxSize = 45
                });

                GameState.Levels.Add(new LevelDefinition
                {
                    BacteriasNumber = 20,
                    PillsNumber = 4,
                    PillsMaxSize = 30,
                    PillsMinSize = 28,
                    PillsBehaviours = new EntityBehaviour[] { EntityBehaviour.SlowRandom, EntityBehaviour.FastRandom },
                    PillPenalty = TimeSpan.FromMilliseconds(0.5),
                    Background = "👂",
                    BacteriaBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom, EntityBehaviour.Horizontal, EntityBehaviour.Vertical },
                    AvailableTime = TimeSpan.FromSeconds(15),
                    BacteriasMinSize = 28,
                    BacteriasMaxSize = 36
                });

                GameState.Levels.Add(new LevelDefinition
                {
                    BacteriasNumber = 20,
                    PillsNumber = 4,
                    PillsMaxSize = 30,
                    PillsMinSize = 28,
                    PillsBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom },
                    PillPenalty = TimeSpan.FromMilliseconds(0.5),
                    Background = "👃",
                    BacteriaBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom, EntityBehaviour.Horizontal, EntityBehaviour.Vertical },
                    AvailableTime = TimeSpan.FromSeconds(15),
                    BacteriasMinSize = 28,
                    BacteriasMaxSize = 36
                });
            }
            else if (GameState.Difficulty == Difficulty.Hard)
            {
                GameState.Levels.Add(new LevelDefinition
                {
                    BacteriasNumber = 22,
                    PillsNumber = 4,
                    PillsMaxSize = 30,
                    PillsMinSize = 28,
                    PillsBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom },
                    PillPenalty = TimeSpan.FromMilliseconds(0.5),
                    Background = "🧫",
                    BacteriaBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom, EntityBehaviour.Horizontal, EntityBehaviour.Vertical },
                    AvailableTime = TimeSpan.FromSeconds(16),
                    BacteriasMinSize = 28,
                    BacteriasMaxSize = 36
                });

                GameState.Levels.Add(new LevelDefinition
                {
                    BacteriasNumber = 25,
                    PillsNumber = 6,
                    PillsMaxSize = 30,
                    PillsMinSize = 28,
                    PillsBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom },
                    PillPenalty = TimeSpan.FromMilliseconds(0.5),
                    Background = "💉",
                    BacteriaBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom, EntityBehaviour.Horizontal, EntityBehaviour.Vertical },
                    AvailableTime = TimeSpan.FromSeconds(17),
                    BacteriasMinSize = 28,
                    BacteriasMaxSize = 30
                });

                GameState.Levels.Add(new LevelDefinition
                {
                    BacteriasNumber = 25,
                    PillsNumber = 6,
                    PillsMaxSize = 30,
                    PillsMinSize = 28,
                    PillsBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom },
                    PillPenalty = TimeSpan.FromMilliseconds(0.5),
                    Background = "💔",
                    BacteriaBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom, EntityBehaviour.Horizontal, EntityBehaviour.Vertical },
                    AvailableTime = TimeSpan.FromSeconds(18),
                    BacteriasMinSize = 28,
                    BacteriasMaxSize = 40
                });

                GameState.Levels.Add(new LevelDefinition
                {
                    BacteriasNumber = 27,
                    PillsNumber = 6,
                    PillsMaxSize = 36,
                    PillsMinSize = 28,
                    PillsBehaviours = new EntityBehaviour[] { EntityBehaviour.SlowRandom },
                    PillPenalty = TimeSpan.FromMilliseconds(0.5),
                    Background = "💔",
                    BacteriaBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom, EntityBehaviour.Horizontal, EntityBehaviour.Vertical },
                    AvailableTime = TimeSpan.FromSeconds(19),
                    BacteriasMinSize = 28,
                    BacteriasMaxSize = 40
                });

                GameState.Levels.Add(new LevelDefinition
                {
                    BacteriasNumber = 28,
                    PillsNumber = 6,
                    PillsMaxSize = 36,
                    PillsMinSize = 28,
                    PillsBehaviours = new EntityBehaviour[] { EntityBehaviour.SlowRandom },
                    PillPenalty = TimeSpan.FromMilliseconds(0.5),
                    Background = "🧬",
                    BacteriaBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom, EntityBehaviour.Horizontal, EntityBehaviour.Vertical },
                    AvailableTime = TimeSpan.FromSeconds(20),
                    BacteriasMinSize = 28,
                    BacteriasMaxSize = 40
                });

                GameState.Levels.Add(new LevelDefinition
                {
                    BacteriasNumber = 30,
                    PillsNumber = 1,
                    PillsMaxSize = 60,
                    PillsMinSize = 28,
                    PillsBehaviours = new EntityBehaviour[] { EntityBehaviour.FastRandom },
                    PillPenalty = TimeSpan.FromMilliseconds(0.5),
                    Background = "🧠",
                    BacteriaBehaviours = new EntityBehaviour[] { EntityBehaviour.Horizontal, EntityBehaviour.Vertical },
                    AvailableTime = TimeSpan.FromSeconds(20),
                    BacteriasMinSize = 28,
                    BacteriasMaxSize = 40
                });
            }
        }
    }
}