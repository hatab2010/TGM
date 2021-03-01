using System;
using System.IO;
using WebBotCore.Interfase;
using WebBotCore.Model;

namespace WebBotCore.Data
{
    public class ChromeProfile : IChromeProfile
    {
        public string CurrentProfileDirectory => $"{Directory.GetCurrentDirectory()}/{Id}";
        public ChromeProfile(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public ChromeProfile CopyProfileDirectory(string Id)
        {
            var copy = new ChromeProfile(Id);

            Helper.CopyDirectory(new DirectoryInfo(CurrentProfileDirectory),
                new DirectoryInfo(copy.CurrentProfileDirectory));

            return copy;
        }
    }
}
