using Inkyvirus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace Inkyvirus.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WelcomePage : Page
    {
        /// <summary>
        /// Restart global game state
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            GameState.CurrentLevel = 0;
            GameState.Levels = new List<LevelDefinition>();
            GameState.OverallElapsedTime = TimeSpan.Zero;

            soundOn.IsChecked = Settings.IsSound;
        }

        public WelcomePage()
        {
            this.InitializeComponent();
            ink.InkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Pen | Windows.UI.Core.CoreInputDeviceTypes.Touch | Windows.UI.Core.CoreInputDeviceTypes.Mouse;

            if (Settings.IsSound)
                App.BackgroundPlayer.Play();
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // if there is no user signature
            if (ink.InkPresenter.StrokeContainer.GetStrokes().Count == 0)
            {
                border.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                // initialize random seed
                GameState.R = new System.Random(ink.InkPresenter.StrokeContainer.GetStrokes().Sum(x => x.StrokeDuration.HasValue ? (int)x.StrokeDuration.Value.TotalMilliseconds : 0));
                GameState.PlayerId = Guid.NewGuid().ToString();

                if (diffEasy.IsChecked.Value) GameState.Difficulty = Difficulty.Easy;
                if (diffMedium.IsChecked.Value) GameState.Difficulty = Difficulty.Medium;
                if (diffHard.IsChecked.Value) GameState.Difficulty = Difficulty.Hard;
                Levels.Add();

                var root = Window.Current.Content as Frame;
                root.Navigate(typeof(Views.GamePage), null, new DrillInNavigationTransitionInfo());

                SavePlayerSignature();
            }
        }

        /// <summary>
        /// Saves player signature to a localappdata
        /// </summary>
        private async void SavePlayerSignature()
        {
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(GameState.PlayerId + ".isf");
            // When chosen, picker returns a reference to the selected file.
            if (file != null)
            {
                // Prevent updates to the file until updates are
                // finalized with call to CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(file);
                // Open a file stream for writing.
                IRandomAccessStream stream = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
                // Write the ink strokes to the output stream.
                using (IOutputStream outputStream = stream.GetOutputStreamAt(0))
                {
                    await ink.InkPresenter.StrokeContainer.SaveAsync(outputStream);
                    await outputStream.FlushAsync();
                }
                stream.Dispose();
            }
        }

        private void diffEasy_Checked(object sender, RoutedEventArgs e)
        {
            diffMedium.IsChecked = false;
            diffHard.IsChecked = false;
        }

        private void diffMedium_Checked(object sender, RoutedEventArgs e)
        {
            diffEasy.IsChecked = false;
            diffHard.IsChecked = false;
        }

        private void diffHard_Checked(object sender, RoutedEventArgs e)
        {
            diffEasy.IsChecked = false;
            diffMedium.IsChecked = false;
        }

        private void soundOn_Click(object sender, RoutedEventArgs e)
        {
            Settings.IsSound = soundOn.IsChecked.Value;
            Settings.Save();

            if (!Settings.IsSound && App.BackgroundPlayer.PlaybackSession.PlaybackState == Windows.Media.Playback.MediaPlaybackState.Playing)
                App.BackgroundPlayer.Pause();

            if (Settings.IsSound && App.BackgroundPlayer.PlaybackSession.PlaybackState != Windows.Media.Playback.MediaPlaybackState.Playing)
                App.BackgroundPlayer.Play();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var abdlg = new AboutDialog();
            abdlg.ShowAsync();
        }
    }
}