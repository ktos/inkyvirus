using Inkyvirus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Inkyvirus.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        private DispatcherTimer timer;
        private DispatcherTimer timer2;
        private bool isNavigating = false;

        private List<Entity> entities;
        private TimeSpan remainingTime;

        public GamePage()
        {
            this.InitializeComponent();

            if (GameState.R == null) GameState.R = new Random();

            inkCanvas.Width = (int)Window.Current.Bounds.Width;
            inkCanvas.Height = (int)Window.Current.Bounds.Height;
            inkCanvas.InkPresenter.InputConfiguration.IsEraserInputEnabled = false;
            inkCanvas.InkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Pen | Windows.UI.Core.CoreInputDeviceTypes.Touch | Windows.UI.Core.CoreInputDeviceTypes.Mouse;
            inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(new Windows.UI.Input.Inking.InkDrawingAttributes { Color = Colors.Red });

            background.Text = GameState.Levels[GameState.CurrentLevel].Background;

            // timer for moving entities
            timer = new DispatcherTimer();

            // timer for calculating time
            timer2 = new DispatcherTimer();

            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer2.Interval = TimeSpan.FromMilliseconds(100);

            timer.Tick += Timer_Tick;
            timer2.Tick += Timer2_Tick;

            inkCanvas.InkPresenter.StrokesCollected += InkPresenter_StrokesCollected;

            entities = new List<Entity>();

            // generate viruses
            for (int i = 0; i < GameState.CurrentLevelDefinition.BacteriasNumber; i++)
            {
                entities.Add(new Bacteria(
                    maxWidth: (int)inkCanvas.Width,
                    maxHeight: (int)inkCanvas.Height,
                    behaviour: GameState.CurrentLevelDefinition.BacteriaBehaviours[GameState.R.Next(GameState.CurrentLevelDefinition.BacteriaBehaviours.Length)],
                    size: GameState.R.Next(GameState.CurrentLevelDefinition.BacteriasMinSize, GameState.CurrentLevelDefinition.BacteriasMaxSize)
                ));
            }

            // generate pills
            for (int i = 0; i < GameState.CurrentLevelDefinition.PillsNumber; i++)
            {
                entities.Add(new Pill(
                    maxWidth: (int)inkCanvas.Width,
                    maxHeight: (int)inkCanvas.Height,
                    behaviour: GameState.CurrentLevelDefinition.PillsBehaviours[GameState.R.Next(GameState.CurrentLevelDefinition.PillsBehaviours.Length)],
                    size: GameState.R.Next(GameState.CurrentLevelDefinition.PillsMinSize, GameState.CurrentLevelDefinition.PillsMaxSize)
                ));
            }

            // initial position
            foreach (var item in entities)
            {
                canvas.Children.Add(item.Sprite);
                PositionEntitySprite(item);
            }

            remainingTime = GameState.CurrentLevelDefinition.AvailableTime;

            // let's go!
            timer.Start();
            timer2.Start();
        }

        /// <summary>
        /// Updates remaining time and checks win/fail rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer2_Tick(object sender, object e)
        {
            remainingTime -= timer2.Interval;
            time.Text = string.Format("⏳ {0:ss\\,ff}", remainingTime);

            if (remainingTime <= TimeSpan.Zero && !isNavigating)
            {
                timer.Stop();
                timer2.Stop();
                if (BacteriaAlive() == 0)
                {
                    isNavigating = true;
                    GameState.Win(GameState.CurrentLevelDefinition.AvailableTime - remainingTime);
                }
                else
                {
                    isNavigating = true;
                    GameState.Lose();
                }
            }
        }

        /// <summary>
        /// Moves entity's representation to the point it should be
        /// </summary>
        /// <param name="item"></param>
        private void PositionEntitySprite(Entity item)
        {
            Canvas.SetLeft(item.Sprite, item.CentralPoint.X);
            Canvas.SetTop(item.Sprite, item.CentralPoint.Y);
        }

        /// <summary>
        /// Moves entities
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, object e)
        {
            foreach (var item in entities.Where(x => x.Behaviour != EntityBehaviour.Static))
            {
                item.Move();
                PositionEntitySprite(item);
            }
        }

        /// <summary>
        /// Counts how many bacteria is alive
        /// </summary>
        /// <returns></returns>
        private int BacteriaAlive()
        {
            return entities.Where(x => !x.IsDead && x.GetType() == typeof(Bacteria)).Count();
        }

        /// <summary>
        /// Run when user creates a new stroke on the ink canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void InkPresenter_StrokesCollected(Windows.UI.Input.Inking.InkPresenter sender, Windows.UI.Input.Inking.InkStrokesCollectedEventArgs args)
        {
            foreach (var stroke in args.Strokes)
            {
                foreach (var entity in entities.Where(x => !x.IsDead).ToList())
                {
                    // check if stroke is bounding entity centerpoint
                    if (stroke.BoundingRect.Contains(entity.CentralPoint))
                    {
                        // remove sprite
                        canvas.Children.Remove(entity.Sprite);
                        entity.IsDead = true;

                        // take penalty for killing pill
                        if (entity.GetType() == typeof(Pill))
                        {
                            remainingTime -= GameState.CurrentLevelDefinition.PillPenalty;
                        }
                        else
                        {
                            if (Settings.IsSound)
                                audioKill.Play();
                        }

                        break;
                    }
                }

                stroke.Selected = true;
            }

            inkCanvas.InkPresenter.StrokeContainer.DeleteSelected();

            // check winning rules
            if (BacteriaAlive() == 0)
            {
                timer.Stop();
                timer2.Stop();
                isNavigating = true;
                GameState.Win(remainingTime);
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            timer.Stop();
            timer2.Stop();
        }
    }
}