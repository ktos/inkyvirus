using Inkyvirus.Models;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Inkyvirus.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WinnerPage : Page
    {
        public WinnerPage()
        {
            this.InitializeComponent();

            score.Text = string.Format("⌛ {0:mm\\:ss\\,ff}", GameState.OverallElapsedTime);

            PopulateHighscoresAsync();

            if (Settings.IsSound)
                winAudio.Play();
        }

        public async Task PopulateHighscoresAsync()
        {
            var hs = new Services.Highscore();
            await hs.SaveAsync(GameState.PlayerId, GameState.OverallElapsedTime, GameState.Difficulty);

            var scores = await hs.LoadAsync();

            foreach (var item in scores.Where(x => x.Difficulty == GameState.Difficulty).OrderBy(x => x.ElapsedTime))
            {
                var g = new Grid();

                g.ColumnDefinitions.Add(new ColumnDefinition() { Width = new Windows.UI.Xaml.GridLength(1, Windows.UI.Xaml.GridUnitType.Star) });
                g.ColumnDefinitions.Add(new ColumnDefinition() { Width = new Windows.UI.Xaml.GridLength(1, Windows.UI.Xaml.GridUnitType.Star) });

                var t = new InkCanvas() { Width = 250, Height = 100 };
                await hs.LoadPlayerSignatureAsync(t, item.PlayerId);
                Grid.SetColumn(t, 0);

                var t2 = new TextBlock() { FontSize = 28, Text = string.Format("⌛ {0:mm\\:ss\\,ff}", item.ElapsedTime), HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center };
                if (item.PlayerId == GameState.PlayerId)
                    g.Background = new SolidColorBrush(Colors.Orange);

                Grid.SetColumn(t2, 1);

                g.Children.Add(t);
                g.Children.Add(t2);

                highscores.Children.Add(g);
            }

            return;
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            GameState.Restart();
        }
    }
}