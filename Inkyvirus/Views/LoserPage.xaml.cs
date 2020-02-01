using Inkyvirus.Models;
using System;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Inkyvirus.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoserPage : Page
    {
        public LoserPage()
        {
            this.InitializeComponent();

            if (Settings.IsSound)
                loseAudio.Play();

            RemoveSignatureWhenNotHighscore();
        }

        private async void RemoveSignatureWhenNotHighscore()
        {
            var userFile = await ApplicationData.Current.LocalFolder.GetFileAsync(GameState.PlayerId + ".isf");
            await userFile.DeleteAsync();
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            GameState.Restart();
        }
    }
}