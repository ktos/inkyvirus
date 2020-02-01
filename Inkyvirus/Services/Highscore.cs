using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;

namespace Inkyvirus.Services
{
    /// <summary>
    /// Highscore record saved in a database
    /// </summary>
    internal class Score
    {
        public string PlayerId { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public Difficulty Difficulty { get; set; }
    }

    /// <summary>
    /// Service for returning high score results
    /// </summary>
    internal class Highscore
    {
        /// <summary>
        /// Loads a list of high scores
        /// </summary>
        /// <returns></returns>
        public async Task<List<Score>> LoadAsync()
        {
            StorageFile file;
            var item = await ApplicationData.Current.LocalFolder.TryGetItemAsync("highscores.txt");
            if (item == null)
                file = await ApplicationData.Current.LocalFolder.CreateFileAsync("highscores.txt");
            else
                file = await ApplicationData.Current.LocalFolder.GetFileAsync("highscores.txt");

            var lines = await FileIO.ReadLinesAsync(file);
            var highScores = new List<Score>();

            foreach (var line in lines)
            {
                var s = line.Split('|');
                highScores.Add(new Score { PlayerId = s[0], ElapsedTime = TimeSpan.Parse(s[1]), Difficulty = (Difficulty)int.Parse(s[2]) });
            }

            return highScores;
        }

        /// <summary>
        /// Saves a new high score to a database
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public async Task SaveAsync(string playerId, TimeSpan time, Difficulty difficulty)
        {
            StorageFile file;
            var item = await ApplicationData.Current.LocalFolder.TryGetItemAsync("highscores.txt");
            if (item == null)
                file = await ApplicationData.Current.LocalFolder.CreateFileAsync("highscores.txt");
            else
                file = await ApplicationData.Current.LocalFolder.GetFileAsync("highscores.txt");

            await FileIO.AppendLinesAsync(file, new string[] { $"{playerId}|{time.ToString()}|{(int)difficulty}" });
        }

        /// <summary>
        /// Loads player signature based in his or her GUID
        /// </summary>
        /// <param name="ink"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public async Task LoadPlayerSignatureAsync(InkCanvas ink, string playerId)
        {
            var file = await ApplicationData.Current.LocalFolder.GetFileAsync(playerId + ".isf");

            if (file != null)
            {
                var stream = await file.OpenAsync(FileAccessMode.Read);
                using (var inputStream = stream.GetInputStreamAt(0))
                {
                    await ink.InkPresenter.StrokeContainer.LoadAsync(inputStream);
                }
                stream.Dispose();
            }

            return;
        }
    }
}