using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Inkyvirus.Models
{
    internal static class Settings
    {
        public static bool IsSound { get; set; }

        public static async void Load()
        {
            StorageFile file;
            var item = await ApplicationData.Current.LocalFolder.TryGetItemAsync("settings.txt");
            if (item == null)
                file = await ApplicationData.Current.LocalFolder.CreateFileAsync("settings.txt");
            else
                file = await ApplicationData.Current.LocalFolder.GetFileAsync("settings.txt");

            var settings = await FileIO.ReadTextAsync(file);

            IsSound = settings.Contains("s=1");
        }

        public static async void Save()
        {
            StorageFile file;
            var item = await ApplicationData.Current.LocalFolder.TryGetItemAsync("settings.txt");
            if (item == null)
                file = await ApplicationData.Current.LocalFolder.CreateFileAsync("settings.txt");
            else
                file = await ApplicationData.Current.LocalFolder.GetFileAsync("settings.txt");

            await FileIO.WriteTextAsync(file, IsSound ? "s=1" : "s=0");
        }
    }
}